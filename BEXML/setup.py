#!/usr/bin/env python

from distribute_setup import use_setuptools
use_setuptools()

from setuptools import setup, find_packages
import os.path
try:
    import py2exe
except:
    py2exe=None

setup(
    name='BEXML',
	console=['bexmlsrv.py'],
    version="0.01",
    description='Provides fast, lazy, RESTful fastcgi access to various issue (bug) trackers. Compilable into a fast binary with IronPython and PyPy for even faster access.',
    author='Niall Douglas',
    url='http://www.nedprod.com/programs/portable/bexml',
    packages=find_packages(),
    test_suite='tests',
    install_requires=['automodinit', 'pyyaml', 'omnijson', 'ujson', 'web.py', 'mimerender'],
    )
