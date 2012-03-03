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
	console=['bexmlcgi.py'],
    version="0.01",
    description='Provides fast, lazy, RESTful access to various issue (bug) trackers. Compilable into a fast binary with IronPython and PyPy for even faster access.',
    author='Niall Douglas',
    url='http://www.nedprod.com/programs/portable/bexml',
    packages=find_packages('libBEXML'),
    test_suite='tests',
    install_requires=['pyyaml', 'webpy'],
    )
