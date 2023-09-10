
namespace EdgeMon
{
    partial class NewEdge
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
            this.bat_SOE = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PV_on = new System.Windows.Forms.PictureBox();
            this.PV_off = new System.Windows.Forms.PictureBox();
            this.house = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.PictureBox();
            this.battery = new System.Windows.Forms.PictureBox();
            this.pic_PV_from = new System.Windows.Forms.PictureBox();
            this.pic_grid_from = new System.Windows.Forms.PictureBox();
            this.pic_bat_from = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pic_bat_to = new System.Windows.Forms.PictureBox();
            this.pic_house_to = new System.Windows.Forms.PictureBox();
            this.pic_grid_to = new System.Windows.Forms.PictureBox();
            this.MB_Pwr_3 = new System.Windows.Forms.TextBox();
            this.ImpExMeter = new System.Windows.Forms.TextBox();
            this.lb_dc_pwr = new System.Windows.Forms.Label();
            this.lb_ac_pwr = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_update = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_T_Av = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_bat_max = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_SOH = new System.Windows.Forms.Label();
            this.lb_SOE_TXT = new System.Windows.Forms.Label();
            this.lb_bat_stat = new System.Windows.Forms.Label();
            this.tb_batManu = new System.Windows.Forms.TextBox();
            this.lb_temp = new System.Windows.Forms.Label();
            this.lb_batt_pwr = new System.Windows.Forms.Label();
            this.lb_mtr_sernr = new System.Windows.Forms.Label();
            this.lb_mtr_opt = new System.Windows.Forms.Label();
            this.lb_mtr_ver = new System.Windows.Forms.Label();
            this.lb_mtr_model = new System.Windows.Forms.Label();
            this.lbl_mtr_manu = new System.Windows.Forms.Label();
            this.lb_pwr_house = new System.Windows.Forms.Label();
            this.lb_pwr_PV = new System.Windows.Forms.Label();
            this.tb_Inv = new System.Windows.Forms.TextBox();
            this.tb_chargepower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_total = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_tot_prod = new System.Windows.Forms.TextBox();
            this.lb_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PV_on)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PV_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_house_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_to)).BeginInit();
            this.SuspendLayout();
            // 
            // bat_SOE
            // 
            this.bat_SOE.BackColor = System.Drawing.Color.IndianRed;
            this.bat_SOE.ForeColor = System.Drawing.Color.Red;
            this.bat_SOE.Location = new System.Drawing.Point(74, 420);
            this.bat_SOE.MarqueeAnimationSpeed = 10;
            this.bat_SOE.Name = "bat_SOE";
            this.bat_SOE.Size = new System.Drawing.Size(155, 45);
            this.bat_SOE.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bat_SOE.TabIndex = 2;
            this.bat_SOE.UseWaitCursor = true;
            this.bat_SOE.Value = 99;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 720);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // PV_on
            // 
            this.PV_on.Image = global::EdgeMon.Properties.Resources.PV;
            this.PV_on.InitialImage = global::EdgeMon.Properties.Resources.PV;
            this.PV_on.Location = new System.Drawing.Point(101, 55);
            this.PV_on.Name = "PV_on";
            this.PV_on.Size = new System.Drawing.Size(100, 99);
            this.PV_on.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PV_on.TabIndex = 4;
            this.PV_on.TabStop = false;
            // 
            // PV_off
            // 
            this.PV_off.Image = global::EdgeMon.Properties.Resources.PV_off;
            this.PV_off.Location = new System.Drawing.Point(101, 55);
            this.PV_off.Name = "PV_off";
            this.PV_off.Size = new System.Drawing.Size(100, 99);
            this.PV_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PV_off.TabIndex = 5;
            this.PV_off.TabStop = false;
            // 
            // house
            // 
            this.house.Image = global::EdgeMon.Properties.Resources.house;
            this.house.Location = new System.Drawing.Point(473, 401);
            this.house.Name = "house";
            this.house.Size = new System.Drawing.Size(100, 99);
            this.house.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.house.TabIndex = 6;
            this.house.TabStop = false;
            // 
            // grid
            // 
            this.grid.Image = global::EdgeMon.Properties.Resources.Grid;
            this.grid.Location = new System.Drawing.Point(473, 55);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(100, 99);
            this.grid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.grid.TabIndex = 7;
            this.grid.TabStop = false;
            // 
            // battery
            // 
            this.battery.Image = global::EdgeMon.Properties.Resources.battery;
            this.battery.Location = new System.Drawing.Point(56, 384);
            this.battery.Name = "battery";
            this.battery.Size = new System.Drawing.Size(214, 116);
            this.battery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.battery.TabIndex = 8;
            this.battery.TabStop = false;
            // 
            // pic_PV_from
            // 
            this.pic_PV_from.Image = global::EdgeMon.Properties.Resources.arrow41;
            this.pic_PV_from.Location = new System.Drawing.Point(142, 151);
            this.pic_PV_from.Name = "pic_PV_from";
            this.pic_PV_from.Size = new System.Drawing.Size(100, 130);
            this.pic_PV_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PV_from.TabIndex = 9;
            this.pic_PV_from.TabStop = false;
            // 
            // pic_grid_from
            // 
            this.pic_grid_from.Image = global::EdgeMon.Properties.Resources.arrow2;
            this.pic_grid_from.Location = new System.Drawing.Point(447, 151);
            this.pic_grid_from.Name = "pic_grid_from";
            this.pic_grid_from.Size = new System.Drawing.Size(100, 129);
            this.pic_grid_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_grid_from.TabIndex = 10;
            this.pic_grid_from.TabStop = false;
            // 
            // pic_bat_from
            // 
            this.pic_bat_from.Image = global::EdgeMon.Properties.Resources.arrow1;
            this.pic_bat_from.Location = new System.Drawing.Point(142, 298);
            this.pic_bat_from.Name = "pic_bat_from";
            this.pic_bat_from.Size = new System.Drawing.Size(100, 116);
            this.pic_bat_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_bat_from.TabIndex = 11;
            this.pic_bat_from.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::EdgeMon.Properties.Resources.SE11;
            this.pictureBox5.Location = new System.Drawing.Point(241, 243);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(209, 92);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            // 
            // pic_bat_to
            // 
            this.pic_bat_to.Image = global::EdgeMon.Properties.Resources.arrow1R;
            this.pic_bat_to.Location = new System.Drawing.Point(142, 296);
            this.pic_bat_to.Name = "pic_bat_to";
            this.pic_bat_to.Size = new System.Drawing.Size(100, 116);
            this.pic_bat_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_bat_to.TabIndex = 28;
            this.pic_bat_to.TabStop = false;
            // 
            // pic_house_to
            // 
            this.pic_house_to.Image = global::EdgeMon.Properties.Resources.arrow3;
            this.pic_house_to.Location = new System.Drawing.Point(447, 296);
            this.pic_house_to.Name = "pic_house_to";
            this.pic_house_to.Size = new System.Drawing.Size(100, 116);
            this.pic_house_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_house_to.TabIndex = 30;
            this.pic_house_to.TabStop = false;
            // 
            // pic_grid_to
            // 
            this.pic_grid_to.Image = global::EdgeMon.Properties.Resources.arrow2R;
            this.pic_grid_to.Location = new System.Drawing.Point(447, 151);
            this.pic_grid_to.Name = "pic_grid_to";
            this.pic_grid_to.Size = new System.Drawing.Size(100, 129);
            this.pic_grid_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_grid_to.TabIndex = 31;
            this.pic_grid_to.TabStop = false;
            // 
            // MB_Pwr_3
            // 
            this.MB_Pwr_3.BackColor = System.Drawing.Color.White;
            this.MB_Pwr_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MB_Pwr_3.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MB_Pwr_3.ForeColor = System.Drawing.Color.Black;
            this.MB_Pwr_3.Location = new System.Drawing.Point(553, 247);
            this.MB_Pwr_3.Name = "MB_Pwr_3";
            this.MB_Pwr_3.Size = new System.Drawing.Size(154, 15);
            this.MB_Pwr_3.TabIndex = 44;
            this.MB_Pwr_3.Text = "---";
            // 
            // ImpExMeter
            // 
            this.ImpExMeter.BackColor = System.Drawing.Color.White;
            this.ImpExMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ImpExMeter.Font = new System.Drawing.Font("Britannic Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImpExMeter.ForeColor = System.Drawing.Color.Black;
            this.ImpExMeter.Location = new System.Drawing.Point(553, 228);
            this.ImpExMeter.Name = "ImpExMeter";
            this.ImpExMeter.Size = new System.Drawing.Size(154, 19);
            this.ImpExMeter.TabIndex = 43;
            this.ImpExMeter.Text = "---";
            // 
            // lb_dc_pwr
            // 
            this.lb_dc_pwr.AutoSize = true;
            this.lb_dc_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dc_pwr.Location = new System.Drawing.Point(248, 215);
            this.lb_dc_pwr.Name = "lb_dc_pwr";
            this.lb_dc_pwr.Size = new System.Drawing.Size(63, 20);
            this.lb_dc_pwr.TabIndex = 45;
            this.lb_dc_pwr.Text = "000000";
            this.lb_dc_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_ac_pwr
            // 
            this.lb_ac_pwr.AutoSize = true;
            this.lb_ac_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ac_pwr.Location = new System.Drawing.Point(387, 215);
            this.lb_ac_pwr.Name = "lb_ac_pwr";
            this.lb_ac_pwr.Size = new System.Drawing.Size(63, 20);
            this.lb_ac_pwr.TabIndex = 46;
            this.lb_ac_pwr.Text = "000000";
            this.lb_ac_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.Red;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_status.Location = new System.Drawing.Point(299, 338);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(97, 31);
            this.lb_status.TabIndex = 47;
            this.lb_status.Text = "NONE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Last Update";
            // 
            // lb_update
            // 
            this.lb_update.AutoSize = true;
            this.lb_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_update.Location = new System.Drawing.Point(132, 9);
            this.lb_update.Name = "lb_update";
            this.lb_update.Size = new System.Drawing.Size(63, 20);
            this.lb_update.TabIndex = 48;
            this.lb_update.Text = "000000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 17);
            this.label11.TabIndex = 59;
            this.label11.Text = "T_Av";
            // 
            // lb_T_Av
            // 
            this.lb_T_Av.AutoSize = true;
            this.lb_T_Av.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T_Av.Location = new System.Drawing.Point(108, 522);
            this.lb_T_Av.Name = "lb_T_Av";
            this.lb_T_Av.Size = new System.Drawing.Size(23, 17);
            this.lb_T_Av.TabIndex = 58;
            this.lb_T_Av.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 57;
            this.label9.Text = "E_Max";
            // 
            // lb_bat_max
            // 
            this.lb_bat_max.AutoSize = true;
            this.lb_bat_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_max.Location = new System.Drawing.Point(108, 542);
            this.lb_bat_max.Name = "lb_bat_max";
            this.lb_bat_max.Size = new System.Drawing.Size(23, 17);
            this.lb_bat_max.TabIndex = 56;
            this.lb_bat_max.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 562);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 55;
            this.label7.Text = "SOH";
            // 
            // lb_SOH
            // 
            this.lb_SOH.AutoSize = true;
            this.lb_SOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOH.Location = new System.Drawing.Point(108, 562);
            this.lb_SOH.Name = "lb_SOH";
            this.lb_SOH.Size = new System.Drawing.Size(23, 17);
            this.lb_SOH.TabIndex = 54;
            this.lb_SOH.Text = "---";
            // 
            // lb_SOE_TXT
            // 
            this.lb_SOE_TXT.AutoSize = true;
            this.lb_SOE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOE_TXT.Location = new System.Drawing.Point(69, 480);
            this.lb_SOE_TXT.Name = "lb_SOE_TXT";
            this.lb_SOE_TXT.Size = new System.Drawing.Size(30, 20);
            this.lb_SOE_TXT.TabIndex = 53;
            this.lb_SOE_TXT.Text = "---";
            // 
            // lb_bat_stat
            // 
            this.lb_bat_stat.AutoSize = true;
            this.lb_bat_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_stat.Location = new System.Drawing.Point(248, 456);
            this.lb_bat_stat.Name = "lb_bat_stat";
            this.lb_bat_stat.Size = new System.Drawing.Size(102, 20);
            this.lb_bat_stat.TabIndex = 52;
            this.lb_bat_stat.Text = "Bat_Status";
            // 
            // tb_batManu
            // 
            this.tb_batManu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_batManu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tb_batManu.Location = new System.Drawing.Point(202, 518);
            this.tb_batManu.Multiline = true;
            this.tb_batManu.Name = "tb_batManu";
            this.tb_batManu.Size = new System.Drawing.Size(228, 138);
            this.tb_batManu.TabIndex = 60;
            this.tb_batManu.Text = "---";
            // 
            // lb_temp
            // 
            this.lb_temp.AutoSize = true;
            this.lb_temp.BackColor = System.Drawing.Color.White;
            this.lb_temp.Location = new System.Drawing.Point(333, 315);
            this.lb_temp.Name = "lb_temp";
            this.lb_temp.Size = new System.Drawing.Size(23, 17);
            this.lb_temp.TabIndex = 61;
            this.lb_temp.Text = "---";
            // 
            // lb_batt_pwr
            // 
            this.lb_batt_pwr.AutoSize = true;
            this.lb_batt_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_batt_pwr.Location = new System.Drawing.Point(52, 332);
            this.lb_batt_pwr.Name = "lb_batt_pwr";
            this.lb_batt_pwr.Size = new System.Drawing.Size(63, 20);
            this.lb_batt_pwr.TabIndex = 62;
            this.lb_batt_pwr.Text = "000000";
            this.lb_batt_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_mtr_sernr
            // 
            this.lb_mtr_sernr.AutoSize = true;
            this.lb_mtr_sernr.Location = new System.Drawing.Point(579, 189);
            this.lb_mtr_sernr.Name = "lb_mtr_sernr";
            this.lb_mtr_sernr.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_sernr.TabIndex = 67;
            this.lb_mtr_sernr.Text = "---";
            // 
            // lb_mtr_opt
            // 
            this.lb_mtr_opt.AutoSize = true;
            this.lb_mtr_opt.Location = new System.Drawing.Point(579, 172);
            this.lb_mtr_opt.Name = "lb_mtr_opt";
            this.lb_mtr_opt.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_opt.TabIndex = 66;
            this.lb_mtr_opt.Text = "---";
            // 
            // lb_mtr_ver
            // 
            this.lb_mtr_ver.AutoSize = true;
            this.lb_mtr_ver.Location = new System.Drawing.Point(579, 151);
            this.lb_mtr_ver.Name = "lb_mtr_ver";
            this.lb_mtr_ver.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_ver.TabIndex = 65;
            this.lb_mtr_ver.Text = "---";
            // 
            // lb_mtr_model
            // 
            this.lb_mtr_model.AutoSize = true;
            this.lb_mtr_model.Location = new System.Drawing.Point(579, 130);
            this.lb_mtr_model.Name = "lb_mtr_model";
            this.lb_mtr_model.Size = new System.Drawing.Size(23, 17);
            this.lb_mtr_model.TabIndex = 64;
            this.lb_mtr_model.Text = "---";
            // 
            // lbl_mtr_manu
            // 
            this.lbl_mtr_manu.AutoSize = true;
            this.lbl_mtr_manu.Location = new System.Drawing.Point(579, 113);
            this.lbl_mtr_manu.Name = "lbl_mtr_manu";
            this.lbl_mtr_manu.Size = new System.Drawing.Size(23, 17);
            this.lbl_mtr_manu.TabIndex = 63;
            this.lbl_mtr_manu.Text = "---";
            // 
            // lb_pwr_house
            // 
            this.lb_pwr_house.AutoSize = true;
            this.lb_pwr_house.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pwr_house.ForeColor = System.Drawing.Color.Black;
            this.lb_pwr_house.Location = new System.Drawing.Point(553, 332);
            this.lb_pwr_house.Name = "lb_pwr_house";
            this.lb_pwr_house.Size = new System.Drawing.Size(63, 20);
            this.lb_pwr_house.TabIndex = 68;
            this.lb_pwr_house.Text = "000000";
            this.lb_pwr_house.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_pwr_PV
            // 
            this.lb_pwr_PV.AutoSize = true;
            this.lb_pwr_PV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pwr_PV.ForeColor = System.Drawing.Color.Black;
            this.lb_pwr_PV.Location = new System.Drawing.Point(29, 206);
            this.lb_pwr_PV.Name = "lb_pwr_PV";
            this.lb_pwr_PV.Size = new System.Drawing.Size(63, 20);
            this.lb_pwr_PV.TabIndex = 69;
            this.lb_pwr_PV.Text = "000000";
            this.lb_pwr_PV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Inv
            // 
            this.tb_Inv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tb_Inv.Location = new System.Drawing.Point(258, 127);
            this.tb_Inv.Multiline = true;
            this.tb_Inv.Name = "tb_Inv";
            this.tb_Inv.Size = new System.Drawing.Size(172, 77);
            this.tb_Inv.TabIndex = 70;
            this.tb_Inv.Text = "---";
            // 
            // tb_chargepower
            // 
            this.tb_chargepower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_chargepower.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_chargepower.Location = new System.Drawing.Point(111, 582);
            this.tb_chargepower.Multiline = true;
            this.tb_chargepower.Name = "tb_chargepower";
            this.tb_chargepower.Size = new System.Drawing.Size(165, 35);
            this.tb_chargepower.TabIndex = 71;
            this.tb_chargepower.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 582);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Max/Peak";
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total.Location = new System.Drawing.Point(30, 603);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(23, 17);
            this.lb_total.TabIndex = 73;
            this.lb_total.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 621);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 74;
            this.label4.Text = "V2.1 (C) M. Aigle 2023";
            // 
            // lb_tot_prod
            // 
            this.lb_tot_prod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_tot_prod.Location = new System.Drawing.Point(258, 384);
            this.lb_tot_prod.Name = "lb_tot_prod";
            this.lb_tot_prod.Size = new System.Drawing.Size(192, 15);
            this.lb_tot_prod.TabIndex = 75;
            this.lb_tot_prod.Text = "---";
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.lb_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_error.ForeColor = System.Drawing.Color.DarkGreen;
            this.lb_error.Location = new System.Drawing.Point(333, 16);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(24, 13);
            this.lb_error.TabIndex = 76;
            this.lb_error.Text = "OK";
            // 
            // NewEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 647);
            this.Controls.Add(this.lb_error);
            this.Controls.Add(this.lb_tot_prod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_chargepower);
            this.Controls.Add(this.tb_Inv);
            this.Controls.Add(this.lb_pwr_PV);
            this.Controls.Add(this.lb_pwr_house);
            this.Controls.Add(this.lb_mtr_sernr);
            this.Controls.Add(this.lb_mtr_opt);
            this.Controls.Add(this.lb_mtr_ver);
            this.Controls.Add(this.lb_mtr_model);
            this.Controls.Add(this.lbl_mtr_manu);
            this.Controls.Add(this.lb_batt_pwr);
            this.Controls.Add(this.lb_temp);
            this.Controls.Add(this.tb_batManu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_T_Av);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_bat_max);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_SOH);
            this.Controls.Add(this.lb_SOE_TXT);
            this.Controls.Add(this.lb_bat_stat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_update);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.lb_ac_pwr);
            this.Controls.Add(this.lb_dc_pwr);
            this.Controls.Add(this.MB_Pwr_3);
            this.Controls.Add(this.ImpExMeter);
            this.Controls.Add(this.pic_grid_to);
            this.Controls.Add(this.pic_house_to);
            this.Controls.Add(this.pic_bat_to);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pic_bat_from);
            this.Controls.Add(this.pic_grid_from);
            this.Controls.Add(this.pic_PV_from);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.house);
            this.Controls.Add(this.PV_off);
            this.Controls.Add(this.PV_on);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bat_SOE);
            this.Controls.Add(this.battery);
            this.Name = "NewEdge";
            this.Text = "Edgemon";
            ((System.ComponentModel.ISupportInitialize)(this.PV_on)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PV_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_house_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_to)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar bat_SOE;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PV_on;
        private System.Windows.Forms.PictureBox PV_off;
        private System.Windows.Forms.PictureBox house;
        private System.Windows.Forms.PictureBox grid;
        private System.Windows.Forms.PictureBox battery;
        private System.Windows.Forms.PictureBox pic_PV_from;
        private System.Windows.Forms.PictureBox pic_grid_from;
        private System.Windows.Forms.PictureBox pic_bat_from;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pic_bat_to;
        private System.Windows.Forms.PictureBox pic_house_to;
        private System.Windows.Forms.PictureBox pic_grid_to;
        private System.Windows.Forms.TextBox MB_Pwr_3;
        private System.Windows.Forms.TextBox ImpExMeter;
        private System.Windows.Forms.Label lb_dc_pwr;
        private System.Windows.Forms.Label lb_ac_pwr;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_update;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_T_Av;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_bat_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_SOH;
        private System.Windows.Forms.Label lb_SOE_TXT;
        private System.Windows.Forms.Label lb_bat_stat;
        private System.Windows.Forms.TextBox tb_batManu;
        private System.Windows.Forms.Label lb_temp;
        private System.Windows.Forms.Label lb_batt_pwr;
        private System.Windows.Forms.Label lb_mtr_sernr;
        private System.Windows.Forms.Label lb_mtr_opt;
        private System.Windows.Forms.Label lb_mtr_ver;
        private System.Windows.Forms.Label lb_mtr_model;
        private System.Windows.Forms.Label lbl_mtr_manu;
        private System.Windows.Forms.Label lb_pwr_house;
        private System.Windows.Forms.Label lb_pwr_PV;
        private System.Windows.Forms.TextBox tb_Inv;
        private System.Windows.Forms.TextBox tb_chargepower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lb_tot_prod;
        private System.Windows.Forms.Label lb_error;
    }
}