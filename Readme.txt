BEurtle v1.50 alpha 2 (?)
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
(C) 2011-2013 Niall Douglas, ned Productions Limited, http://www.nedproductions.biz/

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

Double-clicking or hitting enter on an issue will open its detail box.
You can view comments, add new ones, or reply to existing comments. You
can also edit the issue's detail, and drag and drop message content
(including HTML/pictures/binary attachments) between BEurtle and any
COM supporting application.

HTTP access is supported, so you can enter a http:// remote repo address
and after some delay due to BE being slow it will appear. All editing
operations are also supported on remote repos.

If you use the embedded copy of BE (in Program Files/.../BEurtle/dist),
you can do 'be gui' to launch BEurtle from the command line.


What isn't supported:
-=-=-=-=-=-=-=-=-=-=-
There is no bug dependency support at all, nor for tagging.

There is no support for setting due dates, subscribing or targeting.

This release wraps the be command line directly, and as a result is
painfully slow on Intel Atom netbooks. A fix (not to use be) is coming soon.

What's coming soon:
-=-=-=-=-=-=-=-=-=-
As I mentioned above, on an underpowered Intel Atom laptop BEurtle is
fairly painfully slow as several invocations of BE have to often be made
per BEurtle operation, and things can take a few seconds to happen. Next
release of BEurtle will use BEXML, a very fast, lazy, RESTful web service
exposing Bugs Everywhere and other issue trackers. Once BEurtle is using
BEXML, all operations will be nearly instant, even on an Atom netbook.

BEXML is slowly gaining the ability to wrap a Redmine issue tracker in a
BEXML interface, and not long after that it will also be able to wrap a
Github issue tracker too. That will enable BEurtle to access Redmine/
Github/any supported backend issue trackers and therefore to automagically
copy/move/merge bugs and issues between your Bugs Everywhere tracker and
any supported external tracker. I need this facility personally, so you
have a very strong chance of seeing it completed soon as it would save me
a great deal of time personally.

To Install:
-=-=-=-=-=-
1. Install your choice of TortoiseSVN, TortoiseGIT, TortoiseHG, TortoiseBZR etc.

2. Install this plugin.

3. Open up your TortoiseXXX settings dialog choosing Issue Tracker Integration.
Click Add and type in the path of the root of your repository, choosing BEurtle
as the provider. Click on the Options button and choose what options you'd prefer.
Exit by clicking OK, then OK to close the Issue Tracker Integration dialog.

4. Try committing something in your repository. You should see a "Bugs, Bugs, Bugs!"
button in the top right of the commit box. Click that. You should get the dialog
and a message asking if you want to create a new BE repository because there is no
BE repository in your VC repository root. Say yes to this.

5. Remember that BE's tracking data is stored by your VC repository. After you
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
v1.50 alpha 2 (?):

Bugs fixed:
  * Opening a new issue, then pressing new comment, then closing the window no
    longer produces an error.
  * No longer possible to add an issue with an empty summary by pressing add
    comment and then closing the window.

Features added:
  * Finally fixed the lack of clipboard handling in the rich text editor, so now
    one can copy, cut and paste etc. as one should.
  * Now can add hyperlinks to comments, and clicking on a hyperlink opens it in
    an external web browser.

v1.50 alpha 1 (18th July 2012):

Bugs fixed:
  * Fixed lack of unicode support by hacking BE to behave on Windows.
  * Fixed missing severity change feature on context menu.
  * Went through the code and trapped every possible disc i/o error I could find,
    now doing something sensible instead of erroring out.
  * Installer now deinstalls properly instead of leaving files around.
  * Python no longer needs to be installed for BEurtle to work.
  * HTML dump finally works properly and doesn't forget to add newly dumped items.

Features added:
  * F5 now refreshes bug list.
  * Added auto-completion of commonly used fields like Author, Reporter etc.
  * Added commenting display and support.
  * Added fancy new rich text comment editor based on MSHTML.
  * Files and data can now be dragged and dropped in to create comments.
  * BEurtle windows now remember their position and location across appearances,
    correctly coping with multi-monitor setups and resolution changes.
  * BE no longer needs to be installed for BEurtle to work (it uses an embedded
    copy of BE and a Python 2.7.2 runtime).
  * BE XML dump is now optionally cached and the cache is used to greatly reduce
    first load time if it isn't stale. This is a godsend on my netbook.
  * Installer is now x86/x64 unified, securely signed, and auto-detects missing
    dependencies and auto-installs them.
  * Now optionally shows comment counts in main dialog.
  * Added 'be gui' tool to embedded BE. This simply launches BEurtle from the
    current directory.

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

