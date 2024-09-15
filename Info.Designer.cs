namespace EdgeMon
{
    partial class Info
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.ConfigGrid = new System.Windows.Forms.DataGridView();
            this.resetbutton = new System.Windows.Forms.Button();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfigGrid
            // 
            this.ConfigGrid.AllowUserToAddRows = false;
            this.ConfigGrid.AllowUserToDeleteRows = false;
            this.ConfigGrid.AllowUserToOrderColumns = true;
            this.ConfigGrid.AllowUserToResizeColumns = false;
            this.ConfigGrid.AllowUserToResizeRows = false;
            this.ConfigGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ConfigGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfigGrid.Location = new System.Drawing.Point(3, 191);
            this.ConfigGrid.Name = "ConfigGrid";
            this.ConfigGrid.RowHeadersWidth = 51;
            this.ConfigGrid.RowTemplate.Height = 24;
            this.ConfigGrid.Size = new System.Drawing.Size(602, 389);
            this.ConfigGrid.TabIndex = 28;
            this.ConfigGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ConfigGrid_CellValidating);
            this.ConfigGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConfigGrid_CellValueChanged);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(270, 622);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(175, 32);
            this.resetbutton.TabIndex = 29;
            this.resetbutton.Text = "RESET SETTINGS";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // bt_accept
            // 
            this.bt_accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_accept.Location = new System.Drawing.Point(133, 622);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(131, 32);
            this.bt_accept.TabIndex = 31;
            this.bt_accept.Text = "CLOSE";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(15, 622);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(112, 32);
            this.bt_cancel.TabIndex = 30;
            this.bt_cancel.Text = "CANCEL";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(12, 11);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(592, 21);
            this.labelProductName.TabIndex = 32;
            this.labelProductName.Text = "EdgeMon";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 41);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(67, 16);
            this.labelVersion.TabIndex = 33;
            this.labelVersion.Text = "VERSION";
            this.labelVersion.Click += new System.EventHandler(this.labelVersion_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(12, 66);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(64, 16);
            this.labelCopyright.TabIndex = 34;
            this.labelCopyright.Text = "Copyright";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Location = new System.Drawing.Point(15, 93);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(95, 16);
            this.labelCompanyName.TabIndex = 36;
            this.labelCompanyName.Text = "labelCompany";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AutoSize = true;
            this.textBoxDescription.Location = new System.Drawing.Point(15, 146);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(37, 16);
            this.textBoxDescription.TabIndex = 37;
            this.textBoxDescription.Text = "desc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(364, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(616, 669);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.ConfigGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Shown += new System.EventHandler(this.Info_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ConfigGrid;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label textBoxDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
