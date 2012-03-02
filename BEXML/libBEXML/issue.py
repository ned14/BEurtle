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

import re
from uuid import UUID
from datetime import datetime

from propertieddictionary import PropertiedDictionary
from comment import Comment
from coerce_datetime import coerce_datetime

class Issue(PropertiedDictionary):
    """Base class for issues"""
    severities=["target",
            "wishlist",
            "minor",
            "serious",
            "critical",
            "fatal"]
    statuses=["unconfirmed",
            "open",
            "assigned",
            "test",
            "closed",
            "fixed",
            "wontfix"]
    nullUUID=UUID(int=0)
    nullDatetime=datetime.fromordinal(1)

    def __init__(self, *entries, **args):
        PropertiedDictionary.__init__(self)
        self.__dirty=False
        self._addProperty("uuid", "The uuid of the issue", lambda x: x if isinstance(x, UUID) else UUID(x), self.nullUUID)
        self._addProperty("short-name", "The short name of the issue", str, "")
        self._addProperty("severity", "The severity of the issue", self.__coerce_severity, "")
        self._addProperty("status", "The status of the issue", self.__coerce_status, "")
        self._addProperty("reporter", "The reporter of the issue", unicode, u"")
        self._addProperty("creator", "The creator of the issue", unicode, u"")
        self._addProperty("assigned", "The person assigned to the issue", unicode, u"")
        self._addProperty("time", "When this issue was created", coerce_datetime, self.nullDatetime)
        self._addProperty("extra-strings", "Additional tags on the issue", str, "")
        self._addProperty("summary", "Summary of the issue", unicode, u"")
        self.comments={}
        self._load(*entries, **args)

    def __coerce_severity(self, v):
        v=str(v)
        assert v=="" or v in self.severities
        return v

    def __coerce_status(self, v):
        v=str(v)
        assert v=="" or v in self.statuses
        return v

    @property
    def isDirty(self, includeChildren=False):
        """True if this comment has been modified and needs writing to disk"""
        return self.__dirty

    def match(self, issuefilter):
        """Returns true if this issue matches issuefilter"""
        if issuefilter.uuid!=nullUUID:
            if not re.match(str(issuefilter.uuid), str(self.uuid)): return False
        if issuefilter.short_name!="":
            if not re.search(issuefilter.short_name, self.short_name): return False
        if issuefilter.severity!="":
            if not re.search(issuefilter.severity, self.severity): return False
        if issuefilter.status!="":
            if not re.search(issuefilter.status, self.status): return False
        if issuefilter.reporter!="":
            if not re.search(issuefilter.reporter, self.reporter): return False
        if issuefilter.creator!="":
            if not re.search(issuefilter.creator, self.creator): return False
        if issuefilter.created!=nullDatetime:
            if not re.search(str(issuefilter.created), str(self.created)): return False
        if issuefilter.summary!="":
            if not re.search(issuefilter.summary, self.summary): return False
        return True

    def addComment(self, comment):
        """Adds a comment to the issue"""
        assert isinstance(comment, Comment)
        self.comments[comment.uuid]=comment
        return comment

    def removeComment(self, comment):
        """Removes a comment from the issue"""
        if isinstance(comment, str):
            comment=UUID(comment)
        if isinstance(comment, UUID):
            del self.comments[comment]
        elif isinstance(comment, Comment):
            del self.comments[comment.uuid]
        else:
            raise LookupError, "comment is not a string, uuid or comment"

if __name__=="__main__":
    import doctest
    doctest.testmod()
