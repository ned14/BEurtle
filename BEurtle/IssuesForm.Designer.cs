namespace BEurtle
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
            this.IssuesList = new System.Windows.Forms.DataGridView();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BERepoLocation = new System.Windows.Forms.TextBox();
            this.NewIssue = new System.Windows.Forms.Button();
            this.DeleteIssue = new System.Windows.Forms.Button();
            this.BERepoLocationBrowse = new System.Windows.Forms.Button();
            this.BoxStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesList)).BeginInit();
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
            this.Summary});
            this.IssuesList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.IssuesList.Location = new System.Drawing.Point(16, 41);
            this.IssuesList.Name = "IssuesList";
            this.IssuesList.ReadOnly = true;
            this.IssuesList.RowHeadersVisible = false;
            this.IssuesList.RowTemplate.ReadOnly = true;
            this.IssuesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IssuesList.Size = new System.Drawing.Size(600, 360);
            this.IssuesList.TabIndex = 0;
            this.IssuesList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IssuesList_CellDoubleClick);
            this.IssuesList.SelectionChanged += new System.EventHandler(this.IssuesList_SelectionChanged);
            this.IssuesList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.IssuesList_SortCompare);
            this.IssuesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssuesList_KeyDown);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(537, 407);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 5;
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
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path/URL:";
            // 
            // BERepoLocation
            // 
            this.BERepoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BERepoLocation.Location = new System.Drawing.Point(77, 14);
            this.BERepoLocation.Name = "BERepoLocation";
            this.BERepoLocation.Size = new System.Drawing.Size(454, 20);
            this.BERepoLocation.TabIndex = 6;
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
            this.BERepoLocationBrowse.Location = new System.Drawing.Point(537, 12);
            this.BERepoLocationBrowse.Name = "BERepoLocationBrowse";
            this.BERepoLocationBrowse.Size = new System.Drawing.Size(75, 23);
            this.BERepoLocationBrowse.TabIndex = 7;
            this.BERepoLocationBrowse.Text = "Browse";
            this.BERepoLocationBrowse.UseVisualStyleBackColor = true;
            this.BERepoLocationBrowse.Click += new System.EventHandler(this.BERepoLocationBrowse_Click);
            // 
            // BoxStatus
            // 
            this.BoxStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BoxStatus.FormattingEnabled = true;
            this.BoxStatus.Items.AddRange(new object[] {
            "",
            "unconfirmed",
            "open",
            "assigned",
            "test",
            "closed",
            "fixed",
            "wontfix"});
            this.BoxStatus.Location = new System.Drawing.Point(277, 409);
            this.BoxStatus.Name = "BoxStatus";
            this.BoxStatus.Size = new System.Drawing.Size(121, 21);
            this.BoxStatus.TabIndex = 3;
            this.BoxStatus.SelectedIndexChanged += new System.EventHandler(this.BoxStatus_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Status:";
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
            // IssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.BoxStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BERepoLocationBrowse);
            this.Controls.Add(this.DeleteIssue);
            this.Controls.Add(this.NewIssue);
            this.Controls.Add(this.BERepoLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.IssuesList);
            this.MinimumSize = new System.Drawing.Size(540, 200);
            this.Name = "IssuesForm";
            this.Text = "Bugs Everywhere Issues";
            this.Shown += new System.EventHandler(this.IssuesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.IssuesList)).EndInit();
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
        private System.Windows.Forms.ComboBox BoxStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
    }
}