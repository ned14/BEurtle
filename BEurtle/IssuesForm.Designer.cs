﻿namespace BEurtle
{
    partial class IssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
            this.IssuesList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unconfirmedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wontfixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wishlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fatalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allClosedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allNotSeriousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fromStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromStatusClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.FromStatusTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fromSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromSeverityClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.FromSeverityTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fromCreatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromCreatedClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.FromCreatedTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fromSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromSummaryClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.FromSummaryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BERepoLocation = new System.Windows.Forms.TextBox();
            this.NewIssue = new System.Windows.Forms.Button();
            this.DeleteIssue = new System.Windows.Forms.Button();
            this.BERepoLocationBrowse = new System.Windows.Forms.Button();
            this.VCSInfo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LinkAbout = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesList)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IssuesList
            // 
            this.IssuesList.AllowUserToAddRows = false;
            this.IssuesList.AllowUserToDeleteRows = false;
            this.IssuesList.AllowUserToResizeRows = false;
            this.IssuesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IssuesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IssuesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Status,
            this.Severity,
            this.Created1,
            this.Summary,
            this.CommentCount});
            this.IssuesList.ContextMenuStrip = this.contextMenu;
            this.IssuesList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.IssuesList.Location = new System.Drawing.Point(12, 82);
            this.IssuesList.Name = "IssuesList";
            this.IssuesList.ReadOnly = true;
            this.IssuesList.RowHeadersVisible = false;
            this.IssuesList.RowTemplate.ReadOnly = true;
            this.IssuesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IssuesList.Size = new System.Drawing.Size(604, 319);
            this.IssuesList.TabIndex = 0;
            this.IssuesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IssuesList_CellClick);
            this.IssuesList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IssuesList_CellDoubleClick);
            this.IssuesList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.IssuesList_CellMouseDown);
            this.IssuesList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.IssuesList_SortCompare);
            this.IssuesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssuesList_KeyDown);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.Width = 70;
            // 
            // Severity
            // 
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            this.Severity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Severity.Width = 70;
            // 
            // Created1
            // 
            this.Created1.HeaderText = "Created";
            this.Created1.Name = "Created1";
            this.Created1.ReadOnly = true;
            this.Created1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Created1.Width = 130;
            // 
            // Summary
            // 
            this.Summary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // CommentCount
            // 
            this.CommentCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.CommentCount.HeaderText = "Comments";
            this.CommentCount.Name = "CommentCount";
            this.CommentCount.ReadOnly = true;
            this.CommentCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CommentCount.UseColumnTextForLinkValue = true;
            this.CommentCount.Width = 5;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeStatusToolStripMenuItem,
            this.changeSeverityToolStripMenuItem,
            this.filterOutToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.copyAsXMLToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.ShowCheckMargin = true;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(160, 164);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unconfirmedToolStripMenuItem,
            this.openToolStripMenuItem,
            this.assignedToolStripMenuItem,
            this.testToolStripMenuItem,
            this.closedToolStripMenuItem,
            this.fixedToolStripMenuItem,
            this.wontfixToolStripMenuItem});
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.changeStatusToolStripMenuItem.Text = "Change S&tatus";
            // 
            // unconfirmedToolStripMenuItem
            // 
            this.unconfirmedToolStripMenuItem.Name = "unconfirmedToolStripMenuItem";
            this.unconfirmedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.unconfirmedToolStripMenuItem.Text = "unconfirmed";
            this.unconfirmedToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // assignedToolStripMenuItem
            // 
            this.assignedToolStripMenuItem.Name = "assignedToolStripMenuItem";
            this.assignedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.assignedToolStripMenuItem.Text = "assigned";
            this.assignedToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // closedToolStripMenuItem
            // 
            this.closedToolStripMenuItem.Name = "closedToolStripMenuItem";
            this.closedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closedToolStripMenuItem.Text = "closed";
            this.closedToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // fixedToolStripMenuItem
            // 
            this.fixedToolStripMenuItem.Name = "fixedToolStripMenuItem";
            this.fixedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.fixedToolStripMenuItem.Text = "fixed";
            this.fixedToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // wontfixToolStripMenuItem
            // 
            this.wontfixToolStripMenuItem.Name = "wontfixToolStripMenuItem";
            this.wontfixToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.wontfixToolStripMenuItem.Text = "wontfix";
            this.wontfixToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // changeSeverityToolStripMenuItem
            // 
            this.changeSeverityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetToolStripMenuItem,
            this.wishlistToolStripMenuItem,
            this.minorToolStripMenuItem,
            this.seriousToolStripMenuItem,
            this.criticalToolStripMenuItem,
            this.fatalToolStripMenuItem});
            this.changeSeverityToolStripMenuItem.Name = "changeSeverityToolStripMenuItem";
            this.changeSeverityToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.changeSeverityToolStripMenuItem.Text = "Change S&everity";
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.targetToolStripMenuItem.Text = "target";
            this.targetToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // wishlistToolStripMenuItem
            // 
            this.wishlistToolStripMenuItem.Name = "wishlistToolStripMenuItem";
            this.wishlistToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.wishlistToolStripMenuItem.Text = "wishlist";
            this.wishlistToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // minorToolStripMenuItem
            // 
            this.minorToolStripMenuItem.Name = "minorToolStripMenuItem";
            this.minorToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.minorToolStripMenuItem.Text = "minor";
            this.minorToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // seriousToolStripMenuItem
            // 
            this.seriousToolStripMenuItem.Name = "seriousToolStripMenuItem";
            this.seriousToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.seriousToolStripMenuItem.Text = "serious";
            this.seriousToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // criticalToolStripMenuItem
            // 
            this.criticalToolStripMenuItem.Name = "criticalToolStripMenuItem";
            this.criticalToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.criticalToolStripMenuItem.Text = "critical";
            this.criticalToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // fatalToolStripMenuItem
            // 
            this.fatalToolStripMenuItem.Name = "fatalToolStripMenuItem";
            this.fatalToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.fatalToolStripMenuItem.Text = "fatal";
            this.fatalToolStripMenuItem.Click += new System.EventHandler(this.changeSeverityToolStripMenuItem_Click);
            // 
            // filterOutToolStripMenuItem
            // 
            this.filterOutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.allClosedItemsToolStripMenuItem,
            this.allNotSeriousToolStripMenuItem,
            this.toolStripSeparator1,
            this.fromStatusToolStripMenuItem,
            this.fromSeverityToolStripMenuItem,
            this.fromCreatedToolStripMenuItem,
            this.fromSummaryToolStripMenuItem});
            this.filterOutToolStripMenuItem.Name = "filterOutToolStripMenuItem";
            this.filterOutToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.filterOutToolStripMenuItem.Text = "Filter &Out";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // allClosedItemsToolStripMenuItem
            // 
            this.allClosedItemsToolStripMenuItem.Name = "allClosedItemsToolStripMenuItem";
            this.allClosedItemsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.allClosedItemsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allClosedItemsToolStripMenuItem.Text = "&All Closed Items";
            this.allClosedItemsToolStripMenuItem.Click += new System.EventHandler(this.allClosedItemsToolStripMenuItem_Click);
            // 
            // allNotSeriousToolStripMenuItem
            // 
            this.allNotSeriousToolStripMenuItem.Name = "allNotSeriousToolStripMenuItem";
            this.allNotSeriousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.allNotSeriousToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allNotSeriousToolStripMenuItem.Text = "All &Not Serious";
            this.allNotSeriousToolStripMenuItem.Click += new System.EventHandler(this.allNotSeriousToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // fromStatusToolStripMenuItem
            // 
            this.fromStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromStatusClear,
            this.toolStripSeparator3,
            this.FromStatusTextBox});
            this.fromStatusToolStripMenuItem.Name = "fromStatusToolStripMenuItem";
            this.fromStatusToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.fromStatusToolStripMenuItem.Text = "From S&tatus";
            // 
            // FromStatusClear
            // 
            this.FromStatusClear.Name = "FromStatusClear";
            this.FromStatusClear.Size = new System.Drawing.Size(160, 22);
            this.FromStatusClear.Text = "Clear";
            this.FromStatusClear.Click += new System.EventHandler(this.FromStatusClear_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // FromStatusTextBox
            // 
            this.FromStatusTextBox.Name = "FromStatusTextBox";
            this.FromStatusTextBox.Size = new System.Drawing.Size(100, 23);
            this.FromStatusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FromStatusTextBox_KeyPress);
            this.FromStatusTextBox.TextChanged += new System.EventHandler(this.FromStatusTextBox_TextChanged);
            // 
            // fromSeverityToolStripMenuItem
            // 
            this.fromSeverityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromSeverityClear,
            this.toolStripSeparator4,
            this.FromSeverityTextBox});
            this.fromSeverityToolStripMenuItem.Name = "fromSeverityToolStripMenuItem";
            this.fromSeverityToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.fromSeverityToolStripMenuItem.Text = "From S&everity";
            // 
            // FromSeverityClear
            // 
            this.FromSeverityClear.Name = "FromSeverityClear";
            this.FromSeverityClear.Size = new System.Drawing.Size(160, 22);
            this.FromSeverityClear.Text = "Clear";
            this.FromSeverityClear.Click += new System.EventHandler(this.FromSeverityClear_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // FromSeverityTextBox
            // 
            this.FromSeverityTextBox.Name = "FromSeverityTextBox";
            this.FromSeverityTextBox.Size = new System.Drawing.Size(100, 23);
            this.FromSeverityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FromSeverityTextBox_KeyPress);
            this.FromSeverityTextBox.TextChanged += new System.EventHandler(this.FromSeverityTextBox_TextChanged);
            // 
            // fromCreatedToolStripMenuItem
            // 
            this.fromCreatedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromCreatedClear,
            this.toolStripSeparator5,
            this.FromCreatedTextBox});
            this.fromCreatedToolStripMenuItem.Name = "fromCreatedToolStripMenuItem";
            this.fromCreatedToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.fromCreatedToolStripMenuItem.Text = "From C&reated";
            // 
            // FromCreatedClear
            // 
            this.FromCreatedClear.Name = "FromCreatedClear";
            this.FromCreatedClear.Size = new System.Drawing.Size(160, 22);
            this.FromCreatedClear.Text = "Clear";
            this.FromCreatedClear.Click += new System.EventHandler(this.FromCreatedClear_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // FromCreatedTextBox
            // 
            this.FromCreatedTextBox.Name = "FromCreatedTextBox";
            this.FromCreatedTextBox.Size = new System.Drawing.Size(100, 23);
            this.FromCreatedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FromCreatedTextBox_KeyPress);
            this.FromCreatedTextBox.TextChanged += new System.EventHandler(this.FromCreatedTextBox_TextChanged);
            // 
            // fromSummaryToolStripMenuItem
            // 
            this.fromSummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromSummaryClear,
            this.toolStripSeparator6,
            this.FromSummaryTextBox});
            this.fromSummaryToolStripMenuItem.Name = "fromSummaryToolStripMenuItem";
            this.fromSummaryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.fromSummaryToolStripMenuItem.Text = "From S&ummary";
            // 
            // FromSummaryClear
            // 
            this.FromSummaryClear.Name = "FromSummaryClear";
            this.FromSummaryClear.Size = new System.Drawing.Size(160, 22);
            this.FromSummaryClear.Text = "Clear";
            this.FromSummaryClear.Click += new System.EventHandler(this.FromSummaryClear_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // FromSummaryTextBox
            // 
            this.FromSummaryTextBox.Name = "FromSummaryTextBox";
            this.FromSummaryTextBox.Size = new System.Drawing.Size(100, 23);
            this.FromSummaryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FromSummaryTextBox_KeyPress);
            this.FromSummaryTextBox.TextChanged += new System.EventHandler(this.FromSummaryTextBox_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Visible = false;
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Visible = false;
            // 
            // copyAsXMLToolStripMenuItem
            // 
            this.copyAsXMLToolStripMenuItem.Name = "copyAsXMLToolStripMenuItem";
            this.copyAsXMLToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.copyAsXMLToolStripMenuItem.Text = "Copy as &XML";
            this.copyAsXMLToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(537, 407);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(456, 407);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path/URL:";
            // 
            // BERepoLocation
            // 
            this.BERepoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BERepoLocation.Location = new System.Drawing.Point(318, 30);
            this.BERepoLocation.Name = "BERepoLocation";
            this.BERepoLocation.Size = new System.Drawing.Size(213, 20);
            this.BERepoLocation.TabIndex = 5;
            this.BERepoLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BERepoLocation_KeyPress);
            // 
            // NewIssue
            // 
            this.NewIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewIssue.Location = new System.Drawing.Point(16, 407);
            this.NewIssue.Name = "NewIssue";
            this.NewIssue.Size = new System.Drawing.Size(75, 23);
            this.NewIssue.TabIndex = 1;
            this.NewIssue.Text = "New Issue";
            this.NewIssue.UseVisualStyleBackColor = true;
            this.NewIssue.Click += new System.EventHandler(this.NewIssue_Click);
            // 
            // DeleteIssue
            // 
            this.DeleteIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteIssue.Location = new System.Drawing.Point(97, 407);
            this.DeleteIssue.Name = "DeleteIssue";
            this.DeleteIssue.Size = new System.Drawing.Size(75, 23);
            this.DeleteIssue.TabIndex = 2;
            this.DeleteIssue.Text = "Delete Issue";
            this.DeleteIssue.UseVisualStyleBackColor = true;
            this.DeleteIssue.Click += new System.EventHandler(this.DeleteIssue_Click);
            // 
            // BERepoLocationBrowse
            // 
            this.BERepoLocationBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BERepoLocationBrowse.Location = new System.Drawing.Point(537, 28);
            this.BERepoLocationBrowse.Name = "BERepoLocationBrowse";
            this.BERepoLocationBrowse.Size = new System.Drawing.Size(75, 23);
            this.BERepoLocationBrowse.TabIndex = 6;
            this.BERepoLocationBrowse.Text = "Browse";
            this.BERepoLocationBrowse.UseVisualStyleBackColor = true;
            this.BERepoLocationBrowse.Click += new System.EventHandler(this.BERepoLocationBrowse_Click);
            // 
            // VCSInfo
            // 
            this.VCSInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VCSInfo.Location = new System.Drawing.Point(256, 56);
            this.VCSInfo.Name = "VCSInfo";
            this.VCSInfo.ReadOnly = true;
            this.VCSInfo.Size = new System.Drawing.Size(356, 20);
            this.VCSInfo.TabIndex = 8;
            this.VCSInfo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LinkAbout
            // 
            this.LinkAbout.AutoSize = true;
            this.LinkAbout.Location = new System.Drawing.Point(106, 62);
            this.LinkAbout.Name = "LinkAbout";
            this.LinkAbout.Size = new System.Drawing.Size(35, 13);
            this.LinkAbout.TabIndex = 7;
            this.LinkAbout.TabStop = true;
            this.LinkAbout.Text = "About";
            this.LinkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkAbout_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "BEurtle v1.50α";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "(C) 2011-2013 Niall Douglas";
            // 
            // IssuesForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LinkAbout);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.VCSInfo);
            this.Controls.Add(this.BERepoLocationBrowse);
            this.Controls.Add(this.DeleteIssue);
            this.Controls.Add(this.NewIssue);
            this.Controls.Add(this.BERepoLocation);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.IssuesList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(540, 256);
            this.Name = "IssuesForm";
            this.Text = "Bugs Everywhere Issues";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssuesForm_FormClosing);
            this.Load += new System.EventHandler(this.IssuesForm_Load);
            this.Shown += new System.EventHandler(this.IssuesForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.IssuesForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.IssuesForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssuesForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.IssuesList)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView IssuesList;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BERepoLocation;
        private System.Windows.Forms.Button NewIssue;
        private System.Windows.Forms.Button DeleteIssue;
        private System.Windows.Forms.Button BERepoLocationBrowse;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem filterOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allClosedItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FromStatusClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fromSeverityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FromSeverityClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox FromSeverityTextBox;
        private System.Windows.Forms.ToolStripMenuItem fromCreatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FromCreatedClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripTextBox FromCreatedTextBox;
        private System.Windows.Forms.ToolStripMenuItem fromSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FromSummaryClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox FromSummaryTextBox;
        private System.Windows.Forms.ToolStripTextBox FromStatusTextBox;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unconfirmedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wontfixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allNotSeriousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAsXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSeverityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wishlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seriousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fatalToolStripMenuItem;
        private System.Windows.Forms.TextBox VCSInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel LinkAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewLinkColumn CommentCount;
    }
}