namespace User.Feedback.Client.Views.ViewMessages
{
    partial class ViewMessagesForm
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
            this.getMessagesButton = new System.Windows.Forms.Button();
            this.userFeedbackDataGridView = new System.Windows.Forms.DataGridView();
            this.userFeedbackBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userFeedbackDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userFeedbackBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // getMessagesButton
            // 
            this.getMessagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getMessagesButton.Location = new System.Drawing.Point(395, 262);
            this.getMessagesButton.Name = "getMessagesButton";
            this.getMessagesButton.Size = new System.Drawing.Size(100, 23);
            this.getMessagesButton.TabIndex = 2;
            this.getMessagesButton.Text = "&Get Messages";
            this.getMessagesButton.UseVisualStyleBackColor = true;
            // 
            // userFeedbackDataGridView
            // 
            this.userFeedbackDataGridView.AllowUserToAddRows = false;
            this.userFeedbackDataGridView.AllowUserToDeleteRows = false;
            this.userFeedbackDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userFeedbackDataGridView.AutoGenerateColumns = false;
            this.userFeedbackDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userFeedbackDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageDataGridViewTextBoxColumn,
            this.createdDataGridViewTextBoxColumn});
            this.userFeedbackDataGridView.DataSource = this.userFeedbackBindingSource;
            this.userFeedbackDataGridView.Location = new System.Drawing.Point(12, 12);
            this.userFeedbackDataGridView.Name = "userFeedbackDataGridView";
            this.userFeedbackDataGridView.ReadOnly = true;
            this.userFeedbackDataGridView.Size = new System.Drawing.Size(483, 244);
            this.userFeedbackDataGridView.TabIndex = 3;
            // 
            // userFeedbackBindingSource
            // 
            this.userFeedbackBindingSource.DataSource = typeof(User.Feedback.Common.UserFeedback);
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Width = 200;
            // 
            // createdDataGridViewTextBoxColumn
            // 
            this.createdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.createdDataGridViewTextBoxColumn.DataPropertyName = "Created";
            this.createdDataGridViewTextBoxColumn.HeaderText = "Created";
            this.createdDataGridViewTextBoxColumn.Name = "createdDataGridViewTextBoxColumn";
            this.createdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ViewMessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 297);
            this.Controls.Add(this.userFeedbackDataGridView);
            this.Controls.Add(this.getMessagesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewMessagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Messages";
            ((System.ComponentModel.ISupportInitialize)(this.userFeedbackDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userFeedbackBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getMessagesButton;
        private System.Windows.Forms.DataGridView userFeedbackDataGridView;
        private System.Windows.Forms.BindingSource userFeedbackBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDataGridViewTextBoxColumn;
    }
}