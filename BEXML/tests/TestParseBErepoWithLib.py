#!/usr/bin/env python
# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012
#
# Deliberately written to compile in IronPython and PyPy

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
        for issue in parser.parse():
            for commentuuid in issue.comments:
                issue.comments[commentuuid].uuid
                pass
        end=time.time()
        print("Reading the bugs everywhere repository for the first time took %f secs" % (end-start-self.emptyloop))

        start=time.time()
        for issue in parser.parse():
            for commentuuid in issue.comments:
                issue.comments[commentuuid].uuid
                pass
        end=time.time()
        print("Reading the bugs everywhere repository for the second time took %f secs" % (end-start-self.emptyloop))
        #for issue in parser.parse():
        #    print("   %s: %s" % (issue.uuid, issue.summary))

if __name__=="__main__":
    unittest.main()
    