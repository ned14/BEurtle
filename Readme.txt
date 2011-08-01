BEurtle v1.0 beta 1 (31st July 2011)
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
(C) 2011 Niall Douglas, ned Productions Limited

Please find enclosed a TortoiseXXX plugin for the Bugs Everywhere
distributed issue tracker (http://www.bugseverywhere.org/). The plugin
integrates with TortoiseSVN, TortoiseGIT, TortoiseHG, TortoiseBZR etc.
etc. to provide a pretty GUI interface for embedded issue tracking.

Much as distributed source control has revolutionised productivity for
many people, distributed issue tracking promises to add another chunk
of productivity. One tracks the issues alongside the branches of code
being worked upon, and issues can be merged, uploaded, tagged and
branched just like code.

This becomes really useful when you're getting older like me and can't
remember what's wrong with your code anymore :) If you have ever been
searching for some code and noticed something wrong with a different
bit of code, then forgot you noticed, this plugin is definitely for you!

What is supported:
-=-=-=-=-=-=-=-=-=
The BEurtle plugin literally wraps the command line be. You get
a dialog box which lists all issues, showing their current status,
severity, creation date and summary. You can sort status and severity
and it sorts it the right way. One simply selects the bugs about to be
fixed in the commit and hits OK - this will list the bugs in question
in the commit message as being fixed.

v1.0 supports only the IBugTraqProvider interface
(http://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-ibugtraqprovider.html),
so unfortunately that is as far as integration currently goes. v1.1 will
no doubt add IBugTraqProvider2 support.

You can also quickly change the status of issues by selecting them and
changing their status using the combobox at the bottom. You can add and
delete issues using the buttons provided.

Double-clicking or hitting enter on an issue will open its detail box
which also makes a very basic stab at showing the comments with replies
correctly sorted and indented (i.e. they're threaded). It doesn't look
pretty, but it's sufficient. You can edit an issue by clicking the Edit
button, and upon hitting OK it will save out the changes.

Lastly, HTTP access is supported, so you can enter a http:// remote repo
address and after some delay it will appear. All editing operations are
also supported on remote repos.

Note that listing all bugs including closed ones on
http://bugs.bugseverywhere.org/ pukes on the command line, so it pukes also
in this plugin. Hassle BE's author to fix this.

What isn't supported:
-=-=-=-=-=-=-=-=-=-=-
There is currently no way to either create or delete repositories - you'll
still have to do this on the command line.

There is no way to add or edit comments.

Binary attachments to comments aren't decoded.

Currently can't export or import bugs in XML. This might get fixed in v1.1.

Currently it doesn't keep a list of people who have previously fixed
something. This would be useful for quick-assigning someone to fix a bug.

There is no bug dependency support at all, nor for tagging.

There is no support for diffing, setting due dates, merging, subscribing or
targeting.

Currently there is no support for dumping out a HTML copy. This will likely
get fixed in v1.1 because it's useful for people who don't have BE installed.

Lastly, I'd personally really like a way of merging GitHub issues with BE
issues. Because I'd personally really like this, you have a good chance of
seeing support for it soon.


To Install:
-=-=-=-=-=-
1. Go install Python (http://www.python.org/). You currently want a 2.x
version as I don't think BE supports 3.x yet.

2. Go install easy_install from http://pypi.python.org/pypi/setuptools

3. On the command line, do "easy_install pyyaml". If it can't find easy_install
you may need to modify your PATH as detailed in Appendix A.

4. Download the latest BE from http://www.bugseverywhere.org/. Unpack it
somewhere and run "python setup.py install" inside it.

5. Current versions of BE don't come with a be shell invoker. Try typing
"be --help" on the command line. If it can't find BE, follow the
instructions in Appendix A below.

6. Current versions of BE puke on XML import. This prevents you adding new
issues or editing existing ones. To check this, open your python's
site-packages/libbe/command/import_xml.py. Find this section of code around
line 182:

        for new in root_bugs:
            try:
                old = bugdir.bug_from_uuid(new.alt_id)
            except KeyError:
                old = None
            if old == None:
                bd.append(new)

Replace as follows:

        for new in root_bugs:
            try:
                old = bugdir.bug_from_uuid(new.alt_id)
            except KeyError:
                old = None
            if old == None:
                bugdir.append(new) # bd is supposed to be bugdir

7. I haven't written an installer for BEurtle yet, so for now you're going
to have to do it manually. Open the registry file in BEurtle/BEurtle.reg.
Change all paths pointing to G:\BEurtle to point to wherever your BEurtle.dll
lives. Save out the registry file. Run the registry file.

8. Open up your TortoiseXXX settings dialog choosing Issue Tracker Integration.
Click Add and type in the path of the root of your repository, choosing BEurtle
as the provider. Click OK.

9. Try committing something in your repository. You should see a "Bugs, bugs, bugs!"
button in the top right of the commit box. Click that. You should get the dialog
and an error because there is no BE repository in your VC repository root.

10. To fix this, open a command box and go to your VC repository root. Type "be init"
and hit enter. Now retry committing something - you should no longer get an error.

11. Remember that BE's tracking data is stored by your VC repository. After you
modify issues you'll need to commit to your VC repository to store the changes. Enjoy!


Problems?
-=-=-=-=-
Go to http://github.com/ned14/BEurtle and see if changes to HEAD have fixed the
problem.

Failing that, check http://github.com/ned14/BEurtle/issues to see if someone has
already reported the problem. If they haven't, add an issue there.


Want a new feature?
-=-=-=-=-=-=-=-=-=-
You can add it yourself and submit a pull request on github, or a patch otherwise.

Or you can contract my consulting company ned Productions Limited to do it for you.
See http://www.nedproductions.biz/. For something small like this, I would likely
strike a fixed price deal with any customer.


ChangeLog:
-=-=-=-=-=
v1.01 beta 1 (?):
  * [SHA: b4738f6] First attempt at an IBugTraqProvider2 implementation.
  * [SHA: 8915ee5] Bumped to v1.01.

v1.00 beta 1 (31st July 2011):
  * [SHA: 4a71029] Released first version to public.

  
Appendix A: Fixing the lack of be.bat on Windows
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
Go to your python root directory and into the scripts directory. Create a file called
be.bat and paste the following into it using a text editor:

@echo off
python -c "import sys, libbe.ui.command_line; sys.exit(libbe.ui.command_line.main());" %*
set BE_TOOL_ERRORLEVEL=%ERRORLEVEL%
exit /B %BE_TOOL_ERRORLEVEL%

Some python installers don't add the scripts directory to PATH on Windows, so you may
need to open the properties of My Computer, choose advanced settings, then environment
variables, then edit the PATH system environment variable. Find where it says x:\pythonXX
and after add x:\pythonXX\scripts. Save the changes, open a NEW command box and test
that be is now available from the command line.
