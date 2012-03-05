#!/usr/bin/env python
# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012
#
# Deliberately written to compile in IronPython and PyPy

import sys
if sys.path[0]!='.': sys.path.insert(0, '.')
from libBEXML import BEXML
import logging, time, unittest

class TestParseBErepoWithLib(unittest.TestCase):
    def setUp(self):
        logging.basicConfig(level=logging.WARN)
        start=time.time()
        end=time.time()
        self.emptyloop=end-start

    def test(self):
        parser=BEXML("file://tests/bugs.bugseverywhere.org")
        print("Issues in the bugs everywhere repository:")
        start=time.time()
        parser.reload()
        end=time.time()
        print("Loading the bugs everywhere repository took %f secs" % (end-start-self.emptyloop))

        start=time.time()
        issues=comments=0
        for issue in parser.parseIssues():
            issues+=1
            issue.status
            #print "  "+str(issue.uuid)+": "+issue.summary
            for commentuuid in issue.comments:
                comments+=1
                issue.comments[commentuuid].alt_id
        end=time.time()
        print("Reading %d issues and %d comments from the bugs everywhere repository for the first time took %f secs" % (issues, comments, end-start-self.emptyloop))

        start=time.time()
        for issue in parser.parseIssues():
            issue.status
            for commentuuid in issue.comments:
                issue.comments[commentuuid].alt_id
        end=time.time()
        print("Reading the bugs everywhere repository for the second time took %f secs" % (end-start-self.emptyloop))

        print("\nIssues created by anyone called Steve:")
        start=time.time()
        n=0
        for issue in parser.parseIssues("{{creator}}:{{Steve}}"):
            n+=1
            #print "  "+str(issue.uuid)+": "+issue.summary
        end=time.time()
        print("Reading %d items from the bugs everywhere repository for the first time took %f secs" % (n, end-start-self.emptyloop))


if __name__=="__main__":
    unittest.main()
    