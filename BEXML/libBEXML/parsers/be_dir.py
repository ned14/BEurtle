# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from ..parserbase import ParserBase
from ..issue import Issue as IssueBase
from ..comment import Comment as CommentBase

import urllib2, os, re, codecs, logging
from encodings import utf_8 as ironpython_utf8_override
from urlparse import urlparse
from collections import namedtuple
from uuid import UUID
import yaml

log=logging.getLogger(__name__)


class BEDirComment(CommentBase):
    """A comment loaded from a filing system based BE repo"""

    def __init__(self, parentIssue, dirpath, encoding):
        CommentBase.__init__(self, parentIssue)
        self.dirpath=dirpath
        self.encoding=encoding
        self.isLoaded=True
        self.uuid=os.path.basename(dirpath)
        self.isLoaded=False
        self.stat=None

    def __getStat(self):
        """Returns the stat for the file backing of this comment"""
        stat=namedtuple('CommentStat', ['values', 'body'])
        stat.values=os.stat(os.path.join(self.dirpath, "values"))
        stat.body=os.stat(os.path.join(self.dirpath, "body"))
        return stat

    @property
    def isStale(self):
        """True if the file backing for this comment is newer than us"""
        if not self.isLoaded or not self.tracksStaleness:
            return None
        stat=self.__getStat()
        return stat.values!=self.stat.values

    def load(self, reload=False):
        """Loads in the comment from the filing system"""
        if not reload and self.isLoaded:
            return
        with codecs.open(os.path.join(self.dirpath, "values"), 'r', self.encoding) as ih:
            values=yaml.safe_load(ih)
            assert isinstance(values, dict)
        with codecs.open(os.path.join(self.dirpath, "body"), 'r', self.encoding) as ih:
            values['body']=ih.read()
        notloaded=self._load_mostly(values)
        if len(notloaded)>0:
            log.warn("The following values from comment '"+self.dirpath+"' were not recognised: "+repr(notloaded))
        self.isLoaded=True
        self.isDirty=False
        if self.tracksStaleness:
            self.stat=self.__getStat()


class BEDirIssue(IssueBase):
    """An issue loaded from a filing system based BE repo"""

    def __init__(self, dirpath, encoding):
        IssueBase.__init__(self)
        self.dirpath=dirpath
        self.encoding=encoding
        self.isLoaded=True
        self.uuid=os.path.basename(dirpath)
        self.isLoaded=False
        self.stat=None

    def __getStat(self):
        """Returns the stat for the file backing of this issue"""
        stat=namedtuple('IssueStat', ['values'])
        stat.values=os.stat(os.path.join(self.dirpath, "values"))
        return stat

    @property
    def isStale(self):
        """True if the file backing for this issue is newer than us"""
        if not self.isLoaded or not self.tracksStaleness:
            return None
        stat=self.__getStat()
        return stat.values!=self.stat.values

    def addComment(self, dirpath):
        """Adds a comment to the issue"""
        temp1=self.isLoaded
        comment=BEDirComment(self, dirpath, self.encoding)
        try:
            self.isLoaded=True
            comment.isLoaded=True
            return IssueBase.addComment(self, comment)
        finally:
            comment.isLoaded=False
            self.isLoaded=temp1

    def removeComment(self, comment):
        temp=self.isLoaded
        try:
            self.isLoaded=True
            return IssueBase.removeComment(self, comment)
        finally:
            self.isLoaded=temp

    def load(self, reload=False):
        """Loads in the issue from the filing system"""
        if not reload and self.isLoaded:
            return
        with codecs.open(os.path.join(self.dirpath, "values"), 'r', self.encoding) as ih:
            values=yaml.safe_load(ih)
            assert isinstance(values, dict)
        notloaded=self._load_mostly(values)
        if len(notloaded)>0:
            log.warn("The following values from issue '"+self.dirpath+"' were not recognised: "+repr(notloaded))
        self.isLoaded=True
        self.isDirty=False
        if self.tracksStaleness:
            self.stat=self.__getStat()


class BEDirParser(ParserBase):
    """Parses a filing system based BE repo"""
    uuid_match=re.compile("[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}")

    def __init__(self, uri, encoding="utf-8", cache_in_memory=False, precache_in_memory=False):
        ParserBase.__init__(self, uri)
        self.version=""         # This repo's version string
        self.encoding=encoding  # How to treat text files in this repo
        self.cache_in_memory=cache_in_memory or precache_in_memory
        self.precache_in_memory=precache_in_memory
        self.__bedir={}         # Dictionary of bug directories in repo

    def try_location(self):
        path=self._pathFromURI()
        if path is None or not os.path.exists(path) or not os.path.exists(os.path.join(path, ".be")):
            return (-999, "'"+path+"' is not a BE directory")
        path=os.path.join(path, ".be")
        if not os.path.exists(os.path.join(path, "version")):
            return (-998, "Missing version file")
        # Does the directory have a supported version format?
        with open(os.path.join(path, "version"), "r") as ih:
            self.version=ih.read()
        if self.version!="Bugs Everywhere Directory v1.4\n":
            return (-997, "Unsupported BE repo version")
        # Does the directory have a reasonable structure?
        items=filter(self.uuid_match.match, os.listdir(path))
        if len(items)==0:
            return (-996, "Can't find a uuid bug directory")
        return (1, None)

    def __loadIssueAndComments(self, bug, bugspath):
        """Adds an unloaded issue and comments"""
        self.__bedir[bugspath][bug]=bugitem=BEDirIssue(os.path.join(bugspath, bug), self.encoding)
        commentspath=os.path.join(bugspath, bug, "comments")
        if os.path.exists(commentspath):
            comments=filter(self.uuid_match.match, os.listdir(commentspath))
            for comment in comments:
                bugitem.addComment(os.path.join(commentspath, comment))
        return bugitem
        
    def reload(self):
        """Loads a BE directory structure into memory"""
        if self.version=="":
            assert self.try_location()[0]>0
        path=os.path.join(self._pathFromURI(), ".be")
        items=filter(self.uuid_match.match, os.listdir(path))
        self.__bedir={}
        for item in items:
            bugspath=os.path.join(path, item, "bugs")
            if os.path.exists(bugspath):
                self.__bedir[bugspath]={}
                bugs=filter(self.uuid_match.match, os.listdir(bugspath))
                for bug in bugs:
                    self.__loadIssueAndComments(bug, bugspath)
        if self.precache_in_memory:
            for issue in self.parse():
                for commentuuid in issue.comments:
                    issue.comments[commentuuid].uuid

    def parseIssues(self, issuefilter=None):
        if len(self.__bedir)==0:
            self.reload()
        for bugdir in self.__bedir:
            issueuuids=self.__bedir[bugdir]
            for issueuuid in issueuuids:
                issue=issueuuids[issueuuid]
                # Refresh if loaded and stale
                if issue.isLoaded and issue.tracksStaleness and issue.isStale:
                    issue.load(True)
                if issuefilter is None or issue._match(issuefilter):
                    yield issue
                if not self.cache_in_memory:
                    # Replace with a fresh structure. If the caller took
                    # a copy of the issue, it'll live on, otherwise it'll
                    # get GCed
                    self.__loadIssueAndComments(issueuuid, os.path.dirname(issue.dirpath))

    def parseComments(self, issue_uuid, commentfilter=None):
        if not isinstance(issue_uuid, str):
            issue_uuid=str(issue_uuid)
        if len(self.__bedir)==0:
            self.reload()
        issue=None
        for bugdir in self.__bedir:
            issueuuids=self.__bedir[bugdir]
            if issue_uuid in issueuuids:
                issue=issueuuids[issue_uuid]
                break
        if issue is None:
            raise AssertionError, "Issue uuid '"+str(issue_uuid)+"' not found"
        for commentuuid in issue.comments:
            yield issue.comments[commentuuid]

def instantiate(uri, **args):
    return BEDirParser(uri, **args)
