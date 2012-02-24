namespace BEurtle
{
    partial class IssueDetail
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Comment1Reply");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Comment1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("image/jpeg", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueDetail));
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BoxUUID = new System.Windows.Forms.TextBox();
            this.BoxShortName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxCreator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxAssigned = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxCreated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BoxSeverity = new System.Windows.Forms.ComboBox();
            this.BoxStatus = new System.Windows.Forms.ComboBox();
            this.BoxSummary = new System.Windows.Forms.TextBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.BoxReporter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CommentAuthor = new System.Windows.Forms.TextBox();
            this.Commentary = new System.Windows.Forms.SplitContainer();
            this.CommentEdit = new System.Windows.Forms.Button();
            this.CommentDelete = new System.Windows.Forms.Button();
            this.CommentAdd = new System.Windows.Forms.Button();
            this.Comments = new System.Windows.Forms.TreeView();
            this.CommentBodyView = new System.Windows.Forms.TabControl();
            this.CommentBodyViewHTML = new System.Windows.Forms.TabPage();
            this.HTMLEditorControls = new System.Windows.Forms.Panel();
            this.ApplyOutdent = new System.Windows.Forms.Button();
            this.ApplyIndent = new System.Windows.Forms.Button();
            this.CommentEditCancel = new System.Windows.Forms.Button();
            this.ApplyOrderedList = new System.Windows.Forms.Button();
            this.ApplyBold = new System.Windows.Forms.Button();
            this.ApplyUnorderedList = new System.Windows.Forms.Button();
            this.ApplyItalics = new System.Windows.Forms.Button();
            this.ApplyAlignJustify = new System.Windows.Forms.Button();
            this.ApplyAlignLeft = new System.Windows.Forms.Button();
            this.ApplyAlignRight = new System.Windows.Forms.Button();
            this.ApplyAlignMiddle = new System.Windows.Forms.Button();
            this.CommentBody = new System.Windows.Forms.WebBrowser();
            this.CommentBodyViewRaw = new System.Windows.Forms.TabPage();
            this.CommentBodyRaw = new System.Windows.Forms.RichTextBox();
            this.CommentBodyViewFile = new System.Windows.Forms.TabPage();
            this.LoadAttachment = new System.Windows.Forms.Button();
            this.SaveAttachment = new System.Windows.Forms.Button();
            this.DraggableIcon = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CommentDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Commentary.Panel1.SuspendLayout();
            this.Commentary.Panel2.SuspendLayout();
            this.Commentary.SuspendLayout();
            this.CommentBodyView.SuspendLayout();
            this.CommentBodyViewHTML.SuspendLayout();
            this.HTMLEditorControls.SuspendLayout();
            this.CommentBodyViewRaw.SuspendLayout();
            this.CommentBodyViewFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.Location = new System.Drawing.Point(384, 13);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 21;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(383, 43);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 22;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UUID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BoxUUID
            // 
            this.BoxUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxUUID.Location = new System.Drawing.Point(82, 12);
            this.BoxUUID.Name = "BoxUUID";
            this.BoxUUID.ReadOnly = true;
            this.BoxUUID.Size = new System.Drawing.Size(295, 20);
            this.BoxUUID.TabIndex = 10;
            // 
            // BoxShortName
            // 
            this.BoxShortName.Location = new System.Drawing.Point(82, 39);
            this.BoxShortName.Name = "BoxShortName";
            this.BoxShortName.ReadOnly = true;
            this.BoxShortName.Size = new System.Drawing.Size(113, 20);
            this.BoxShortName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Short Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BoxCreator
            // 
            this.BoxCreator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxCreator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BoxCreator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BoxCreator.Location = new System.Drawing.Point(82, 65);
            this.BoxCreator.Name = "BoxCreator";
            this.BoxCreator.Size = new System.Drawing.Size(295, 20);
            this.BoxCreator.TabIndex = 0;
            this.toolTip1.SetToolTip(this.BoxCreator, "Try entering \" to start auto-completion");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Assigned:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BoxAssigned
            // 
            this.BoxAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxAssigned.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BoxAssigned.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BoxAssigned.Location = new System.Drawing.Point(82, 117);
            this.BoxAssigned.Name = "BoxAssigned";
            this.BoxAssigned.Size = new System.Drawing.Size(295, 20);
            this.BoxAssigned.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BoxAssigned, "Try entering \" to start auto-completion");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Creator:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Created:";
            // 
            // BoxCreated
            // 
            this.BoxCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxCreated.Location = new System.Drawing.Point(255, 39);
            this.BoxCreated.Name = "BoxCreated";
            this.BoxCreated.ReadOnly = true;
            this.BoxCreated.Size = new System.Drawing.Size(122, 20);
            this.BoxCreated.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Severity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Summary:";
            // 
            // BoxSeverity
            // 
            this.BoxSeverity.FormattingEnabled = true;
            this.BoxSeverity.Items.AddRange(new object[] {
            "target",
            "wishlist",
            "minor",
            "serious",
            "critical",
            "fatal"});
            this.BoxSeverity.Location = new System.Drawing.Point(82, 143);
            this.BoxSeverity.Name = "BoxSeverity";
            this.BoxSeverity.Size = new System.Drawing.Size(121, 21);
            this.BoxSeverity.TabIndex = 3;
            // 
            // BoxStatus
            // 
            this.BoxStatus.FormattingEnabled = true;
            this.BoxStatus.Items.AddRange(new object[] {
            "unconfirmed",
            "open",
            "assigned",
            "test",
            "closed",
            "fixed",
            "wontfix"});
            this.BoxStatus.Location = new System.Drawing.Point(256, 143);
            this.BoxStatus.Name = "BoxStatus";
            this.BoxStatus.Size = new System.Drawing.Size(121, 21);
            this.BoxStatus.TabIndex = 4;
            // 
            // BoxSummary
            // 
            this.BoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxSummary.Location = new System.Drawing.Point(83, 170);
            this.BoxSummary.Multiline = true;
            this.BoxSummary.Name = "BoxSummary";
            this.BoxSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BoxSummary.Size = new System.Drawing.Size(376, 36);
            this.BoxSummary.TabIndex = 5;
            this.BoxSummary.TextChanged += new System.EventHandler(this.BoxSummary_TextChanged);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEdit.Location = new System.Drawing.Point(383, 140);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 23;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // BoxReporter
            // 
            this.BoxReporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxReporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BoxReporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BoxReporter.Location = new System.Drawing.Point(82, 91);
            this.BoxReporter.Name = "BoxReporter";
            this.BoxReporter.Size = new System.Drawing.Size(295, 20);
            this.BoxReporter.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BoxReporter, "Try entering \" to start auto-completion");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Reporter:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CommentAuthor
            // 
            this.CommentAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CommentAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CommentAuthor.Location = new System.Drawing.Point(64, 3);
            this.CommentAuthor.Name = "CommentAuthor";
            this.CommentAuthor.ReadOnly = true;
            this.CommentAuthor.Size = new System.Drawing.Size(157, 20);
            this.CommentAuthor.TabIndex = 12;
            this.toolTip1.SetToolTip(this.CommentAuthor, "Try entering \" to start auto-completion");
            // 
            // Commentary
            // 
            this.Commentary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Commentary.Location = new System.Drawing.Point(6, 19);
            this.Commentary.Name = "Commentary";
            this.Commentary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Commentary.Panel1
            // 
            this.Commentary.Panel1.Controls.Add(this.CommentEdit);
            this.Commentary.Panel1.Controls.Add(this.CommentDelete);
            this.Commentary.Panel1.Controls.Add(this.CommentAdd);
            this.Commentary.Panel1.Controls.Add(this.Comments);
            this.Commentary.Panel1MinSize = 100;
            // 
            // Commentary.Panel2
            // 
            this.Commentary.Panel2.Controls.Add(this.CommentBodyView);
            this.Commentary.Panel2.Controls.Add(this.CommentDate);
            this.Commentary.Panel2.Controls.Add(this.label11);
            this.Commentary.Panel2.Controls.Add(this.label10);
            this.Commentary.Panel2.Controls.Add(this.CommentAuthor);
            this.Commentary.Panel2.Enabled = false;
            this.Commentary.Size = new System.Drawing.Size(436, 323);
            this.Commentary.SplitterDistance = 103;
            this.Commentary.TabIndex = 24;
            // 
            // CommentEdit
            // 
            this.CommentEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentEdit.Enabled = false;
            this.CommentEdit.Location = new System.Drawing.Point(358, 19);
            this.CommentEdit.Name = "CommentEdit";
            this.CommentEdit.Size = new System.Drawing.Size(75, 23);
            this.CommentEdit.TabIndex = 7;
            this.CommentEdit.Text = "Edit";
            this.CommentEdit.UseVisualStyleBackColor = true;
            this.CommentEdit.Click += new System.EventHandler(this.CommentEdit_Click);
            // 
            // CommentDelete
            // 
            this.CommentDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentDelete.Enabled = false;
            this.CommentDelete.Location = new System.Drawing.Point(358, 48);
            this.CommentDelete.Name = "CommentDelete";
            this.CommentDelete.Size = new System.Drawing.Size(75, 23);
            this.CommentDelete.TabIndex = 8;
            this.CommentDelete.Text = "Delete";
            this.CommentDelete.UseVisualStyleBackColor = true;
            this.CommentDelete.Click += new System.EventHandler(this.CommentDelete_Click);
            // 
            // CommentAdd
            // 
            this.CommentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentAdd.Enabled = false;
            this.CommentAdd.Location = new System.Drawing.Point(358, 77);
            this.CommentAdd.Name = "CommentAdd";
            this.CommentAdd.Size = new System.Drawing.Size(75, 23);
            this.CommentAdd.TabIndex = 9;
            this.CommentAdd.Text = "Add";
            this.CommentAdd.UseVisualStyleBackColor = true;
            this.CommentAdd.Click += new System.EventHandler(this.CommentAdd_Click);
            // 
            // Comments
            // 
            this.Comments.AllowDrop = true;
            this.Comments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comments.HideSelection = false;
            this.Comments.Location = new System.Drawing.Point(3, 3);
            this.Comments.Name = "Comments";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Comment1Reply";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Comment1";
            this.Comments.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.Comments.Size = new System.Drawing.Size(349, 97);
            this.Comments.TabIndex = 6;
            this.Comments.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Comments_ItemDrag);
            this.Comments.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.Comments_BeforeSelect);
            this.Comments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Comments_AfterSelect);
            this.Comments.DragDrop += new System.Windows.Forms.DragEventHandler(this.Comments_DragDrop);
            this.Comments.DragEnter += new System.Windows.Forms.DragEventHandler(this.Comments_DragEnter);
            this.Comments.DragOver += new System.Windows.Forms.DragEventHandler(this.Comments_DragOver);
            // 
            // CommentBodyView
            // 
            this.CommentBodyView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentBodyView.Controls.Add(this.CommentBodyViewHTML);
            this.CommentBodyView.Controls.Add(this.CommentBodyViewRaw);
            this.CommentBodyView.Controls.Add(this.CommentBodyViewFile);
            this.CommentBodyView.Location = new System.Drawing.Point(3, 29);
            this.CommentBodyView.Name = "CommentBodyView";
            this.CommentBodyView.SelectedIndex = 0;
            this.CommentBodyView.Size = new System.Drawing.Size(430, 184);
            this.CommentBodyView.TabIndex = 10;
            this.CommentBodyView.Selected += new System.Windows.Forms.TabControlEventHandler(this.CommentBodyView_Selected);
            // 
            // CommentBodyViewHTML
            // 
            this.CommentBodyViewHTML.Controls.Add(this.HTMLEditorControls);
            this.CommentBodyViewHTML.Controls.Add(this.CommentBody);
            this.CommentBodyViewHTML.Location = new System.Drawing.Point(4, 22);
            this.CommentBodyViewHTML.Name = "CommentBodyViewHTML";
            this.CommentBodyViewHTML.Padding = new System.Windows.Forms.Padding(3);
            this.CommentBodyViewHTML.Size = new System.Drawing.Size(422, 158);
            this.CommentBodyViewHTML.TabIndex = 0;
            this.CommentBodyViewHTML.Text = "WYSIWYG";
            this.CommentBodyViewHTML.UseVisualStyleBackColor = true;
            // 
            // HTMLEditorControls
            // 
            this.HTMLEditorControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HTMLEditorControls.Controls.Add(this.ApplyOutdent);
            this.HTMLEditorControls.Controls.Add(this.ApplyIndent);
            this.HTMLEditorControls.Controls.Add(this.CommentEditCancel);
            this.HTMLEditorControls.Controls.Add(this.ApplyOrderedList);
            this.HTMLEditorControls.Controls.Add(this.ApplyBold);
            this.HTMLEditorControls.Controls.Add(this.ApplyUnorderedList);
            this.HTMLEditorControls.Controls.Add(this.ApplyItalics);
            this.HTMLEditorControls.Controls.Add(this.ApplyAlignJustify);
            this.HTMLEditorControls.Controls.Add(this.ApplyAlignLeft);
            this.HTMLEditorControls.Controls.Add(this.ApplyAlignRight);
            this.HTMLEditorControls.Controls.Add(this.ApplyAlignMiddle);
            this.HTMLEditorControls.Enabled = false;
            this.HTMLEditorControls.Location = new System.Drawing.Point(6, 6);
            this.HTMLEditorControls.Name = "HTMLEditorControls";
            this.HTMLEditorControls.Size = new System.Drawing.Size(410, 23);
            this.HTMLEditorControls.TabIndex = 25;
            // 
            // ApplyOutdent
            // 
            this.ApplyOutdent.Image = global::nedprod.Resource1.outdent;
            this.ApplyOutdent.Location = new System.Drawing.Point(205, 0);
            this.ApplyOutdent.Name = "ApplyOutdent";
            this.ApplyOutdent.Size = new System.Drawing.Size(23, 23);
            this.ApplyOutdent.TabIndex = 22;
            this.ApplyOutdent.UseVisualStyleBackColor = true;
            this.ApplyOutdent.Click += new System.EventHandler(this.ApplyOutdent_Click);
            // 
            // ApplyIndent
            // 
            this.ApplyIndent.Image = global::nedprod.Resource1.indent;
            this.ApplyIndent.Location = new System.Drawing.Point(228, 0);
            this.ApplyIndent.Name = "ApplyIndent";
            this.ApplyIndent.Size = new System.Drawing.Size(23, 23);
            this.ApplyIndent.TabIndex = 21;
            this.ApplyIndent.UseVisualStyleBackColor = true;
            this.ApplyIndent.Click += new System.EventHandler(this.ApplyIndent_Click);
            // 
            // CommentEditCancel
            // 
            this.CommentEditCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentEditCancel.Location = new System.Drawing.Point(335, 0);
            this.CommentEditCancel.Name = "CommentEditCancel";
            this.CommentEditCancel.Size = new System.Drawing.Size(75, 23);
            this.CommentEditCancel.TabIndex = 20;
            this.CommentEditCancel.Text = "Cancel";
            this.CommentEditCancel.UseVisualStyleBackColor = true;
            this.CommentEditCancel.Click += new System.EventHandler(this.CommentEditCancel_Click);
            // 
            // ApplyOrderedList
            // 
            this.ApplyOrderedList.Image = global::nedprod.Resource1.orderedlist;
            this.ApplyOrderedList.Location = new System.Drawing.Point(176, 0);
            this.ApplyOrderedList.Name = "ApplyOrderedList";
            this.ApplyOrderedList.Size = new System.Drawing.Size(23, 23);
            this.ApplyOrderedList.TabIndex = 19;
            this.ApplyOrderedList.UseVisualStyleBackColor = true;
            this.ApplyOrderedList.Click += new System.EventHandler(this.ApplyOrderedList_Click);
            // 
            // ApplyBold
            // 
            this.ApplyBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBold.Location = new System.Drawing.Point(1, 0);
            this.ApplyBold.Name = "ApplyBold";
            this.ApplyBold.Size = new System.Drawing.Size(23, 23);
            this.ApplyBold.TabIndex = 12;
            this.ApplyBold.TabStop = false;
            this.ApplyBold.Text = "B";
            this.ApplyBold.UseVisualStyleBackColor = true;
            this.ApplyBold.Click += new System.EventHandler(this.ApplyBold_Click);
            // 
            // ApplyUnorderedList
            // 
            this.ApplyUnorderedList.Image = global::nedprod.Resource1.unorderedlist;
            this.ApplyUnorderedList.Location = new System.Drawing.Point(153, 0);
            this.ApplyUnorderedList.Name = "ApplyUnorderedList";
            this.ApplyUnorderedList.Size = new System.Drawing.Size(23, 23);
            this.ApplyUnorderedList.TabIndex = 18;
            this.ApplyUnorderedList.UseVisualStyleBackColor = true;
            this.ApplyUnorderedList.Click += new System.EventHandler(this.ApplyUnorderedList_Click);
            // 
            // ApplyItalics
            // 
            this.ApplyItalics.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyItalics.Location = new System.Drawing.Point(24, 0);
            this.ApplyItalics.Name = "ApplyItalics";
            this.ApplyItalics.Size = new System.Drawing.Size(23, 23);
            this.ApplyItalics.TabIndex = 13;
            this.ApplyItalics.Text = "I";
            this.ApplyItalics.UseVisualStyleBackColor = true;
            this.ApplyItalics.Click += new System.EventHandler(this.ApplyItalics_Click);
            // 
            // ApplyAlignJustify
            // 
            this.ApplyAlignJustify.Image = global::nedprod.Resource1.alignjustified;
            this.ApplyAlignJustify.Location = new System.Drawing.Point(124, 0);
            this.ApplyAlignJustify.Name = "ApplyAlignJustify";
            this.ApplyAlignJustify.Size = new System.Drawing.Size(23, 23);
            this.ApplyAlignJustify.TabIndex = 17;
            this.ApplyAlignJustify.UseVisualStyleBackColor = true;
            this.ApplyAlignJustify.Click += new System.EventHandler(this.ApplyAlignJustify_Click);
            // 
            // ApplyAlignLeft
            // 
            this.ApplyAlignLeft.Image = global::nedprod.Resource1.alignleft;
            this.ApplyAlignLeft.Location = new System.Drawing.Point(55, 0);
            this.ApplyAlignLeft.Name = "ApplyAlignLeft";
            this.ApplyAlignLeft.Size = new System.Drawing.Size(23, 23);
            this.ApplyAlignLeft.TabIndex = 14;
            this.ApplyAlignLeft.UseVisualStyleBackColor = true;
            this.ApplyAlignLeft.Click += new System.EventHandler(this.ApplyAlignLeft_Click);
            // 
            // ApplyAlignRight
            // 
            this.ApplyAlignRight.Image = global::nedprod.Resource1.alignright;
            this.ApplyAlignRight.Location = new System.Drawing.Point(101, 0);
            this.ApplyAlignRight.Name = "ApplyAlignRight";
            this.ApplyAlignRight.Size = new System.Drawing.Size(23, 23);
            this.ApplyAlignRight.TabIndex = 16;
            this.ApplyAlignRight.UseVisualStyleBackColor = true;
            this.ApplyAlignRight.Click += new System.EventHandler(this.ApplyAlignRight_Click);
            // 
            // ApplyAlignMiddle
            // 
            this.ApplyAlignMiddle.Image = global::nedprod.Resource1.aligncentred;
            this.ApplyAlignMiddle.Location = new System.Drawing.Point(78, 0);
            this.ApplyAlignMiddle.Name = "ApplyAlignMiddle";
            this.ApplyAlignMiddle.Size = new System.Drawing.Size(23, 23);
            this.ApplyAlignMiddle.TabIndex = 15;
            this.ApplyAlignMiddle.UseVisualStyleBackColor = true;
            this.ApplyAlignMiddle.Click += new System.EventHandler(this.ApplyAlignMiddle_Click);
            // 
            // CommentBody
            // 
            this.CommentBody.AllowNavigation = false;
            this.CommentBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentBody.IsWebBrowserContextMenuEnabled = false;
            this.CommentBody.Location = new System.Drawing.Point(6, 35);
            this.CommentBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.CommentBody.Name = "CommentBody";
            this.CommentBody.ScriptErrorsSuppressed = true;
            this.CommentBody.Size = new System.Drawing.Size(410, 120);
            this.CommentBody.TabIndex = 11;
            this.CommentBody.WebBrowserShortcutsEnabled = false;
            this.CommentBody.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.CommentBody_Navigated);
            // 
            // CommentBodyViewRaw
            // 
            this.CommentBodyViewRaw.Controls.Add(this.CommentBodyRaw);
            this.CommentBodyViewRaw.Location = new System.Drawing.Point(4, 22);
            this.CommentBodyViewRaw.Name = "CommentBodyViewRaw";
            this.CommentBodyViewRaw.Padding = new System.Windows.Forms.Padding(3);
            this.CommentBodyViewRaw.Size = new System.Drawing.Size(422, 158);
            this.CommentBodyViewRaw.TabIndex = 1;
            this.CommentBodyViewRaw.Text = "Raw HTML";
            this.CommentBodyViewRaw.UseVisualStyleBackColor = true;
            // 
            // CommentBodyRaw
            // 
            this.CommentBodyRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentBodyRaw.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentBodyRaw.Location = new System.Drawing.Point(4, 7);
            this.CommentBodyRaw.Name = "CommentBodyRaw";
            this.CommentBodyRaw.ReadOnly = true;
            this.CommentBodyRaw.Size = new System.Drawing.Size(412, 138);
            this.CommentBodyRaw.TabIndex = 20;
            this.CommentBodyRaw.Text = "";
            // 
            // CommentBodyViewFile
            // 
            this.CommentBodyViewFile.Controls.Add(this.LoadAttachment);
            this.CommentBodyViewFile.Controls.Add(this.SaveAttachment);
            this.CommentBodyViewFile.Controls.Add(this.DraggableIcon);
            this.CommentBodyViewFile.Location = new System.Drawing.Point(4, 22);
            this.CommentBodyViewFile.Name = "CommentBodyViewFile";
            this.CommentBodyViewFile.Padding = new System.Windows.Forms.Padding(3);
            this.CommentBodyViewFile.Size = new System.Drawing.Size(422, 158);
            this.CommentBodyViewFile.TabIndex = 2;
            this.CommentBodyViewFile.Text = "File";
            this.CommentBodyViewFile.UseVisualStyleBackColor = true;
            // 
            // LoadAttachment
            // 
            this.LoadAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadAttachment.Enabled = false;
            this.LoadAttachment.Location = new System.Drawing.Point(327, 100);
            this.LoadAttachment.Name = "LoadAttachment";
            this.LoadAttachment.Size = new System.Drawing.Size(89, 23);
            this.LoadAttachment.TabIndex = 2;
            this.LoadAttachment.Text = "Load From ...";
            this.LoadAttachment.UseVisualStyleBackColor = true;
            this.LoadAttachment.Click += new System.EventHandler(this.LoadAttachment_Click);
            // 
            // SaveAttachment
            // 
            this.SaveAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAttachment.Location = new System.Drawing.Point(327, 129);
            this.SaveAttachment.Name = "SaveAttachment";
            this.SaveAttachment.Size = new System.Drawing.Size(89, 23);
            this.SaveAttachment.TabIndex = 1;
            this.SaveAttachment.Text = "Save As ...";
            this.SaveAttachment.UseVisualStyleBackColor = true;
            this.SaveAttachment.Click += new System.EventHandler(this.SaveAttachment_Click);
            // 
            // DraggableIcon
            // 
            this.DraggableIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DraggableIcon.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.DraggableIcon.LargeImageList = this.imageList1;
            this.DraggableIcon.Location = new System.Drawing.Point(6, 6);
            this.DraggableIcon.Name = "DraggableIcon";
            this.DraggableIcon.Size = new System.Drawing.Size(315, 146);
            this.DraggableIcon.TabIndex = 0;
            this.DraggableIcon.UseCompatibleStateImageBehavior = false;
            this.DraggableIcon.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.DraggableIcon_ItemDrag);
            this.DraggableIcon.DoubleClick += new System.EventHandler(this.DraggableIcon_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "generic_document.ico");
            this.imageList1.Images.SetKeyName(1, "generic_picture.ico");
            this.imageList1.Images.SetKeyName(2, "zippedFile.ico");
            // 
            // CommentDate
            // 
            this.CommentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentDate.Location = new System.Drawing.Point(266, 3);
            this.CommentDate.Name = "CommentDate";
            this.CommentDate.ReadOnly = true;
            this.CommentDate.Size = new System.Drawing.Size(167, 20);
            this.CommentDate.TabIndex = 15;
            this.CommentDate.Text = "Thu, 28 Jul 2011 00:29:19 +0000";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Author:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Commentary);
            this.groupBox1.Location = new System.Drawing.Point(12, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 348);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commentary:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.ReadOnlyChecked = true;
            // 
            // IssueDetail
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 572);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BoxReporter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.BoxSummary);
            this.Controls.Add(this.BoxStatus);
            this.Controls.Add(this.BoxSeverity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BoxCreated);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BoxAssigned);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoxCreator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxShortName);
            this.Controls.Add(this.BoxUUID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(488, 600);
            this.Name = "IssueDetail";
            this.Text = "Issue Detail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssueDetail_FormClosing);
            this.Load += new System.EventHandler(this.IssueDetail_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.IssueDetail_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.IssueDetail_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssueDetail_KeyDown);
            this.Commentary.Panel1.ResumeLayout(false);
            this.Commentary.Panel2.ResumeLayout(false);
            this.Commentary.Panel2.PerformLayout();
            this.Commentary.ResumeLayout(false);
            this.CommentBodyView.ResumeLayout(false);
            this.CommentBodyViewHTML.ResumeLayout(false);
            this.HTMLEditorControls.ResumeLayout(false);
            this.CommentBodyViewRaw.ResumeLayout(false);
            this.CommentBodyViewFile.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BoxUUID;
        private System.Windows.Forms.TextBox BoxShortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxCreator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxAssigned;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BoxCreated;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox BoxSeverity;
        private System.Windows.Forms.ComboBox BoxStatus;
        private System.Windows.Forms.TextBox BoxSummary;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.TextBox BoxReporter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer Commentary;
        private System.Windows.Forms.TreeView Comments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser CommentBody;
        private System.Windows.Forms.TextBox CommentDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox CommentAuthor;
        private System.Windows.Forms.Button CommentEdit;
        private System.Windows.Forms.Button CommentDelete;
        private System.Windows.Forms.Button CommentAdd;
        private System.Windows.Forms.Button ApplyBold;
        private System.Windows.Forms.TabControl CommentBodyView;
        private System.Windows.Forms.TabPage CommentBodyViewHTML;
        private System.Windows.Forms.TabPage CommentBodyViewRaw;
        private System.Windows.Forms.RichTextBox CommentBodyRaw;
        private System.Windows.Forms.Button ApplyOrderedList;
        private System.Windows.Forms.Button ApplyUnorderedList;
        private System.Windows.Forms.Button ApplyAlignJustify;
        private System.Windows.Forms.Button ApplyAlignRight;
        private System.Windows.Forms.Button ApplyAlignMiddle;
        private System.Windows.Forms.Button ApplyAlignLeft;
        private System.Windows.Forms.Button ApplyItalics;
        private System.Windows.Forms.Panel HTMLEditorControls;
        private System.Windows.Forms.TabPage CommentBodyViewFile;
        private System.Windows.Forms.Button LoadAttachment;
        private System.Windows.Forms.Button SaveAttachment;
        private System.Windows.Forms.ListView DraggableIcon;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button ApplyOutdent;
        private System.Windows.Forms.Button ApplyIndent;
        private System.Windows.Forms.Button CommentEditCancel;
    }
}