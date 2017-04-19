namespace Lender_Administration
{
    partial class MainAdminWindow
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
            this.lenderList = new System.Windows.Forms.ComboBox();
            this.lenderListLabel = new System.Windows.Forms.Label();
            this.userDisplayGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.userDisplayGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lenderList
            // 
            this.lenderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lenderList.FormattingEnabled = true;
            this.lenderList.Location = new System.Drawing.Point(13, 41);
            this.lenderList.Name = "lenderList";
            this.lenderList.Size = new System.Drawing.Size(259, 21);
            this.lenderList.TabIndex = 0;
            this.lenderList.SelectedIndexChanged += LenderList_SelectedIndexChanged;
            // 
            // lenderListLabel
            // 
            this.lenderListLabel.AutoSize = true;
            this.lenderListLabel.Location = new System.Drawing.Point(12, 25);
            this.lenderListLabel.Name = "lenderListLabel";
            this.lenderListLabel.Size = new System.Drawing.Size(78, 13);
            this.lenderListLabel.TabIndex = 1;
            this.lenderListLabel.Text = "Select a lender";
            // 
            // userDisplayGrid
            // 
            this.userDisplayGrid.AllowUserToAddRows = false;
            this.userDisplayGrid.AllowUserToDeleteRows = false;
            this.userDisplayGrid.AllowUserToOrderColumns = true;
            this.userDisplayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDisplayGrid.Location = new System.Drawing.Point(12, 68);
            this.userDisplayGrid.Name = "userDisplayGrid";
            this.userDisplayGrid.ReadOnly = true;
            this.userDisplayGrid.Size = new System.Drawing.Size(260, 181);
            this.userDisplayGrid.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editCtrlToolStripMenuItem,
            this.deleteAltToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenderToolStripMenuItem,
            this.userToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.addToolStripMenuItem.Text = "Add...(Ctrl+Shift)";
            // 
            // lenderToolStripMenuItem
            // 
            this.lenderToolStripMenuItem.Name = "lenderToolStripMenuItem";
            this.lenderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.lenderToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.lenderToolStripMenuItem.Text = "Lender";
            this.lenderToolStripMenuItem.Click += new System.EventHandler(this.addLenderToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.userToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // editCtrlToolStripMenuItem
            // 
            this.editCtrlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenderToolStripMenuItem2,
            this.userToolStripMenuItem2});
            this.editCtrlToolStripMenuItem.Name = "editCtrlToolStripMenuItem";
            this.editCtrlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.editCtrlToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.editCtrlToolStripMenuItem.Text = "Edit...(Ctrl)";
            // 
            // lenderToolStripMenuItem2
            // 
            this.lenderToolStripMenuItem2.Name = "lenderToolStripMenuItem2";
            this.lenderToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.lenderToolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.lenderToolStripMenuItem2.Text = "Lender";
            this.lenderToolStripMenuItem2.Click += new System.EventHandler(this.editLenderToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem2
            // 
            this.userToolStripMenuItem2.Name = "userToolStripMenuItem2";
            this.userToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.userToolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.userToolStripMenuItem2.Text = "User";
            this.userToolStripMenuItem2.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // deleteAltToolStripMenuItem
            // 
            this.deleteAltToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenderToolStripMenuItem1,
            this.userToolStripMenuItem1});
            this.deleteAltToolStripMenuItem.Name = "deleteAltToolStripMenuItem";
            this.deleteAltToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.deleteAltToolStripMenuItem.Text = "Delete...(Alt)";
            // 
            // lenderToolStripMenuItem1
            // 
            this.lenderToolStripMenuItem1.Name = "lenderToolStripMenuItem1";
            this.lenderToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lenderToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.lenderToolStripMenuItem1.Text = "Lender";
            this.lenderToolStripMenuItem1.Click += new System.EventHandler(this.deleteLenderToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem1
            // 
            this.userToolStripMenuItem1.Name = "userToolStripMenuItem1";
            this.userToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.userToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.userToolStripMenuItem1.Text = "User";
            this.userToolStripMenuItem1.Click += new System.EventHandler(this.deleteUserToolStripMenuItem_Click);
            // 
            // MainAdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.userDisplayGrid);
            this.Controls.Add(this.lenderListLabel);
            this.Controls.Add(this.lenderList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainAdminWindow";
            this.Text = "Lender Administration";
            this.Icon = Properties.Resources.Admin;
            ((System.ComponentModel.ISupportInitialize)(this.userDisplayGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lenderList;
        private System.Windows.Forms.Label lenderListLabel;
        private System.Windows.Forms.DataGridView userDisplayGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteAltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem1;
    }
}