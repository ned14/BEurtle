# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from abc import ABCMeta, abstractmethod, abstractproperty
import urlparse, os, logging

log=logging.getLogger(__name__)

class ParserBase():
    """Abstract base class for parsers"""
    __metaclass__=ABCMeta

    def __init__(self, uri):
        up=urlparse.urlparse(uri)
        assert up.scheme is not ""
        if up.scheme.lower()=="file":
            up=(up.scheme.lower(), os.path.abspath(up.netloc).replace(os.sep, '/'), up.path, up.params, up.query, up.fragment)
            uri2=urlparse.urlunparse(up)
            if uri!=uri2:
                log.warn("Fixed up URI '"+uri+"' to '"+uri2+"'")
            uri=uri2
        self.uri=uri

    def _pathFromURI(self):
        """Returns a local filing system path from a URI"""
        # Windows can pass a drive letter through, unfortunately this causes urlparse to misparse
        up=urlparse.urlparse(self.uri)
        if up.scheme!="file":
            return None
        return (up.netloc+up.path) if up.netloc[-1]==':' else up.netloc

    @abstractmethod
    def try_location(self):
        """Returns (integer score, msg) for how much this parser likes the given uri"""
        pass

    @abstractmethod
    def reload(self):
        """Reloads any cached data."""
        pass

    @abstractmethod
    def parseIssues(self, issuefilter=None):
        """Coroutine parsing the issues at the uri filtering out anything not matching issuefilter"""
        pass

    @abstractmethod
    def parseComments(self, issue_uuid, commentfilter=None):
        """Coroutine parsing the comments for issue_uuid filtering out anything not matching commentfilter"""
        pass
