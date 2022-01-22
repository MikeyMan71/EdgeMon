
namespace EdgeMon
{
    partial class EdgeMon
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lb_version = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_temp = new System.Windows.Forms.Label();
            this.ImpExMeter = new System.Windows.Forms.TextBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.lb_dc_pwr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_update = new System.Windows.Forms.Label();
            this.lb_ac_pwr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ArrowBox = new System.Windows.Forms.PictureBox();
            this.lb_batt_pwr = new System.Windows.Forms.Label();
            this.lb_bat_stat = new System.Windows.Forms.Label();
            this.bat_SOE = new System.Windows.Forms.ProgressBar();
            this.lb_SOE_TXT = new System.Windows.Forms.Label();
            this.lb_SOH = new System.Windows.Forms.Label();
            this.tb_batManu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_T_Av = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_bat_max = new System.Windows.Forms.Label();
            this.lbl_mtr_manu = new System.Windows.Forms.Label();
            this.lb_mtr_model = new System.Windows.Forms.Label();
            this.lb_mtr_ver = new System.Windows.Forms.Label();
            this.lb_mtr_opt = new System.Windows.Forms.Label();
            this.lb_mtr_sernr = new System.Windows.Forms.Label();
            this.MB_Pwr_3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(803, 81);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 345);
            this.textBox1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(449, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "CPU Version";
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.Location = new System.Drawing.Point(449, 38);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(30, 20);
            this.lb_version.TabIndex = 32;
            this.lb_version.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(500, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "Import/Export";
            // 
            // lb_temp
            // 
            this.lb_temp.AutoSize = true;
            this.lb_temp.BackColor = System.Drawing.Color.IndianRed;
            this.lb_temp.Location = new System.Drawing.Point(335, 232);
            this.lb_temp.Name = "lb_temp";
            this.lb_temp.Size = new System.Drawing.Size(23, 17);
            this.lb_temp.TabIndex = 30;
            this.lb_temp.Text = "---";
            // 
            // ImpExMeter
            // 
            this.ImpExMeter.BackColor = System.Drawing.SystemColors.InfoText;
            this.ImpExMeter.Font = new System.Drawing.Font("Britannic Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImpExMeter.ForeColor = System.Drawing.SystemColors.Window;
            this.ImpExMeter.Location = new System.Drawing.Point(498, 253);
            this.ImpExMeter.Name = "ImpExMeter";
            this.ImpExMeter.Size = new System.Drawing.Size(154, 26);
            this.ImpExMeter.TabIndex = 29;
            this.ImpExMeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.Red;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_status.Location = new System.Drawing.Point(296, 103);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(97, 31);
            this.lb_status.TabIndex = 25;
            this.lb_status.Text = "NONE";
            // 
            // lb_dc_pwr
            // 
            this.lb_dc_pwr.AutoSize = true;
            this.lb_dc_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dc_pwr.Location = new System.Drawing.Point(116, 170);
            this.lb_dc_pwr.Name = "lb_dc_pwr";
            this.lb_dc_pwr.Size = new System.Drawing.Size(84, 25);
            this.lb_dc_pwr.TabIndex = 23;
            this.lb_dc_pwr.Text = "000000";
            this.lb_dc_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Last Update";
            // 
            // lb_update
            // 
            this.lb_update.AutoSize = true;
            this.lb_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_update.Location = new System.Drawing.Point(155, 9);
            this.lb_update.Name = "lb_update";
            this.lb_update.Size = new System.Drawing.Size(69, 20);
            this.lb_update.TabIndex = 21;
            this.lb_update.Text = "000000";
            // 
            // lb_ac_pwr
            // 
            this.lb_ac_pwr.AutoSize = true;
            this.lb_ac_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ac_pwr.Location = new System.Drawing.Point(529, 170);
            this.lb_ac_pwr.Name = "lb_ac_pwr";
            this.lb_ac_pwr.Size = new System.Drawing.Size(84, 25);
            this.lb_ac_pwr.TabIndex = 20;
            this.lb_ac_pwr.Text = "000000";
            this.lb_ac_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EdgeMon.Properties.Resources.SE11;
            this.pictureBox1.Location = new System.Drawing.Point(245, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // ArrowBox
            // 
            this.ArrowBox.Image = global::EdgeMon.Properties.Resources.SE_Arrow;
            this.ArrowBox.Location = new System.Drawing.Point(174, 191);
            this.ArrowBox.Name = "ArrowBox";
            this.ArrowBox.Size = new System.Drawing.Size(65, 188);
            this.ArrowBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArrowBox.TabIndex = 34;
            this.ArrowBox.TabStop = false;
            // 
            // lb_batt_pwr
            // 
            this.lb_batt_pwr.AutoSize = true;
            this.lb_batt_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_batt_pwr.Location = new System.Drawing.Point(84, 276);
            this.lb_batt_pwr.Name = "lb_batt_pwr";
            this.lb_batt_pwr.Size = new System.Drawing.Size(84, 25);
            this.lb_batt_pwr.TabIndex = 35;
            this.lb_batt_pwr.Text = "000000";
            this.lb_batt_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_bat_stat
            // 
            this.lb_bat_stat.AutoSize = true;
            this.lb_bat_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_stat.Location = new System.Drawing.Point(241, 178);
            this.lb_bat_stat.Name = "lb_bat_stat";
            this.lb_bat_stat.Size = new System.Drawing.Size(102, 20);
            this.lb_bat_stat.TabIndex = 14;
            this.lb_bat_stat.Text = "Bat_Status";
            // 
            // bat_SOE
            // 
            this.bat_SOE.ForeColor = System.Drawing.Color.Lime;
            this.bat_SOE.Location = new System.Drawing.Point(23, 15);
            this.bat_SOE.Name = "bat_SOE";
            this.bat_SOE.Size = new System.Drawing.Size(217, 56);
            this.bat_SOE.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bat_SOE.TabIndex = 15;
            // 
            // lb_SOE_TXT
            // 
            this.lb_SOE_TXT.AutoSize = true;
            this.lb_SOE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOE_TXT.Location = new System.Drawing.Point(257, 33);
            this.lb_SOE_TXT.Name = "lb_SOE_TXT";
            this.lb_SOE_TXT.Size = new System.Drawing.Size(30, 20);
            this.lb_SOE_TXT.TabIndex = 16;
            this.lb_SOE_TXT.Text = "---";
            // 
            // lb_SOH
            // 
            this.lb_SOH.AutoSize = true;
            this.lb_SOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOH.Location = new System.Drawing.Point(297, 142);
            this.lb_SOH.Name = "lb_SOH";
            this.lb_SOH.Size = new System.Drawing.Size(30, 20);
            this.lb_SOH.TabIndex = 17;
            this.lb_SOH.Text = "---";
            // 
            // tb_batManu
            // 
            this.tb_batManu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_batManu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tb_batManu.Location = new System.Drawing.Point(8, 102);
            this.tb_batManu.Multiline = true;
            this.tb_batManu.Name = "tb_batManu";
            this.tb_batManu.Size = new System.Drawing.Size(228, 138);
            this.tb_batManu.TabIndex = 18;
            this.tb_batManu.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "SOH";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lb_T_Av);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lb_bat_max);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tb_batManu);
            this.panel1.Controls.Add(this.lb_SOH);
            this.panel1.Controls.Add(this.lb_SOE_TXT);
            this.panel1.Controls.Add(this.bat_SOE);
            this.panel1.Controls.Add(this.lb_bat_stat);
            this.panel1.Location = new System.Drawing.Point(93, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 269);
            this.panel1.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "T_Av";
            // 
            // lb_T_Av
            // 
            this.lb_T_Av.AutoSize = true;
            this.lb_T_Av.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T_Av.Location = new System.Drawing.Point(297, 102);
            this.lb_T_Av.Name = "lb_T_Av";
            this.lb_T_Av.Size = new System.Drawing.Size(30, 20);
            this.lb_T_Av.TabIndex = 24;
            this.lb_T_Av.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "E_Max";
            // 
            // lb_bat_max
            // 
            this.lb_bat_max.AutoSize = true;
            this.lb_bat_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_max.Location = new System.Drawing.Point(297, 122);
            this.lb_bat_max.Name = "lb_bat_max";
            this.lb_bat_max.Size = new System.Drawing.Size(30, 20);
            this.lb_bat_max.TabIndex = 20;
            this.lb_bat_max.Text = "---";
            // 
            // lbl_mtr_manu
            // 
            this.lbl_mtr_manu.AutoSize = true;
            this.lbl_mtr_manu.Location = new System.Drawing.Point(459, 315);
            this.lbl_mtr_manu.Name = "lbl_mtr_manu";
            this.lbl_mtr_manu.Size = new System.Drawing.Size(23, 17);
            this.lbl_mtr_manu.TabIndex = 37;
            this.lbl_mtr_manu.Text = "---";
            // 
            // lb_mtr_model
            // 
            this.lb_mtr_model.AutoSize = true;
            this.lb_mtr_model.Location = new System.Drawing.Point(459, 332);
            this.lb_mtr_model.Name = "lb_mtr_model";
            this.lb_mtr_model.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_model.TabIndex = 38;
            this.lb_mtr_model.Text = "---";
            // 
            // lb_mtr_ver
            // 
            this.lb_mtr_ver.AutoSize = true;
            this.lb_mtr_ver.Location = new System.Drawing.Point(459, 349);
            this.lb_mtr_ver.Name = "lb_mtr_ver";
            this.lb_mtr_ver.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_ver.TabIndex = 39;
            this.lb_mtr_ver.Text = "---";
            // 
            // lb_mtr_opt
            // 
            this.lb_mtr_opt.AutoSize = true;
            this.lb_mtr_opt.Location = new System.Drawing.Point(621, 315);
            this.lb_mtr_opt.Name = "lb_mtr_opt";
            this.lb_mtr_opt.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_opt.TabIndex = 40;
            this.lb_mtr_opt.Text = "---";
            // 
            // lb_mtr_sernr
            // 
            this.lb_mtr_sernr.AutoSize = true;
            this.lb_mtr_sernr.Location = new System.Drawing.Point(621, 332);
            this.lb_mtr_sernr.Name = "lb_mtr_sernr";
            this.lb_mtr_sernr.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_sernr.TabIndex = 41;
            this.lb_mtr_sernr.Text = "---";
            // 
            // MB_Pwr_3
            // 
            this.MB_Pwr_3.BackColor = System.Drawing.SystemColors.InfoText;
            this.MB_Pwr_3.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MB_Pwr_3.ForeColor = System.Drawing.SystemColors.Window;
            this.MB_Pwr_3.Location = new System.Drawing.Point(498, 279);
            this.MB_Pwr_3.Name = "MB_Pwr_3";
            this.MB_Pwr_3.Size = new System.Drawing.Size(154, 22);
            this.MB_Pwr_3.TabIndex = 42;
            this.MB_Pwr_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EdgeMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(742, 657);
            this.Controls.Add(this.MB_Pwr_3);
            this.Controls.Add(this.lb_mtr_sernr);
            this.Controls.Add(this.lb_mtr_opt);
            this.Controls.Add(this.lb_mtr_ver);
            this.Controls.Add(this.lb_mtr_model);
            this.Controls.Add(this.lbl_mtr_manu);
            this.Controls.Add(this.lb_batt_pwr);
            this.Controls.Add(this.ArrowBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_temp);
            this.Controls.Add(this.ImpExMeter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.lb_dc_pwr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_update);
            this.Controls.Add(this.lb_ac_pwr);
            this.Controls.Add(this.textBox1);
            this.Name = "EdgeMon";
            this.Text = "EdgeMon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_temp;
        private System.Windows.Forms.TextBox ImpExMeter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label lb_dc_pwr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_update;
        private System.Windows.Forms.Label lb_ac_pwr;
        private System.Windows.Forms.PictureBox ArrowBox;
        private System.Windows.Forms.Label lb_batt_pwr;
        private System.Windows.Forms.Label lb_bat_stat;
        private System.Windows.Forms.ProgressBar bat_SOE;
        private System.Windows.Forms.Label lb_SOE_TXT;
        private System.Windows.Forms.Label lb_SOH;
        private System.Windows.Forms.TextBox tb_batManu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_mtr_manu;
        private System.Windows.Forms.Label lb_mtr_model;
        private System.Windows.Forms.Label lb_mtr_ver;
        private System.Windows.Forms.Label lb_mtr_opt;
        private System.Windows.Forms.Label lb_mtr_sernr;
        private System.Windows.Forms.TextBox MB_Pwr_3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_bat_max;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_T_Av;
    }
}

