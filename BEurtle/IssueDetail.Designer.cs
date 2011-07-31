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
            this.Commentary = new System.Windows.Forms.WebBrowser();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BoxReporter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Commentary
            // 
            this.Commentary.AllowNavigation = false;
            this.Commentary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Commentary.Location = new System.Drawing.Point(6, 19);
            this.Commentary.MinimumSize = new System.Drawing.Size(20, 20);
            this.Commentary.Name = "Commentary";
            this.Commentary.Size = new System.Drawing.Size(436, 163);
            this.Commentary.TabIndex = 6;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(384, 13);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 7;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(383, 43);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 8;
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
            this.BoxCreator.Location = new System.Drawing.Point(82, 65);
            this.BoxCreator.Name = "BoxCreator";
            this.BoxCreator.Size = new System.Drawing.Size(295, 20);
            this.BoxCreator.TabIndex = 0;
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
            this.BoxAssigned.Location = new System.Drawing.Point(82, 117);
            this.BoxAssigned.Name = "BoxAssigned";
            this.BoxAssigned.Size = new System.Drawing.Size(295, 20);
            this.BoxAssigned.TabIndex = 2;
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
            this.ButtonEdit.TabIndex = 9;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Commentary);
            this.groupBox1.Location = new System.Drawing.Point(12, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 188);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commentary:";
            // 
            // BoxReporter
            // 
            this.BoxReporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxReporter.Location = new System.Drawing.Point(82, 91);
            this.BoxReporter.Name = "BoxReporter";
            this.BoxReporter.Size = new System.Drawing.Size(295, 20);
            this.BoxReporter.TabIndex = 1;
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
            // IssueDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 412);
            this.Controls.Add(this.BoxReporter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
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
            this.MinimumSize = new System.Drawing.Size(488, 320);
            this.Name = "IssueDetail";
            this.Text = "IssueDetail";
            this.Shown += new System.EventHandler(this.IssueDetail_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser Commentary;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox BoxReporter;
        private System.Windows.Forms.Label label9;
    }
}