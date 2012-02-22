namespace BEurtle
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.Link_nedproductions = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckFilterOutClosedIssues = new System.Windows.Forms.CheckBox();
            this.CheckAddCommitAsComment = new System.Windows.Forms.CheckBox();
            this.BoxDumpHTMLPath = new System.Windows.Forms.TextBox();
            this.CheckDumpHTML = new System.Windows.Forms.CheckBox();
            this.BoxBEPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LinkGithubIssues = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.LinkHomepage = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.LinkDonate = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "BEurtle v1.02";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Link_nedproductions
            // 
            this.Link_nedproductions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Link_nedproductions.Location = new System.Drawing.Point(201, 116);
            this.Link_nedproductions.Name = "Link_nedproductions";
            this.Link_nedproductions.Size = new System.Drawing.Size(151, 29);
            this.Link_nedproductions.TabIndex = 0;
            this.Link_nedproductions.TabStop = true;
            this.Link_nedproductions.Text = "(C) 2011-2012 Niall Douglas, ned Productions Limited";
            this.Link_nedproductions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Link_nedproductions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_nedproductions_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BE Path:";
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.Controls.Add(this.CheckFilterOutClosedIssues);
            this.OptionsGroupBox.Controls.Add(this.CheckAddCommitAsComment);
            this.OptionsGroupBox.Controls.Add(this.BoxDumpHTMLPath);
            this.OptionsGroupBox.Controls.Add(this.CheckDumpHTML);
            this.OptionsGroupBox.Controls.Add(this.BoxBEPath);
            this.OptionsGroupBox.Controls.Add(this.label2);
            this.OptionsGroupBox.Location = new System.Drawing.Point(13, 148);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(339, 142);
            this.OptionsGroupBox.TabIndex = 3;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options:";
            // 
            // CheckFilterOutClosedIssues
            // 
            this.CheckFilterOutClosedIssues.AutoSize = true;
            this.CheckFilterOutClosedIssues.Location = new System.Drawing.Point(6, 118);
            this.CheckFilterOutClosedIssues.Name = "CheckFilterOutClosedIssues";
            this.CheckFilterOutClosedIssues.Size = new System.Drawing.Size(192, 17);
            this.CheckFilterOutClosedIssues.TabIndex = 5;
            this.CheckFilterOutClosedIssues.Text = "Default to filtering out closed issues";
            this.CheckFilterOutClosedIssues.UseVisualStyleBackColor = true;
            // 
            // CheckAddCommitAsComment
            // 
            this.CheckAddCommitAsComment.AutoSize = true;
            this.CheckAddCommitAsComment.Location = new System.Drawing.Point(6, 95);
            this.CheckAddCommitAsComment.Name = "CheckAddCommitAsComment";
            this.CheckAddCommitAsComment.Size = new System.Drawing.Size(254, 17);
            this.CheckAddCommitAsComment.TabIndex = 4;
            this.CheckAddCommitAsComment.Text = "Add commit id as comment to auto-closed issues";
            this.CheckAddCommitAsComment.UseVisualStyleBackColor = true;
            // 
            // BoxDumpHTMLPath
            // 
            this.BoxDumpHTMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxDumpHTMLPath.Location = new System.Drawing.Point(62, 69);
            this.BoxDumpHTMLPath.Name = "BoxDumpHTMLPath";
            this.BoxDumpHTMLPath.Size = new System.Drawing.Size(271, 20);
            this.BoxDumpHTMLPath.TabIndex = 3;
            this.BoxDumpHTMLPath.TextChanged += new System.EventHandler(this.BoxDumpHTMLPath_TextChanged);
            // 
            // CheckDumpHTML
            // 
            this.CheckDumpHTML.AutoSize = true;
            this.CheckDumpHTML.Location = new System.Drawing.Point(6, 45);
            this.CheckDumpHTML.Name = "CheckDumpHTML";
            this.CheckDumpHTML.Size = new System.Drawing.Size(190, 17);
            this.CheckDumpHTML.TabIndex = 2;
            this.CheckDumpHTML.Text = "Always dump HTML on change to:";
            this.CheckDumpHTML.UseVisualStyleBackColor = true;
            // 
            // BoxBEPath
            // 
            this.BoxBEPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxBEPath.Location = new System.Drawing.Point(62, 19);
            this.BoxBEPath.Name = "BoxBEPath";
            this.BoxBEPath.Size = new System.Drawing.Size(271, 20);
            this.BoxBEPath.TabIndex = 1;
            this.BoxBEPath.TextChanged += new System.EventHandler(this.BoxBEPath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Found a bug?";
            // 
            // LinkGithubIssues
            // 
            this.LinkGithubIssues.AutoSize = true;
            this.LinkGithubIssues.Location = new System.Drawing.Point(95, 302);
            this.LinkGithubIssues.Name = "LinkGithubIssues";
            this.LinkGithubIssues.Size = new System.Drawing.Size(159, 13);
            this.LinkGithubIssues.TabIndex = 6;
            this.LinkGithubIssues.TabStop = true;
            this.LinkGithubIssues.Text = "Check/Report Issues on GitHub";
            this.LinkGithubIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGithubIssues_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Homepage:";
            // 
            // LinkHomepage
            // 
            this.LinkHomepage.AutoSize = true;
            this.LinkHomepage.Location = new System.Drawing.Point(95, 319);
            this.LinkHomepage.Name = "LinkHomepage";
            this.LinkHomepage.Size = new System.Drawing.Size(255, 13);
            this.LinkHomepage.TabIndex = 7;
            this.LinkHomepage.TabStop = true;
            this.LinkHomepage.Text = "http://www.nedprod.com/programs/Win32/BEurtle/";
            this.LinkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHomepage_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(281, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Did this plugin improve your life? If so, please DONATE at:";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(277, 527);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 11;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(196, 527);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 10;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(115, 527);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 9;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // LinkDonate
            // 
            this.LinkDonate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkDonate.Image = global::nedprod.Resource1.Paypal;
            this.LinkDonate.Location = new System.Drawing.Point(12, 366);
            this.LinkDonate.Name = "LinkDonate";
            this.LinkDonate.Size = new System.Drawing.Size(340, 158);
            this.LinkDonate.TabIndex = 8;
            this.LinkDonate.TabStop = true;
            this.LinkDonate.Text = "Buy Niall a coffee or beer to thank him for his work";
            this.LinkDonate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LinkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDonate_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::nedprod.Resource1.bugseverwhere;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.LinkDonate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LinkHomepage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LinkGithubIssues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.Link_nedproductions);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(32768, 600);
            this.MinimumSize = new System.Drawing.Size(380, 600);
            this.Name = "OptionsDialog";
            this.Text = "BEurtle Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsDialog_FormClosing);
            this.Shown += new System.EventHandler(this.OptionsDialog_Shown);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel Link_nedproductions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.TextBox BoxDumpHTMLPath;
        private System.Windows.Forms.CheckBox CheckDumpHTML;
        private System.Windows.Forms.TextBox BoxBEPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel LinkGithubIssues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel LinkHomepage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel LinkDonate;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.CheckBox CheckAddCommitAsComment;
        private System.Windows.Forms.CheckBox CheckFilterOutClosedIssues;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}