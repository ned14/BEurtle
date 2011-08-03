BEurtle v1.01 beta 1 (3rd August 2011)
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
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
severity, creation date and summary. By clicking on column headers, you
can sort status and severity and it sorts it the right way. One simply
selects the bugs about to be fixed in the commit and hits OK - this will
list the bugs in question in the commit message as being fixed.

Upon committing, BEurtle will scan your commit message for the word
"fixed". If that word is present, it will scan it for any BE format issue
id 'hex/hex'. It then checks to see if that issue exists and is open -
if so, it will offer to close the issue for you. If you have enabled
auto-issue commenting with fix revision, it will do that and mark the
issue closed.

You can quickly change the status of issues by selecting them and
right clicking to bring up a context menu. The same context menu also
lets you filter out issues you don't want to see by typing in the relevant
text to exclude into its relevant section. The filter menu doesn't auto-
close, so you can mess around with settings and the list of issues will
dynamically update itself as you change things. Of course, you can add and
delete issues using the buttons at the bottom of the dialog.

Double-clicking or hitting enter on an issue will open its detail box
which also makes a very basic stab at showing the comments with replies
correctly sorted and indented (i.e. they're threaded). It doesn't look
pretty, but it's sufficient. You can edit an issue by clicking the Edit
button, and upon hitting OK it will save out the changes.

HTTP access is supported, so you can enter a http:// remote repo address
and after some delay due to BE being slow it will appear. All editing
operations are also supported on remote repos.

Note that listing all bugs including closed ones on
http://bugs.bugseverywhere.org/ pukes on the command line, so it pukes also
in this plugin. Hassle BE's author to fix this.

What isn't supported:
-=-=-=-=-=-=-=-=-=-=-
There is no way to add or edit comments.

Binary attachments to comments aren't decoded.

Currently can't export or import bugs in XML. This might get fixed in v1.1.

Currently it doesn't keep a list of people who have previously fixed
something. This would be useful for quick-assigning someone to fix a bug.

There is no bug dependency support at all, nor for tagging.

There is no support for diffing, setting due dates, merging, subscribing or
targeting.

Lastly, I'd personally really like a way of merging GitHub issues with BE
issues. Because I'd personally really like this, you have a good chance of
seeing support for it soon.


To Install:
-=-=-=-=-=-
1. Go install Python (http://www.python.org/). You probably want a 2.x
version as I don't think BE fully supports 3.x yet.

2. Supposedly the installer will automatically download .NET v2.0 if it isn't
present on your system, but if it doesn't then you need that too before installing.

3. Run either the x86 or x64 installer as appropriate to your system. Point the
installer at your python installation and where you want to install the plugin.

4. Open up your TortoiseXXX settings dialog choosing Issue Tracker Integration.
Click Add and type in the path of the root of your repository, choosing BEurtle
as the provider. Click on the Options button and choose what options you'd prefer.
Exit by clicking OK, then OK to close the Issue Tracker Integration dialog.

5. Try committing something in your repository. You should see a "Bugs, Bugs, Bugs!"
button in the top right of the commit box. Click that. You should get the dialog
and a message asking if you want to create a new BE repository because there is no
BE repository in your VC repository root. Say yes to this.

6. Remember that BE's tracking data is stored by your VC repository. After you
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
v1.01 beta 1 (3rd August 2011):
  * [SHA: e6eadbe]
    * Issue 701/944 (Add some filter settings so one can filter by status and
	  severity) fixed.
  * [SHA: 42568d8]
    * Issue 701/789 (Sort by status/severity first, but sort by date (with oldest
	  first) thereafter) fixed.
  * [SHA: 55a7af7]
    * Issue 701/9f6 (Get dialogs to open on the window of their parent) fixed.
  * [SHA: 4058436]
    * Issue 701/f36 (Add an installer so I can install this easily on my other
	  machines) fixed.
  * [SHA: e0ea876]
    * Now can automatically mark issues mentioned in a commit message with the word
	  "fixed". For example, having 701/ae8 will trigger that to be marked as fixed
	  if it is currently open in the BE repo.
    * Issue 701/ae8 (test issue for auto closing in commit messages) fixed.
  * [SHA: b4738f6]
    * Added options dialog
    * Issue 701/bb5 (Add IBugTraqProvider2 support) fixed.
    * Issue 701/ebd (Add HTML dumping option and repo create in config settings) fixed.
  * [SHA: 8915ee5] Bumped to v1.01.

v1.00 beta 1 (31st July 2011):
  * [SHA: 4a71029] Released first version to public.

