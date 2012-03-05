# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012
#
# Deliberately written to compile in IronPython and PyPy

import unittest, doctest
import libBEXML

def load_tests(loader, tests, ignore):
    for module in libBEXML.__all__:
        try:
            tests.addTests(doctest.DocTestSuite(libBEXML.__dict__[module], test_finder=doctest.DocTestFinder(verbose=True)))
        except Exception, e:
            pass
    return tests

