# BEXML, a fast Bugs Everywhere parser with RESTful API and other issue tracker backends
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from libBEXML import BEXML, parserbase
import web, urlparse, os, inspect, logging, sys, traceback
import omnijson as json
from mimerender import mimerender
from cgi import escape

DEBUG=True

web.config.debug = False
web.config.session_parameters['timeout'] = 5*60     # 5 minutes, then expire the session
logging.basicConfig(level=logging.WARN)
log=logging.getLogger(__name__)

parserAPIs=dict([x for x in inspect.getmembers(parserbase.ParserBase, inspect.ismethod) if x[0][0]!='_'])
log.info("APIs found on ParserBase are: "+repr(parserAPIs))

def inspect_parameters(routine):
    return [x for x in inspect.getargspec(routine).args if x is not 'self']

def inspect_apis(routines):
    ret={}
    for routine in routines:
        ret[routine]=inspect_parameters(routines[routine])
    return ret


def XMLise(v, indent=0):
    ret=""
    for k in v:
        x=v[k]
        ret+=u''.rjust(indent)
        ret+=u'<'+unicode(k)+u'>'
        if isinstance(x, dict):
            ret+=u'\n'
            ret+=XMLise(x, indent+3)
            ret+=u''.rjust(indent)
        elif isinstance(x, list):
            ret+=u'\n'
            for i in x:
                ret+=u''.rjust(indent+3)
                ret+=unicode(i)
                ret+=',\n'
            ret+=u''.rjust(indent)
        else:
            ret+=unicode(x)
        ret+=u'</'+unicode(k)+u'>\n'
    return ret

render_xml = lambda **args: XMLise(args)
render_json = lambda **args: json.dumps(args)
render_html = lambda **args: u'<html><body><pre>%s</pre></body></html>'%escape(XMLise(args))
render_txt = lambda **args: repr(args)

urls = (
    '/', 'index',
    '/apilist', 'apilist',
    '/open(.*)', 'open',
    '/parser/(.+)', 'parser'
)
app = web.application(urls, locals())
session = web.session.Session(app, web.session.DiskStore('bexmlsrv_sessions'), initializer={'uri': None})
sessionToParserInfo = {}
class ParserInfo:
    """Keeps session to parser info"""
    def __init__(self, session, uri, parser):
        self.session=session
        self.uri=uri
        self.parser=parser

def excfilter(func):
    def dec(*args, **kwargs):
        try:
            return func(*args, **kwargs)
        except AssertionError, e:
            raise web.HTTPError('400 Bad Request', {'Content-Type': 'text/plain'}, 'Error: '+e.message+('\n\n'+traceback.format_exc() if DEBUG else ''))
        except Exception, e:
            raise web.HTTPError('500 Internal Error', {'Content-Type': 'text/plain'}, 'Error: '+e.message+('\n\n'+traceback.format_exc() if DEBUG else ''))
    return dec

class index:
    @mimerender(
        default = 'html',
        html = render_html,
        xml  = render_xml,
        json = render_json,
        txt  = render_txt
    )
    @excfilter
    def GET(self):
        return {"result" : "Call /apilist for a list of APIs you can call"}

class apilist:
    @mimerender(
        default = 'html',
        html = render_html,
        xml  = render_xml,
        json = render_json,
        txt  = render_txt
    )
    @excfilter
    def GET(self):
        ret={'result': { 'open' : inspect_parameters(BEXML),
                           'parser' : inspect_apis(parserAPIs)
                          } }
        return ret

class open:
    @mimerender(
        default = 'html',
        html = render_html,
        xml  = render_xml,
        json = render_json,
        txt  = render_txt
    )
    @excfilter
    def GET(self):
        query=urlparse.parse_qs(web.ctx.env['QUERY_STRING'])
        if 'uri' not in query:
            raise AssertionError, "Need the uri parameter"
        uri=query['uri'][0]
        # If it's a file uri, make sure it's in the current working directory and it exists
        up=urlparse.urlparse(uri)
        if up.scheme.lower() not in ['file', 'http', 'https']:
            raise AssertionError, "Uri '"+up.scheme+"' scheme needs to be one of file, http, https"
        if up.scheme.lower()=='file':
            if up.netloc[0]=='/' or up.netloc[0]=='\\':
                raise AssertionError, "Cannot use absolute paths for file access: "+up.netloc
            if not os.path.exists(up.netloc):
                raise AssertionError, "Path '"+up.netloc+"' not found under the current working directory"
        session.uri=uri
        sessionToParserInfo[session.session_id]=ParserInfo(session, uri, BEXML(session.uri))
        return {'result': 'OK'}

class parser:
    @mimerender(
        default = 'html',
        html = render_html,
        xml  = render_xml,
        json = render_json,
        txt  = render_txt
    )
    @excfilter
    def GET(self, api):
        query=urlparse.parse_qs(web.ctx.env['QUERY_STRING'])
        if session.uri is None:
            raise AssertionError, "Need to call /open to open a parsing session first"
        if api not in parserAPIs:
            raise AssertionError, "API '"+api+"' not in allowed APIs: "+repr(parserAPIs)
        reloaded=False
        if session.session_id in sessionToParserInfo:
            pi=sessionToParserInfo[session.session_id]
        else:
            sessionToParserInfo[session.session_id]=pi=ParserInfo(session, uri, BEXML(session.uri))
            reloaded=True
        method=parserAPIs[api].__get__(pi.parser, type(pi.parser))
        methodspec=inspect.getargspec(method)
        mandpars=[x for x in methodspec.args if x is not 'self']
        if methodspec.defaults is not None:
            mandpars=mandpars[:-len(methodspec.defaults)]
        for parameter in mandpars:
            if parameter not in query:
                raise AssertionError, "Mandatory parameter '"+parameter+"' is missing"
        return {'reloaded' : reloaded, 'result': method(**query)}

if __name__ == "__main__":
    app.run()
