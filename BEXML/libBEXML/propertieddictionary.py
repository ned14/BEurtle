# PropertiedDictionary. Basically a more nimble way of doing python properties
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

from collections import namedtuple

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


if __name__=="__main__":
    import doctest
    doctest.testmod()
