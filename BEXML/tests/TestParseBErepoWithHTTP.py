#!/usr/bin/env python
# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012
#
# Deliberately written to compile in IronPython and PyPy

import sys
if sys.path[0]!='.': sys.path.insert(0, '.')
from bexmlsrv import app
import logging, time, unittest, omnijson as json, urllib

class TestParseBErepoWithLib(unittest.TestCase):
    def setUp(self):
        logging.basicConfig(level=logging.WARN)
        start=time.time()
        end=time.time()
        self.emptyloop=end-start
        self.cookies={}

    def request(self, api, pars=None):
        req=api+('?'+urllib.urlencode(pars) if pars is not None else "")
        headers={'Accept' : 'application/json'}
        if len(self.cookies):
            cookie=""
            for key in self.cookies:
                if cookie!="": cookie+='; '
                cookie+=key+'='+self.cookies[key]
            headers['Cookie']= cookie
        response=app.request(req, headers=headers)
        self.assertEqual(response.status, "200 OK", "API call to '"+req+"' failed, response was "+repr(response))
        if 'Set-Cookie' in response.headers:
            cookie=response.headers['Set-Cookie']
            key, sep, value=cookie.partition('=')
            if ';' in value: value=value[:value.find(';')]
            self.cookies[key]=value
        data=json.loads(response.data)
        return (data, response)

    def test(self):
        print "API list is", self.request("/apilist")[0]

        self.request("/open", { 'uri' : "file://tests/bugs.bugseverywhere.org"})

        print("\nIssues in the bugs everywhere repository:")
        start=time.time()
        self.request("/reload")
        end=time.time()
        print("Loading the bugs everywhere repository took %f secs" % (end-start-self.emptyloop))

        start=time.time()
        issues=comments=0
        while True:
            data=self.request("/parseIssues")[0]
            issue=data['result']
            if issue is None: break
            issues+=1
            #print "  "+issue['uuid']+": "+issue['summary']
            while True:
                data=self.request("/parseComments", {'issue_uuid': issue['uuid']})[0]
                comment=data['result']
                if comment is None: break
                comments+=1
        end=time.time()
        print("Reading %d issues and %d comments from the bugs everywhere repository for the first time took %f secs" % (issues, comments, end-start-self.emptyloop))

if __name__=="__main__":
    unittest.main()
    