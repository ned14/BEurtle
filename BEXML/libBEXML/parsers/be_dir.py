# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from ..parserbase import ParserBase
from ..issue import Issue as IssueBase
from ..comment import Comment as CommentBase

import urllib2, os, re, codecs, logging
from urlparse import urlparse
from collections import namedtuple
import yaml

log=logging.getLogger(__name__)


class BEDirComment(CommentBase):
    """A comment loaded from a filing system based BE repo"""

    def __init__(self, parentIssue, dirpath, encoding):
        CommentBase.__init__(self, parentIssue)
        self.dirpath=dirpath
        self.encoding=encoding
        self.__loaded=True
        self.uuid=os.path.basename(dirpath)
        self.__loaded=False
        self.stat=None

    @property
    def isLoaded(self):
        """True if comment has been loaded from filing system"""
        return self.__loaded
    @isLoaded.setter
    def isLoaded(self, value):
        self.__loaded=value

    def __getStat(self):
        """Returns the stat for the file backing of this comment"""
        stat=namedtuple('CommentStat', ['values', 'body'])
        stat.values=os.stat(os.path.join(self.dirpath, "values"))
        stat.body=os.stat(os.path.join(self.dirpath, "body"))
        return stat

    @property
    def isStale(self):
        """True if the file backing for this comment is newer than us"""
        if not self.__loaded:
            return None
        stat=self.__getStat()
        return stat.values!=self.stat.values

    def load(self, reload=False):
        """Loads in the comment from the filing system"""
        if not reload and self.__loaded:
            return
        with codecs.open(os.path.join(self.dirpath, "values"), 'r', self.encoding) as ih:
            values=yaml.safe_load(ih)
            assert isinstance(values, dict)
        with codecs.open(os.path.join(self.dirpath, "body"), 'r', self.encoding) as ih:
            values['body']=ih.read()
        notloaded=self._load_mostly(values)
        if len(notloaded)>0:
            log.warn("The following values from comment '"+self.dirpath+"' were not recognised: "+repr(notloaded))
        self.__loaded=True
        self._dirty=False
        self.stat=self.__getStat()

    def __getitem__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__getitem__(self, name)
    def __getattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__getattr__(self, name)

    def __setitem__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__setitem__(self, name, value)
    def __setattr__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__setattr__(self, name, value)

    def __delitem__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__delitem__(self, name)
    def __delattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return CommentBase.__delattr__(self, name)

class BEDirIssue(IssueBase):
    """An issue loaded from a filing system based BE repo"""

    def __init__(self, dirpath, encoding):
        IssueBase.__init__(self)
        self.dirpath=dirpath
        self.encoding=encoding
        self.__loaded=True
        self.uuid=os.path.basename(dirpath)
        self.__loaded=False
        self.stat=None

    @property
    def isLoaded(self):
        """True if issue has been loaded from filing system"""
        return self.__loaded

    def __getStat(self):
        """Returns the stat for the file backing of this issue"""
        stat=namedtuple('IssueStat', ['values'])
        stat.values=os.stat(os.path.join(self.dirpath, "values"))
        return stat

    @property
    def isStale(self):
        """True if the file backing for this issue is newer than us"""
        if not self.__loaded:
            return None
        stat=self.__getStat()
        return stat.values!=self.stat.values

    def addComment(self, dirpath):
        """Adds a comment to the issue"""
        temp1=self.__loaded
        comment=BEDirComment(self, dirpath, self.encoding)
        try:
            self.__loaded=True
            comment.isLoaded=True
            return IssueBase.addComment(self, comment)
        finally:
            comment.isLoaded=False
            self.__loaded=temp1

    def removeComment(self, comment):
        temp=self.__loaded
        try:
            self.__loaded=True
            return IssueBase.removeComment(self, comment)
        finally:
            self.__loaded=temp

    def load(self, reload=False):
        """Loads in the issue from the filing system"""
        if not reload and self.__loaded:
            return
        with codecs.open(os.path.join(self.dirpath, "values"), 'r', self.encoding) as ih:
            values=yaml.safe_load(ih)
            assert isinstance(values, dict)
        notloaded=self._load_mostly(values)
        if len(notloaded)>0:
            log.warn("The following values from issue '"+self.dirpath+"' were not recognised: "+repr(notloaded))
        self.__loaded=True
        self._dirty=False
        self.stat=self.__getStat()

    def __getitem__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__getitem__(self, name)
    def __getattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__getattr__(self, name)

    def __setitem__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__setitem__(self, name, value)
    def __setattr__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__setattr__(self, name, value)

    def __delitem__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__delitem__(self, name)
    def __delattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return IssueBase.__delattr__(self, name)


class BEDirParser(ParserBase):
    """Parses a filing system based BE repo"""
    uuid_match=re.compile("[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}")

    def __init__(self, uri, encoding="UTF-8", cache_in_memory=True):
        ParserBase.__init__(self, uri)
        self.version=""         # This repo's version string
        self.encoding=encoding  # How to treat text files in this repo
        self.__bedir={}         # Dictionary of bug directories in repo
        if not cache_in_memory:
            log.warn("cache_in_memory=False not supported and therefore ignored")

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
                self.__bedir[bugspath]=bugsdict={}
                bugs=filter(self.uuid_match.match, os.listdir(bugspath))
                for bug in bugs:
                    bugsdict[bug]=bugitem=BEDirIssue(os.path.join(bugspath, bug), self.encoding)
                    commentspath=os.path.join(bugspath, bug, "comments")
                    if os.path.exists(commentspath):
                        comments=filter(self.uuid_match.match, os.listdir(commentspath))
                        for comment in comments:
                            bugitem.addComment(os.path.join(commentspath, comment))

    def parse(self, issuefilter=None):
        if len(self.__bedir)==0:
            self.reload()
        for bugdir in self.__bedir:
            issueuuids=self.__bedir[bugdir]
            for issueuuid in issueuuids:
                issue=issueuuids[issueuuid]
                # Refresh if loaded and stale
                if issue.isLoaded and issue.isStale:
                    issue.load(True)
                if issuefilter is None:
                    yield issue
                else:
                    if issuefilter.match(issue):
                        yield issue

def instantiate(uri, **args):
    return BEDirParser(uri, **args)
