﻿namespace RSSFeedReader
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBarMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEditCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstBoxFeed = new System.Windows.Forms.ListBox();
            this.lblFeed = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstBoxFeedItems = new System.Windows.Forms.ListBox();
            this.lblItemListBox = new System.Windows.Forms.Label();
            this.cbFeedCategoryFilter = new System.Windows.Forms.ComboBox();
            this.wbRssFeed = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBarMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBarMenuButton
            // 
            this.menuBarMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewFeedToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemEditCategories,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuBarMenuButton.Name = "menuBarMenuButton";
            this.menuBarMenuButton.Size = new System.Drawing.Size(50, 20);
            this.menuBarMenuButton.Text = "Menu";
            // 
            // addNewFeedToolStripMenuItem
            // 
            this.addNewFeedToolStripMenuItem.Name = "addNewFeedToolStripMenuItem";
            this.addNewFeedToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addNewFeedToolStripMenuItem.Text = "Add new feed";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleName = "";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            this.toolStripSeparator1.Tag = "";
            // 
            // toolStripMenuItemEditCategories
            // 
            this.toolStripMenuItemEditCategories.Name = "toolStripMenuItemEditCategories";
            this.toolStripMenuItemEditCategories.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemEditCategories.Text = "Edit categories";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleName = "";
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            this.toolStripMenuItem1.Tag = "";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // lstBoxFeed
            // 
            this.lstBoxFeed.FormattingEnabled = true;
            this.lstBoxFeed.HorizontalScrollbar = true;
            this.lstBoxFeed.Location = new System.Drawing.Point(12, 81);
            this.lstBoxFeed.Name = "lstBoxFeed";
            this.lstBoxFeed.Size = new System.Drawing.Size(176, 186);
            this.lstBoxFeed.TabIndex = 1;
            // 
            // lblFeed
            // 
            this.lblFeed.AutoSize = true;
            this.lblFeed.Location = new System.Drawing.Point(12, 41);
            this.lblFeed.Name = "lblFeed";
            this.lblFeed.Size = new System.Drawing.Size(36, 13);
            this.lblFeed.TabIndex = 2;
            this.lblFeed.Text = "Feeds";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(140, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lstBoxFeedItems
            // 
            this.lstBoxFeedItems.FormattingEnabled = true;
            this.lstBoxFeedItems.Location = new System.Drawing.Point(196, 57);
            this.lstBoxFeedItems.Name = "lstBoxFeedItems";
            this.lstBoxFeedItems.Size = new System.Drawing.Size(188, 537);
            this.lstBoxFeedItems.TabIndex = 6;
            // 
            // lblItemListBox
            // 
            this.lblItemListBox.AutoSize = true;
            this.lblItemListBox.Location = new System.Drawing.Point(196, 40);
            this.lblItemListBox.Name = "lblItemListBox";
            this.lblItemListBox.Size = new System.Drawing.Size(32, 13);
            this.lblItemListBox.TabIndex = 7;
            this.lblItemListBox.Text = "Items";
            // 
            // cbFeedCategoryFilter
            // 
            this.cbFeedCategoryFilter.FormattingEnabled = true;
            this.cbFeedCategoryFilter.Location = new System.Drawing.Point(12, 57);
            this.cbFeedCategoryFilter.Name = "cbFeedCategoryFilter";
            this.cbFeedCategoryFilter.Size = new System.Drawing.Size(176, 21);
            this.cbFeedCategoryFilter.TabIndex = 8;
            // 
            // wbRssFeed
            // 
            this.wbRssFeed.Location = new System.Drawing.Point(391, 57);
            this.wbRssFeed.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRssFeed.Name = "wbRssFeed";
            this.wbRssFeed.Size = new System.Drawing.Size(682, 538);
            this.wbRssFeed.TabIndex = 9;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 607);
            this.Controls.Add(this.wbRssFeed);
            this.Controls.Add(this.cbFeedCategoryFilter);
            this.Controls.Add(this.lblItemListBox);
            this.Controls.Add(this.lstBoxFeedItems);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblFeed);
            this.Controls.Add(this.lstBoxFeed);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "MainView";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBarMenuButton;
        private System.Windows.Forms.ToolStripMenuItem addNewFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstBoxFeed;
        private System.Windows.Forms.Label lblFeed;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstBoxFeedItems;
        private System.Windows.Forms.Label lblItemListBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditCategories;
        private System.Windows.Forms.ComboBox cbFeedCategoryFilter;
        private System.Windows.Forms.WebBrowser wbRssFeed;
    }

}

