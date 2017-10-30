namespace RSSFeedReader.ui
{
    partial class AddFeedPopup
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
            this.lblFedName = new System.Windows.Forms.Label();
            this.lblAddFeedUrl = new System.Windows.Forms.Label();
            this.tbFeedName = new System.Windows.Forms.TextBox();
            this.tbFeedUrl = new System.Windows.Forms.TextBox();
            this.btnCancelFeedAdd = new System.Windows.Forms.Button();
            this.btnConfirmAddFeed = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbUpdateFrequency = new System.Windows.Forms.TextBox();
            this.lblUpdateFrequency = new System.Windows.Forms.Label();
            this.cbUpdateFrequency = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblFedName
            // 
            this.lblFedName.AutoSize = true;
            this.lblFedName.Location = new System.Drawing.Point(12, 9);
            this.lblFedName.Name = "lblFedName";
            this.lblFedName.Size = new System.Drawing.Size(35, 13);
            this.lblFedName.TabIndex = 0;
            this.lblFedName.Text = "Name";
            // 
            // lblAddFeedUrl
            // 
            this.lblAddFeedUrl.AutoSize = true;
            this.lblAddFeedUrl.Location = new System.Drawing.Point(12, 48);
            this.lblAddFeedUrl.Name = "lblAddFeedUrl";
            this.lblAddFeedUrl.Size = new System.Drawing.Size(29, 13);
            this.lblAddFeedUrl.TabIndex = 1;
            this.lblAddFeedUrl.Text = "URL";
            // 
            // tbFeedName
            // 
            this.tbFeedName.Location = new System.Drawing.Point(15, 25);
            this.tbFeedName.Name = "tbFeedName";
            this.tbFeedName.Size = new System.Drawing.Size(413, 20);
            this.tbFeedName.TabIndex = 2;
            // 
            // tbFeedUrl
            // 
            this.tbFeedUrl.Location = new System.Drawing.Point(15, 64);
            this.tbFeedUrl.Name = "tbFeedUrl";
            this.tbFeedUrl.Size = new System.Drawing.Size(413, 20);
            this.tbFeedUrl.TabIndex = 3;
            // 
            // btnCancelFeedAdd
            // 
            this.btnCancelFeedAdd.Location = new System.Drawing.Point(272, 182);
            this.btnCancelFeedAdd.Name = "btnCancelFeedAdd";
            this.btnCancelFeedAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCancelFeedAdd.TabIndex = 4;
            this.btnCancelFeedAdd.Text = "Cancel";
            this.btnCancelFeedAdd.UseVisualStyleBackColor = true;
            // 
            // btnConfirmAddFeed
            // 
            this.btnConfirmAddFeed.Location = new System.Drawing.Point(353, 182);
            this.btnConfirmAddFeed.Name = "btnConfirmAddFeed";
            this.btnConfirmAddFeed.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmAddFeed.TabIndex = 5;
            this.btnConfirmAddFeed.Text = "Add";
            this.btnConfirmAddFeed.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 87);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(15, 104);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(413, 21);
            this.cbCategory.TabIndex = 7;
            // 
            // tbUpdateFrequency
            // 
            this.tbUpdateFrequency.Location = new System.Drawing.Point(15, 144);
            this.tbUpdateFrequency.Name = "tbUpdateFrequency";
            this.tbUpdateFrequency.Size = new System.Drawing.Size(286, 20);
            this.tbUpdateFrequency.TabIndex = 8;
            // 
            // lblUpdateFrequency
            // 
            this.lblUpdateFrequency.AutoSize = true;
            this.lblUpdateFrequency.Location = new System.Drawing.Point(12, 128);
            this.lblUpdateFrequency.Name = "lblUpdateFrequency";
            this.lblUpdateFrequency.Size = new System.Drawing.Size(92, 13);
            this.lblUpdateFrequency.TabIndex = 9;
            this.lblUpdateFrequency.Text = "Update frequency";
            // 
            // cbUpdateFrequency
            // 
            this.cbUpdateFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdateFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbUpdateFrequency.FormattingEnabled = true;
            this.cbUpdateFrequency.Location = new System.Drawing.Point(307, 143);
            this.cbUpdateFrequency.Name = "cbUpdateFrequency";
            this.cbUpdateFrequency.Size = new System.Drawing.Size(121, 21);
            this.cbUpdateFrequency.TabIndex = 10;
            // 
            // AddFeedPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 217);
            this.Controls.Add(this.cbUpdateFrequency);
            this.Controls.Add(this.lblUpdateFrequency);
            this.Controls.Add(this.tbUpdateFrequency);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnConfirmAddFeed);
            this.Controls.Add(this.btnCancelFeedAdd);
            this.Controls.Add(this.tbFeedUrl);
            this.Controls.Add(this.tbFeedName);
            this.Controls.Add(this.lblAddFeedUrl);
            this.Controls.Add(this.lblFedName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddFeedPopup";
            this.Text = "Add new feed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFedName;
        private System.Windows.Forms.Label lblAddFeedUrl;
        private System.Windows.Forms.TextBox tbFeedName;
        private System.Windows.Forms.TextBox tbFeedUrl;
        private System.Windows.Forms.Button btnCancelFeedAdd;
        private System.Windows.Forms.Button btnConfirmAddFeed;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbUpdateFrequency;
        private System.Windows.Forms.Label lblUpdateFrequency;
        private System.Windows.Forms.ComboBox cbUpdateFrequency;
    }
}