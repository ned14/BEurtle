#!/usr/bin/python
# Tests installer in VirtualBox
# (C) 2011-2012 Niall Douglas http://www.nedproductions.biz

INSTALLER="bin/Release/BEurtle Plugin for TortoiseXXX (x86 and x64).exe"

TEST_ACCOUNT="test_normal"
TEST_ACCOUNT_PASSWORD="test_normal"
TEST_ACCOUNT_ADMIN="test_admin"
TEST_ACCOUNT_ADMIN_PASSWORD="test_admin"


import sys, os, subprocess, time, zipfile
sys.path+=[os.path.abspath('test/ZSI-2.1-a1')]
import subprocess, unittest, shutil, random, logging
from collections import deque

log=logging.getLogger(__name__)

g_hascolors = False
term_colors = {
    'red':'\033[31m',
    'blue':'\033[94m',
    'green':'\033[92m',
    'yellow':'\033[93m',
    'magenta':'\033[35m',
    'cyan':'\033[36m'
    }

def colored(string,color):
    if not g_hascolors:
        return string
    global term_colors
    col = term_colors.get(color,None)
    if col:
        return col+str(string)+'\033[0m'
    else:
        return string

def reportError(progress):
    ei = progress.errorInfo
    if ei:
        print colored("Error in module '%s': %s" %(ei.component, ei.text), 'red')

def progressBar(p,wait=1000):
    try:
        while not p.completed:
            print "%s %%\r" %(colored(str(p.percent),'red')),
            sys.stdout.flush()
            p.waitForCompletion(wait)
        if int(p.resultCode) != 0:
            reportError(p)
        return 1
    except KeyboardInterrupt:
        print "Interrupted."
        if p.cancelable:
            print "Canceling task..."
            p.cancel()
        return 0

class TestInstaller(unittest.TestCase):
    """Tests the installer via VirtualBox"""
    def setUp(self):
        """Fires up VirtualBox"""
        try:
            self.vboxwebsrv=subprocess.Popen(os.path.join(os.environ['VBOX_INSTALL_PATH'], "VBoxWebSrv.exe"))
        except:
            self.vboxwebsrv=None

    def tearDown(self):
        """Clean up after the remote installer tests"""
        if self.vboxwebsrv is not None:
            self.vboxwebsrv.terminate()

    def test_push_winxp(self):
        """Fires up a virtual virgin Windows XP, installs push and pushes"""
        #return
        import vboxapi
        mgr=vboxapi.VirtualBoxManager("WEBSERVICE", {'url':'http://127.0.0.1:18083'})
        vbox=mgr.vbox
        machine=vbox.findMachine("Windows XP")
        # Revert to blank snapshot
        print "Reverting to blank snapshot ..."
        session=mgr.openMachineSession(machine)
        console=session.console
        try:
            snapshot=machine.findSnapshot("TestSnapshot4")
            progress=console.restoreSnapshot(snapshot)
            progress.waitForCompletion(10000)
            if progress.getResultCode()!=0: raise Exception, "Timed out restoring VM snapshot"
            mgr.closeMachineSession(session)
            # Fire up the beastie
            print "Launching VM ..."
            session=mgr.mgr.getSessionObject(vbox)
            progress=machine.launchVMProcess(session, "gui", "")
            progress.waitForCompletion(10000)
            if progress.getResultCode()!=0: raise Exception, "Timed out starting VM"
            console=session.console
            # Wait till VM has started
            print "Waiting for VM to start ..."
            while console.state!=mgr.constants.MachineState_FirstOnline:
                print console.state
                time.sleep(3)
            # Wait till guest additions is ready
            print "Waiting for Guest Additions to start ..."
            guest=console.guest
            additionsVersion=guest.additionsVersion
            while additionsVersion=="":
                additionsVersion=guest.additionsVersion
                time.sleep(3)
            facilities=None #(lambda x:{'lastUpdated':x.getLastUpdated(), 'name':x.getName(), 'status':x.getStatus(), 'type':x.getType()})(guest.facilities)
            print "Guest is running v", additionsVersion, "and has facilities", facilities

            print "Waiting twenty seconds for Windows XP to log in ..."
            time.sleep(20)

            # Push a copy of the .NET installer and install it
            print "Installing components inside VM ..."
            guest.directoryCreate("C:\\wb_test", TEST_ACCOUNT_ADMIN, TEST_ACCOUNT_ADMIN_PASSWORD, int('777', 8), 0)
            progress=guest.copyToGuest(os.path.abspath(INSTALLER), "C:\\wb_test\\installer.exe", TEST_ACCOUNT, TEST_ACCOUNT_PASSWORD, 0)
            progressBar(progress)
            if progress.getResultCode()!=0: raise Exception, "Timed out copying in me"
            progress=guest.copyToGuest(os.path.abspath("Redist/NetFx20SP2_x86.exe"), "C:\\wb_test\\NetFx20SP2_x86.exe", TEST_ACCOUNT, TEST_ACCOUNT_PASSWORD, 0)
            progressBar(progress)
            if progress.getResultCode()!=0: raise Exception, "Timed out copying in me"

            # Execute configurator
            progress, pid=guest.executeProcess("C:\\wb_test\\installer.exe", 0, ["-dC:\\wb_test"], [], TEST_ACCOUNT_ADMIN, TEST_ACCOUNT_ADMIN_PASSWORD, 0)
            print "Executed installer with pid", pid
            #if pid!=0 and 0:
            #    while not progress.completed:
            #        progress.waitForCompletion(100)
            #        data=guest.getProcessOutput(pid, 0, 10000, 4096)
            #        if data and len(data)>0:
            #            sys.stdout.write(data)
            #            continue
            #progress.waitForCompletion(12000)
            #if progress.getResultCode()!=0: raise Exception, "Timed out installing stuff"

        finally:
            # Turn off the beastie
            pass
            #if console.state==mgr.constants.MachineState_FirstOnline or console.state==MachineState_LastOnline:
                #print "Shutting down running VM ..."
                #progress=console.powerDown()
                #progress.waitForCompletion(-1)


if __name__ == '__main__':
    rootlogger=logging.getLogger()
    rootlogger.setLevel(logging.DEBUG)
    h=logging.StreamHandler()
    h.setLevel(logging.DEBUG)
    rootlogger.addHandler(h)

    unittest.main()
