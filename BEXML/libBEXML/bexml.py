# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

import inspect, urlparse, logging, os
import parsers

log=logging.getLogger(__name__)

def BEXML(uri, storageparser=None, **args):
    """Initialises an issue tracking repository for use"""
    if storageparser is None:
        parser_instances=[parser_module[1].instantiate(uri, **args) for parser_module in inspect.getmembers(parsers, inspect.ismodule)]
        parser_scores=[(instance.try_location(), instance) for instance in parser_instances]
        parser_scores.sort()
        score=parser_scores[len(parser_scores)-1][0]
        storageparser=parser_scores[len(parser_scores)-1][1]
    else:
        storageparser=storageparser(uri, **args)
        score=storageparser.try_location()
    if score[0]<0:
        raise Exception, "No storage parser matched the uri '"+uri+"'. The best matching ("+str(storageparser)+" reported: "+score[1]
    return storageparser
