#!/usr/bin/env python
# CompileToStandalone, a Python to .NET ILR compiler which produces standalone binaries
# (C) 2012 Niall Douglas http://www.nedproductions.biz/
# Created: March 2012

import modulefinder, sys, os, subprocess, _winreg

if len(sys.argv)<2:
    print("Usage: CompileEverythingToILR.py <source py> [-outdir=<dest dir>]")
    sys.exit(0)

if sys.platform=="cli":
    print("ERROR: IronPython's ModuleFinder currently doesn't work, so run me under CPython please")
    sys.exit(1)

sourcepath=sys.argv[1]
destpath=sys.argv[2][8:] if len(sys.argv)==3 else os.path.dirname(sys.argv[0])
ironpythonpath=None
try:
    try:
        keyh=_winreg.OpenKey(_winreg.HKEY_LOCAL_MACHINE, "SOFTWARE\\IronPython\\2.7\\InstallPath")
        ironpythonpath=_winreg.QueryValue(keyh, None)
    except Exception as e:
        try:
            keyh=_winreg.OpenKey(_winreg.HKEY_LOCAL_MACHINE, "SOFTWARE\\Wow6432Node\\IronPython\\2.7\\InstallPath")
            ironpythonpath=_winreg.QueryValue(keyh, "")
        except Exception as e:
            pass
finally:
    if ironpythonpath is not None:
        _winreg.CloseKey(keyh)
        print("IronPython found at "+ironpythonpath)
    else:
        raise Exception("Cannot find IronPython in the registry")

# What we do now is to load the python source but against the customised IronPython runtime
# library which has been hacked to work with IronPython. This spits out the right set of
# modules mostly, but we include the main python's site-packages in order to resolve any
# third party packages
print("Scanning '"+sourcepath+"' for dependencies and outputting into '"+destpath+"' ...")
searchpaths=[".", ironpythonpath+os.sep+"Lib"]
searchpaths+=[x for x in sys.path if 'site-packages' in x]
finder=modulefinder.ModuleFinder(searchpaths)
finder.run_script(sourcepath)
print(finder.report())
modules=[]
badmodules=finder.badmodules.keys()
for name, mod in finder.modules.iteritems():
    path=mod.__file__
    # Ignore internal modules
    if path is None: continue
    # Ignore DLL internal modules
    #if '\\DLLs\\' in path: continue
    # Watch out for C modules
    if os.path.splitext(path)[1]=='.pyd':
        print("WARNING: I don't support handling C modules at '"+path+"'")
        badmodules.append(name)
        continue
    modules.append((name, os.path.abspath(path)))
modules.sort()
print("Modules not imported due to not found, error or being a C module:")
print("\n".join(badmodules))
raw_input("\nPress Return if you are happy with these missing modules ...")

with open(destpath+os.sep+"files.txt", "w") as oh:
    oh.writelines([x[1]+'\n' for x in modules])
cmd='ipy64 '+destpath+os.sep+'pyc.py /main:"'+os.path.abspath(sourcepath)+'" /out:'+os.path.splitext(os.path.basename(sourcepath))[0]+' /target:exe /standalone /platform:x86 /files:'+destpath+os.sep+'files.txt'
print(cmd)
cwd=os.getcwd()
try:
    os.chdir(destpath)
    retcode=subprocess.call(cmd, shell=True)
finally:
    os.chdir(cwd)
sys.exit(retcode)
