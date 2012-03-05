# PropertiedDictionary. Basically a more nimble way of doing python properties
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from collections import namedtuple
import re

class Property:
    """A property in a propertied dictionary"""

    def __init__(self, name, docstring, coercer, default):
        self.name=name
        self.docstring=docstring
        self.coercer=coercer if coercer is not None else self.__throwReadOnlyException
        self.default=default
        self.reset()

    def __throwReadOnlyException(self, x):
        raise AttributeError, "Property is read-only"

    def reset(self):
        coercer=self.coercer if self.coercer!=self.__throwReadOnlyException else lambda x: x
        self.value=coercer(self.default)

    def __doc__(self):
        return self.docstring

    def __repr__(self):
        ret=repr(self.value)
        if self.coercer==self.__throwReadOnlyException:
            ret="RO "+ret
        if self.default is not None:
            ret=repr(type(self.default))+" "+ret
        return ret

class PropertiedDictionary(dict, object):
    """A strongly typed propertied object which doubles as a dictionary.
    Lets you control access to dictionary items and force typing of storage.
    Note that when accessed as a property, '-' get flattened to '_'.
    This lets you access x["key-ness"] as x.key_ness.

    A read-only property: x._addProperty("foo", default="value")
    An untyped property:  x._addProperty("foo", coercer=lambda x: x)
    
    >>> x=PropertiedDictionary()
    >>> print x
    PropertiedDictionary: {}
    >>> x._addProperty("foo", "I'm a foo", int, 5)
    >>> print x
    PropertiedDictionary: {'foo': <type 'int'> 5}
    >>> x.foo=6
    >>> print x
    PropertiedDictionary: {'foo': <type 'int'> 6}
    >>> x.g=6
    >>> print x
    PropertiedDictionary: {'foo': <type 'int'> 6}
    >>> x.foo="8"
    >>> print x
    PropertiedDictionary: {'foo': <type 'int'> 8}
    >>> x.foo="Niall"
    Traceback (most recent call last):
        ...
    ValueError: invalid literal for int() with base 10: 'Niall'
    >>> del x.foo
    >>> print x
    PropertiedDictionary: {'foo': <type 'int'> 5}
    >>> x._removeProperty("foo")
    >>> print x
    PropertiedDictionary: {}
    >>> x._addProperty("reply-to", default="I am read only")
    >>> print x
    PropertiedDictionary: {'reply-to': <type 'str'> RO 'I am read only'}
    >>> x.reply_to="Niall"
    Traceback (most recent call last):
        ...
    AttributeError: Property is read-only
    >>> x._removeProperty("reply-to")
    >>> print x
    PropertiedDictionary: {}
    >>> x._addProperty("reply-to", coercer=lambda x: x)
    >>> print x
    PropertiedDictionary: {'reply-to': None}
    >>> x.reply_to="Niall"
    >>> print x
    PropertiedDictionary: {'reply-to': 'Niall'}
    >>> x._addProperty("foo", "I'm a foo", int, 5)
    >>> x._reset()
    >>> print x
    PropertiedDictionary: {'reply-to': None, 'foo': <type 'int'> 5}
    >>> x._load(foo="3", reply_to="Not me!")
    >>> print x
    PropertiedDictionary: {'reply-to': 'Not me!', 'foo': <type 'int'> 3}
    >>> print x._load_mostly({'foo': "88", 'reply_to':"Hello", 'boo':43})
    {'boo': 43}
    >>> print x
    PropertiedDictionary: {'reply-to': 'Hello', 'foo': <type 'int'> 88}
    >>> del x
    >>> class Foo(PropertiedDictionary):
    ...     def __init__(self):
    ...         PropertiedDictionary.__init__(self)
    ...         self.boo="hello"
    ...         self._addProperty("coo")
    >>> x=Foo()
    >>> print x.boo
    hello
    >>> print x.coo
    None
    """
    
    def __init__(self):
        dict.__init__(self)
        object.__init__(self)

    def __lookup(self, key, flatten=False):
        key=key.lower()
        has=dict.has_key(self, key)
        if has or not flatten:
            return dict.__getitem__(self, key) if has else None
        key=key.replace('_', '-')
        has=dict.has_key(self, key)
        return dict.__getitem__(self, key) if has else None


    def _addProperty(self, name, docstring=None, coercer=None, default=None):
        """Declares a property with optional type coercer and optional default value.
        The type of default strongly sets the type of this property."""
        name=name.lower()
        if dict.has_key(self, name):
            raise AttributeError, "Already have property "+name
        p=Property(name, docstring, coercer, default)
        dict.__setitem__(self, name, p)

    def _removeProperty(self, name):
        """Removes a property"""
        name=name.lower()
        dict.__delitem__(self, name)

    def _isProperty(self, name):
        """True if name is a property"""
        p=self.__lookup(name)
        return p is not None

    def _reset(self):
        """Resets all properties to their default values"""
        for key in self:
            self.__lookup(key).reset()

    def _load(self, *entries, **args):
        """Loads in a set of values from arguments or a dictionary, throwing an exception if a property is unknown"""
        if len(entries)==0 and len(args)==0: return
        for entry in entries:
            assert isinstance(entry, dict)
            args.update(entry)
        for key in args:
            mkey=key.replace('_', '-')
            p=self.__lookup(mkey)
            if p is None:
                raise KeyError, "Property "+key+" not present in this dictionary"
            p.value=p.coercer(args[key])

    def _load_mostly(self, *entries, **args):
        """Loads in a set of values from arguments or a dictionary, returning those not loaded"""
        if len(entries)==0 and len(args)==0: return
        for entry in entries:
            assert isinstance(entry, dict)
            args.update(entry)
        ret={}
        for key in args:
            mkey=key.replace('_', '-')
            p=self.__lookup(mkey)
            if p is None:
                ret[key]=args[key]
            else:
                p.value=p.coercer(args[key])
        return ret

    def __repr__(self):
        return "PropertiedDictionary: "+dict.__repr__(self)

    def __getitem__(self, name):
        p=self.__lookup(name)
        if p is None:
            raise KeyError, "Key '"+name+"' not found"
        return p.value
    def __getattr__(self, name):
        p=self.__lookup(name, True)
        if p is not None:
            return p.value
        return object.__getattribute__(self, name)

    def __setitem__(self, name, value):
        p=self.__lookup(name)
        if p is None:
            raise KeyError, "Key '"+name+"' not found"
        p.value=p.coercer(value)
    def __setattr__(self, name, value):
        p=self.__lookup(name, True)
        if p is not None:
            p.value=p.coercer(value)
        else:
            return object.__setattr__(self, name, value)

    def __delitem__(self, name):
        """Doesn't delete, but resets to default"""
        p=self.__lookup(name)
        if p is None:
            raise KeyError, "Key '"+name+"' not found"
        p.reset()
    def __delattr__(self, name):
        """Doesn't delete, but resets to default"""
        p=self.__lookup(name, True)
        if p is not None:
            p.reset()
        else:
            return object.__delattr__(self, name)

    def _match(self, filterstring):
        """Returns true if the filterstring matches this item. Filter string looks like this:

        [+]{{regexp fieldname}}:{{regexp contents}},[+]{{regexp fieldname}}:{{regexp contents}}...

        The optional preceding + operator makes matching the fieldname compulsory. Otherwise True
        will be returned if any fieldname matches.

        It also handles plain strings, in which case it matches any value.

        >>> x=PropertiedDictionary()
        >>> x._addProperty("name", "", str, "")
        >>> x._addProperty("phone", "", str, "")
        >>> x._addProperty("room", "", int, 0)
        >>> x.name="Niall Douglas"
        >>> x.phone="4964925"
        >>> x.room=53
        >>> print x._match("{{name}}:{{niall}},{{.*o.*}}:{{5}}")
        True
        >>> print x._match("+{{name}}:{{niall}},{{.*o.*}}:{{5}}")
        False
        >>> print x._match("+{{name}}{{niall}},{{.*o.*}}:{{5}}")
        Traceback (most recent call last):
            ...
        ValueError: Filter string '+{{name}}{{niall}},{{.*o.*}}:{{5}}' has incorrect format at around index 9 'name}}{{nial'
        >>> print x._match("+{{name}}:{{niall}},{{.*o.*}}:{{5}")
        Traceback (most recent call last):
            ...
        ValueError: Filter string '+{{name}}:{{niall}},{{.*o.*}}:{{5}' has incorrect format at around index 30 'o.*}}:{{5}'
        >>> print x._match("+:,")
        Traceback (most recent call last):
            ...
        ValueError: Filter string '+:,' has incorrect format at around index 3 '+:,'
        >>> print x._match(",:")
        Traceback (most recent call last):
            ...
        ValueError: Filter string ',:' has incorrect format at around index 2 ',:'
        >>> print x._match("Niall")
        True
        >>> print x._match("niall")
        False
        """
        assert isinstance(filterstring, str), "Filter string '"+repr(filterstring)+"' is not a string"
        if len(filterstring)==0: return False
        # Break up into bits first ..
        filters=[]
        class Filter:
            def __init__(self):
                self.required=False
                self.property=""
                self.value=""
                self.matched=False
            def __repr__(self):
                return repr(namedtuple("Filter", ["required", "property", "value", "matched"])(self.required, self.property, self.value, self.matched))
        infield=0
        lastbreak=0
        seenPunct=True
        f=Filter()
        for i in xrange(0, len(filterstring)):
            #print infield, filterstring[i:]
            if filterstring[i:i+2]=='{{':
                if infield==0 and not seenPunct:
                    raise ValueError, "Filter string '"+filterstring+"' has incorrect format at around index "+str(i)+" '"+filterstring[i-6:i+6]+"'"
                infield+=1
            elif filterstring[i:i+2]=='}}':
                infield-=1
                seenPunct=False
            elif infield==0:
                if filterstring[i]=='+':
                    f.required=True
                    lastbreak=i+1
                    seenPunct=True
                elif filterstring[i]==':':
                    f.property=filterstring[lastbreak+2:i-2].strip()
                    lastbreak=i+1
                    seenPunct=True
                elif filterstring[i]==',' or i==len(filterstring)-1:
                    if filterstring[i]!=',': i+=1
                    f.value=filterstring[lastbreak:i].strip('\t\n\x0b\x0c\r {}')
                    #print "Parsed", f
                    filters.append(f)
                    f=Filter()
                    lastbreak=i+1
                    seenPunct=True
        if lastbreak!=len(filterstring)+1: raise ValueError, "Filter string '"+filterstring+"' has incorrect format at around index "+str(lastbreak)+" '"+filterstring[lastbreak-6:]+"'"
        if len(filters)==0: raise ValueError, "Filter string '"+filterstring+"' could not be parsed!"
        for f in filters:
            #print f
            f.property=re.compile(f.property)
            f.value=re.compile(f.value)
        for key in self:
            value=unicode(self[key])
            for f in filters:
                f.matched=f.matched or (f.property.match(key) and f.value.search(value))
        matchedAnything=False
        for f in filters:
            if f.required and not f.matched:
                return False
            if f.matched:
                matchedAnything=True
        return matchedAnything


if __name__=="__main__":
    import doctest
    doctest.testmod()
