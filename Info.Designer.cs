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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ConfigGrid = new System.Windows.Forms.DataGridView();
            this.resetbutton = new System.Windows.Forms.Button();
            this.bt_accept = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.bt_cl = new System.Windows.Forms.Button();
            this.bt_lic = new System.Windows.Forms.Button();
            this.saveFileDialog_screenshot = new System.Windows.Forms.SaveFileDialog();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConfigGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ConfigGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ConfigGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ConfigGrid.Location = new System.Drawing.Point(2, 155);
            this.ConfigGrid.Margin = new System.Windows.Forms.Padding(2);
            this.ConfigGrid.Name = "ConfigGrid";
            this.ConfigGrid.RowHeadersWidth = 51;
            this.ConfigGrid.RowTemplate.Height = 24;
            this.ConfigGrid.Size = new System.Drawing.Size(452, 316);
            this.ConfigGrid.TabIndex = 28;
            this.ConfigGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConfigGrid_CellContentClick);
            this.ConfigGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ConfigGrid_CellFormatting);
            this.ConfigGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ConfigGrid_CellValidating);
            this.ConfigGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConfigGrid_CellValueChanged);
            this.ConfigGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.ConfigGrid_CurrentCellDirtyStateChanged);
            this.ConfigGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ConfigGrid_DataError);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(202, 505);
            this.resetbutton.Margin = new System.Windows.Forms.Padding(2);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(131, 26);
            this.resetbutton.TabIndex = 29;
            this.resetbutton.Text = "RESET SETTINGS";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // bt_accept
            // 
            this.bt_accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_accept.Location = new System.Drawing.Point(100, 505);
            this.bt_accept.Margin = new System.Windows.Forms.Padding(2);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(98, 26);
            this.bt_accept.TabIndex = 31;
            this.bt_accept.Text = "CLOSE";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_cancel.Location = new System.Drawing.Point(11, 505);
            this.bt_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(84, 26);
            this.bt_cancel.TabIndex = 30;
            this.bt_cancel.Text = "CANCEL";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(9, 9);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(444, 17);
            this.labelProductName.TabIndex = 32;
            this.labelProductName.Text = "EdgeMon";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(9, 33);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(55, 13);
            this.labelVersion.TabIndex = 33;
            this.labelVersion.Text = "VERSION";
            this.labelVersion.Click += new System.EventHandler(this.labelVersion_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(9, 54);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(51, 13);
            this.labelCopyright.TabIndex = 34;
            this.labelCopyright.Text = "Copyright";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AutoSize = true;
            this.textBoxDescription.Location = new System.Drawing.Point(11, 91);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(30, 13);
            this.textBoxDescription.TabIndex = 37;
            this.textBoxDescription.Text = "desc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EdgeMon.Properties.Resources.Edgemon;
            this.pictureBox1.Location = new System.Drawing.Point(273, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(11, 72);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(49, 13);
            this.linkLabel.TabIndex = 39;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "linkLabel";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // bt_cl
            // 
            this.bt_cl.BackColor = System.Drawing.Color.DarkGray;
            this.bt_cl.Location = new System.Drawing.Point(202, 33);
            this.bt_cl.Margin = new System.Windows.Forms.Padding(2);
            this.bt_cl.Name = "bt_cl";
            this.bt_cl.Size = new System.Drawing.Size(70, 21);
            this.bt_cl.TabIndex = 40;
            this.bt_cl.Text = "Changelog";
            this.bt_cl.UseVisualStyleBackColor = false;
            this.bt_cl.Click += new System.EventHandler(this.bt_cl_Click);
            // 
            // bt_lic
            // 
            this.bt_lic.BackColor = System.Drawing.Color.DarkGray;
            this.bt_lic.Location = new System.Drawing.Point(202, 59);
            this.bt_lic.Margin = new System.Windows.Forms.Padding(2);
            this.bt_lic.Name = "bt_lic";
            this.bt_lic.Size = new System.Drawing.Size(70, 21);
            this.bt_lic.TabIndex = 41;
            this.bt_lic.Text = "Licenses";
            this.bt_lic.UseVisualStyleBackColor = false;
            this.bt_lic.Click += new System.EventHandler(this.bt_lic_Click);
            // 
            // saveFileDialog_screenshot
            // 
            this.saveFileDialog_screenshot.DefaultExt = "jpg";
            this.saveFileDialog_screenshot.InitialDirectory = "C:\\tmp";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(462, 544);
            this.ControlBox = false;
            this.Controls.Add(this.bt_lic);
            this.Controls.Add(this.bt_cl);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.ConfigGrid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Shown += new System.EventHandler(this.Info_Shown);
            this.VisibleChanged += new System.EventHandler(this.Info_VisibleChanged);
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
        private System.Windows.Forms.Label textBoxDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Button bt_cl;
        private System.Windows.Forms.Button bt_lic;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_screenshot;
    }
}
