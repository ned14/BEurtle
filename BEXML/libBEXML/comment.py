# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

"""
<bug>
  <uuid>12c986be-d19a-4b8b-b1b5-68248ff4d331</uuid>
  <short-name>bea/12c</short-name>
  <severity>wishlist</severity>
  <status>unconfirmed</status>
  <reporter>Ronny Pfannschmidt &lt;Ronny.Pfannschmidt@gmx.de&gt;</reporter>
  <creator>W. Trevor King &lt;wking@drexel.edu&gt;</creator>
  <created>Tue, 21 Jul 2009 18:32:12 +0000</created>
  <summary>Bug aggregation.  Multi-repo meta-BE?</summary>
  <comment>
    <uuid>88d1f2c2-e1af-4f0d-9390-e3c89ae4f7d7</uuid>
    <alt-id>&lt;1247313294.7701.60.camel@localhost&gt;</alt-id>
    <short-name>bea/12c/88d</short-name>
    <author>Ronny Pfannschmidt &lt;Ronny.Pfannschmidt@gmx.de&gt;</author>
    <date>Sat, 11 Jul 2009 13:54:54 +0200</date>
    <content-type>text/plain</content-type>
    <body></body>
  </comment>
    <comment>
      <uuid>1f9f60de-ba37-42bc-a1c0-dc062ef255e1</uuid>
      <alt-id>&lt;878wivmjm1.fsf@benfinney.id.au&gt;</alt-id>
      <short-name>bea/12c/1f9</short-name>
      <in-reply-to>88d1f2c2-e1af-4f0d-9390-e3c89ae4f7d7</in-reply-to>
      <author>Ben Finney &lt;bignose+hates-spam@benfinney.id.au&gt;</author>
      <date>Sat, 11 Jul 2009 23:31:34 +1000</date>
      <content-type>text/plain</content-type>
      <body></body>
    </comment>
</bug>
"""

from propertieddictionary import PropertiedDictionary
from coerce_datetime import coerce_datetime

from abc import ABCMeta, abstractmethod, abstractproperty
from uuid import UUID
from datetime import datetime
import mimetypes

# Add missing MIME types
mimetypes.add_type("text/restructured", "rst", False)
mimetypes.add_type("text/rst", "rst2", False)
mimetypes.add_type("application/bat", "bat", False)

class Comment(PropertiedDictionary):
    """Base class for comments"""
    __metaclass__=ABCMeta
    mime_types=mimetypes.types_map.values()
    mime_types+=mimetypes.common_types.values()
    mime_types.sort()
    mime_types=set(mime_types)
    nullUUID=UUID(int=0)
    nullDatetime=datetime.fromordinal(1)

    def __init__(self, parentIssue, *entries, **args):
        PropertiedDictionary.__init__(self)
        self.__parent=parentIssue
        self.__loaded=False
        self.__dirty=False
        self.__trackStaleness=False
        self._addProperty("uuid", "The uuid of the comment", lambda x: x if isinstance(x, UUID) else UUID(x), self.nullUUID)
        self._addProperty("alt-id", "The alt-id of the comment", str, "")
        self._addProperty("short-name", "The short name of the comment", str, "")
        self._addProperty("in-reply-to", "The uuid of the comment to which this comment replies", lambda x: x if isinstance(x, UUID) else UUID(x), self.nullUUID)
        self._addProperty("author", "The author of the comment", unicode, u"")
        self._addProperty("date", "When this comment was made", coerce_datetime, self.nullDatetime)
        self._addProperty("content-type", "The content type of this comment", self.__coerce_content_type, "text/plain")
        self._addProperty("body", "The body of this comment", unicode, u"")
        self._load(*entries, **args)

    def __coerce_content_type(self, type):
        """Checks that a mime type is valid"""
        type=str(type)
        assert type in self.mime_types
        return type

    @property
    def parentIssue(self):
        """Returns the issue to which this comment belongs"""
        return self.__parent

    @property
    def isLoaded(self):
        """True if comment has been loaded from backing store"""
        return self.__loaded
    @isLoaded.setter
    def isLoaded(self, value):
        self.__loaded=value

    @property
    def isDirty(self):
        """True if this comment has been modified and needs writing to disk"""
        return self.__dirty
    @isDirty.setter
    def isDirty(self, value):
        self.__dirty=value

    @property
    def tracksStaleness(self):
        """True is staleness is tracked"""
        return self.__trackStaleness
    @tracksStaleness.setter
    def tracksStaleness(self, value):
        self.__trackStaleness=value
        
    @abstractproperty
    def isStale(self):
        """True if the file backing for this comment is newer than us"""
        pass

    @abstractmethod
    def load(self, reload=False):
        """Loads in the comment from the backing store"""
        pass

    def __getitem__(self, name):
        if self._isProperty(name) and not self.isLoaded and name is not 'uuid':
            self.load()
        return PropertiedDictionary.__getitem__(self, name)
    def __getattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return PropertiedDictionary.__getattr__(self, name)

    def __setitem__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return PropertiedDictionary.__setitem__(self, name, value)
    def __setattr__(self, name, value):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return PropertiedDictionary.__setattr__(self, name, value)

    def __delitem__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return PropertiedDictionary.__delitem__(self, name)
    def __delattr__(self, name):
        if self._isProperty(name) and not self.isLoaded:
            self.load()
        return PropertiedDictionary.__delattr__(self, name)

if __name__=="__main__":
    import doctest
    doctest.testmod()
