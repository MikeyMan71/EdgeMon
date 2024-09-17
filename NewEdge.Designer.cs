
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewEdge));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tb_batManu = new System.Windows.Forms.TextBox();
            this.battery = new System.Windows.Forms.PictureBox();
            this.Inverter_PIC = new System.Windows.Forms.PictureBox();
            this.bat_SOE = new System.Windows.Forms.ProgressBar();
            this.lb_temp = new System.Windows.Forms.Label();
            this.house = new System.Windows.Forms.PictureBox();
            this.PV_on = new System.Windows.Forms.PictureBox();
            this.PV_off = new System.Windows.Forms.PictureBox();
            this.grid = new System.Windows.Forms.PictureBox();
            this.pic_PV_from = new System.Windows.Forms.PictureBox();
            this.pic_grid_from = new System.Windows.Forms.PictureBox();
            this.pic_bat_from = new System.Windows.Forms.PictureBox();
            this.pic_grid_to = new System.Windows.Forms.PictureBox();
            this.ImpExMeter = new System.Windows.Forms.TextBox();
            this.MB_Pwr_3 = new System.Windows.Forms.TextBox();
            this.lb_dc_pwr = new System.Windows.Forms.Label();
            this.lb_ac_pwr = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.lb_update = new System.Windows.Forms.Label();
            this.lb_bat_stat = new System.Windows.Forms.Label();
            this.lb_SOE_TXT = new System.Windows.Forms.Label();
            this.lb_SOH = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_bat_max = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_T_Av = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_batt_pwr = new System.Windows.Forms.Label();
            this.lbl_mtr_manu = new System.Windows.Forms.Label();
            this.lb_mtr_model = new System.Windows.Forms.Label();
            this.lb_mtr_ver = new System.Windows.Forms.Label();
            this.lb_mtr_opt = new System.Windows.Forms.Label();
            this.lb_mtr_sernr = new System.Windows.Forms.Label();
            this.lb_pwr_house = new System.Windows.Forms.Label();
            this.lb_pwr_PV = new System.Windows.Forms.Label();
            this.tb_Inv = new System.Windows.Forms.TextBox();
            this.tb_chargepower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_total = new System.Windows.Forms.Label();
            this.lb_tot_prod = new System.Windows.Forms.TextBox();
            this.lb_error = new System.Windows.Forms.Label();
            this.pic_house_to = new System.Windows.Forms.PictureBox();
            this.pic_bat_to = new System.Windows.Forms.PictureBox();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.lb_version_copyright = new System.Windows.Forms.Label();
            this.lb_upd = new System.Windows.Forms.PictureBox();
            this.lb_OptionMenu = new System.Windows.Forms.PictureBox();
            this.AC_VOLTAGE_3 = new System.Windows.Forms.TextBox();
            this.AC_CURRENT_3 = new System.Windows.Forms.TextBox();
            this.BurgerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.battery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inverter_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_on)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PV_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_house_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_to)).BeginInit();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lb_upd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_OptionMenu)).BeginInit();
            this.BurgerMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.MainTimer_tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 720);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 3;
            this.label1.Visible = false;
            // 
            // tb_batManu
            // 
            this.tb_batManu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_batManu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tb_batManu.Location = new System.Drawing.Point(195, 498);
            this.tb_batManu.Multiline = true;
            this.tb_batManu.Name = "tb_batManu";
            this.tb_batManu.Size = new System.Drawing.Size(228, 114);
            this.tb_batManu.TabIndex = 60;
            this.tb_batManu.Text = "---";
            // 
            // battery
            // 
            this.battery.BackColor = System.Drawing.Color.Transparent;
            this.battery.Image = global::EdgeMon.Properties.Resources.battery;
            this.battery.Location = new System.Drawing.Point(35, 389);
            this.battery.Name = "battery";
            this.battery.Size = new System.Drawing.Size(214, 50);
            this.battery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.battery.TabIndex = 8;
            this.battery.TabStop = false;
            // 
            // Inverter_PIC
            // 
            this.Inverter_PIC.Image = global::EdgeMon.Properties.Resources.SE11;
            this.Inverter_PIC.Location = new System.Drawing.Point(234, 219);
            this.Inverter_PIC.Name = "Inverter_PIC";
            this.Inverter_PIC.Size = new System.Drawing.Size(209, 92);
            this.Inverter_PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Inverter_PIC.TabIndex = 27;
            this.Inverter_PIC.TabStop = false;
            this.Inverter_PIC.Click += new System.EventHandler(this.Inverter_PIC_Click);
            // 
            // bat_SOE
            // 
            this.bat_SOE.BackColor = System.Drawing.Color.IndianRed;
            this.bat_SOE.ForeColor = System.Drawing.Color.Red;
            this.bat_SOE.Location = new System.Drawing.Point(46, 394);
            this.bat_SOE.MarqueeAnimationSpeed = 10;
            this.bat_SOE.Name = "bat_SOE";
            this.bat_SOE.Size = new System.Drawing.Size(179, 41);
            this.bat_SOE.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bat_SOE.TabIndex = 2;
            this.bat_SOE.UseWaitCursor = true;
            this.bat_SOE.Value = 99;
            // 
            // lb_temp
            // 
            this.lb_temp.AutoSize = true;
            this.lb_temp.BackColor = System.Drawing.Color.LightPink;
            this.lb_temp.ForeColor = System.Drawing.Color.DimGray;
            this.lb_temp.Location = new System.Drawing.Point(306, 290);
            this.lb_temp.Name = "lb_temp";
            this.lb_temp.Size = new System.Drawing.Size(19, 16);
            this.lb_temp.TabIndex = 61;
            this.lb_temp.Tag = "FIXEDCOLOR";
            this.lb_temp.Text = "---";
            // 
            // house
            // 
            this.house.Image = global::EdgeMon.Properties.Resources.house;
            this.house.Location = new System.Drawing.Point(463, 389);
            this.house.Name = "house";
            this.house.Size = new System.Drawing.Size(96, 96);
            this.house.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.house.TabIndex = 6;
            this.house.TabStop = false;
            // 
            // PV_on
            // 
            this.PV_on.Image = global::EdgeMon.Properties.Resources.PV;
            this.PV_on.InitialImage = global::EdgeMon.Properties.Resources.PV;
            this.PV_on.Location = new System.Drawing.Point(94, 31);
            this.PV_on.Name = "PV_on";
            this.PV_on.Size = new System.Drawing.Size(100, 99);
            this.PV_on.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PV_on.TabIndex = 4;
            this.PV_on.TabStop = false;
            // 
            // PV_off
            // 
            this.PV_off.Image = global::EdgeMon.Properties.Resources.PV_off;
            this.PV_off.Location = new System.Drawing.Point(94, 31);
            this.PV_off.Name = "PV_off";
            this.PV_off.Size = new System.Drawing.Size(100, 99);
            this.PV_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PV_off.TabIndex = 5;
            this.PV_off.TabStop = false;
            // 
            // grid
            // 
            this.grid.Image = global::EdgeMon.Properties.Resources.Grid;
            this.grid.Location = new System.Drawing.Point(466, 31);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(100, 99);
            this.grid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.grid.TabIndex = 7;
            this.grid.TabStop = false;
            // 
            // pic_PV_from
            // 
            this.pic_PV_from.Image = global::EdgeMon.Properties.Resources.arrow41;
            this.pic_PV_from.Location = new System.Drawing.Point(138, 127);
            this.pic_PV_from.Name = "pic_PV_from";
            this.pic_PV_from.Size = new System.Drawing.Size(97, 130);
            this.pic_PV_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PV_from.TabIndex = 9;
            this.pic_PV_from.TabStop = false;
            // 
            // pic_grid_from
            // 
            this.pic_grid_from.Image = global::EdgeMon.Properties.Resources.arrow2;
            this.pic_grid_from.Location = new System.Drawing.Point(440, 127);
            this.pic_grid_from.Name = "pic_grid_from";
            this.pic_grid_from.Size = new System.Drawing.Size(100, 129);
            this.pic_grid_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_grid_from.TabIndex = 10;
            this.pic_grid_from.TabStop = false;
            // 
            // pic_bat_from
            // 
            this.pic_bat_from.Image = global::EdgeMon.Properties.Resources.arrow411;
            this.pic_bat_from.Location = new System.Drawing.Point(139, 273);
            this.pic_bat_from.Name = "pic_bat_from";
            this.pic_bat_from.Size = new System.Drawing.Size(97, 116);
            this.pic_bat_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_bat_from.TabIndex = 11;
            this.pic_bat_from.TabStop = false;
            // 
            // pic_grid_to
            // 
            this.pic_grid_to.Image = global::EdgeMon.Properties.Resources.arrow2R;
            this.pic_grid_to.Location = new System.Drawing.Point(440, 127);
            this.pic_grid_to.Name = "pic_grid_to";
            this.pic_grid_to.Size = new System.Drawing.Size(100, 129);
            this.pic_grid_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_grid_to.TabIndex = 31;
            this.pic_grid_to.TabStop = false;
            // 
            // ImpExMeter
            // 
            this.ImpExMeter.BackColor = System.Drawing.Color.White;
            this.ImpExMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ImpExMeter.Font = new System.Drawing.Font("Britannic Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImpExMeter.ForeColor = System.Drawing.Color.Black;
            this.ImpExMeter.Location = new System.Drawing.Point(546, 204);
            this.ImpExMeter.Name = "ImpExMeter";
            this.ImpExMeter.Size = new System.Drawing.Size(154, 19);
            this.ImpExMeter.TabIndex = 43;
            this.ImpExMeter.Text = "---";
            // 
            // MB_Pwr_3
            // 
            this.MB_Pwr_3.BackColor = System.Drawing.Color.White;
            this.MB_Pwr_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MB_Pwr_3.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MB_Pwr_3.ForeColor = System.Drawing.Color.Black;
            this.MB_Pwr_3.Location = new System.Drawing.Point(546, 223);
            this.MB_Pwr_3.Name = "MB_Pwr_3";
            this.MB_Pwr_3.Size = new System.Drawing.Size(194, 15);
            this.MB_Pwr_3.TabIndex = 44;
            this.MB_Pwr_3.Text = "---";
            // 
            // lb_dc_pwr
            // 
            this.lb_dc_pwr.AutoSize = true;
            this.lb_dc_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dc_pwr.Location = new System.Drawing.Point(235, 192);
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
            this.lb_ac_pwr.Location = new System.Drawing.Point(360, 192);
            this.lb_ac_pwr.Name = "lb_ac_pwr";
            this.lb_ac_pwr.Size = new System.Drawing.Size(63, 20);
            this.lb_ac_pwr.TabIndex = 46;
            this.lb_ac_pwr.Text = "000000";
            this.lb_ac_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.LightPink;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.Color.DimGray;
            this.lb_status.Location = new System.Drawing.Point(305, 223);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(61, 20);
            this.lb_status.TabIndex = 47;
            this.lb_status.Tag = "FIXEDCOLOR";
            this.lb_status.Text = "NONE";
            // 
            // lb_update
            // 
            this.lb_update.AutoSize = true;
            this.lb_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_update.Location = new System.Drawing.Point(8, 8);
            this.lb_update.Name = "lb_update";
            this.lb_update.Size = new System.Drawing.Size(63, 20);
            this.lb_update.TabIndex = 48;
            this.lb_update.Text = "000000";
            // 
            // lb_bat_stat
            // 
            this.lb_bat_stat.AutoSize = true;
            this.lb_bat_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_stat.Location = new System.Drawing.Point(255, 419);
            this.lb_bat_stat.Name = "lb_bat_stat";
            this.lb_bat_stat.Size = new System.Drawing.Size(102, 20);
            this.lb_bat_stat.TabIndex = 52;
            this.lb_bat_stat.Text = "Bat_Status";
            // 
            // lb_SOE_TXT
            // 
            this.lb_SOE_TXT.AutoSize = true;
            this.lb_SOE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOE_TXT.Location = new System.Drawing.Point(62, 456);
            this.lb_SOE_TXT.Name = "lb_SOE_TXT";
            this.lb_SOE_TXT.Size = new System.Drawing.Size(30, 20);
            this.lb_SOE_TXT.TabIndex = 53;
            this.lb_SOE_TXT.Text = "---";
            // 
            // lb_SOH
            // 
            this.lb_SOH.AutoSize = true;
            this.lb_SOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SOH.Location = new System.Drawing.Point(101, 520);
            this.lb_SOH.Name = "lb_SOH";
            this.lb_SOH.Size = new System.Drawing.Size(19, 16);
            this.lb_SOH.TabIndex = 54;
            this.lb_SOH.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 55;
            this.label7.Text = "SOH";
            // 
            // lb_bat_max
            // 
            this.lb_bat_max.AutoSize = true;
            this.lb_bat_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bat_max.Location = new System.Drawing.Point(101, 536);
            this.lb_bat_max.Name = "lb_bat_max";
            this.lb_bat_max.Size = new System.Drawing.Size(19, 16);
            this.lb_bat_max.TabIndex = 56;
            this.lb_bat_max.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 536);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 57;
            this.label9.Text = "E_Max";
            // 
            // lb_T_Av
            // 
            this.lb_T_Av.AutoSize = true;
            this.lb_T_Av.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T_Av.Location = new System.Drawing.Point(101, 504);
            this.lb_T_Av.Name = "lb_T_Av";
            this.lb_T_Av.Size = new System.Drawing.Size(19, 16);
            this.lb_T_Av.TabIndex = 58;
            this.lb_T_Av.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 504);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 16);
            this.label11.TabIndex = 59;
            this.label11.Text = "T_Av";
            // 
            // lb_batt_pwr
            // 
            this.lb_batt_pwr.AutoSize = true;
            this.lb_batt_pwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_batt_pwr.Location = new System.Drawing.Point(8, 308);
            this.lb_batt_pwr.Name = "lb_batt_pwr";
            this.lb_batt_pwr.Size = new System.Drawing.Size(63, 20);
            this.lb_batt_pwr.TabIndex = 62;
            this.lb_batt_pwr.Text = "000000";
            this.lb_batt_pwr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_mtr_manu
            // 
            this.lbl_mtr_manu.AutoSize = true;
            this.lbl_mtr_manu.Location = new System.Drawing.Point(572, 89);
            this.lbl_mtr_manu.Name = "lbl_mtr_manu";
            this.lbl_mtr_manu.Size = new System.Drawing.Size(19, 16);
            this.lbl_mtr_manu.TabIndex = 63;
            this.lbl_mtr_manu.Text = "---";
            // 
            // lb_mtr_model
            // 
            this.lb_mtr_model.AutoSize = true;
            this.lb_mtr_model.Location = new System.Drawing.Point(572, 106);
            this.lb_mtr_model.Name = "lb_mtr_model";
            this.lb_mtr_model.Size = new System.Drawing.Size(19, 16);
            this.lb_mtr_model.TabIndex = 64;
            this.lb_mtr_model.Text = "---";
            // 
            // lb_mtr_ver
            // 
            this.lb_mtr_ver.AutoSize = true;
            this.lb_mtr_ver.Location = new System.Drawing.Point(572, 127);
            this.lb_mtr_ver.Name = "lb_mtr_ver";
            this.lb_mtr_ver.Size = new System.Drawing.Size(19, 16);
            this.lb_mtr_ver.TabIndex = 65;
            this.lb_mtr_ver.Text = "---";
            // 
            // lb_mtr_opt
            // 
            this.lb_mtr_opt.AutoSize = true;
            this.lb_mtr_opt.Location = new System.Drawing.Point(572, 148);
            this.lb_mtr_opt.Name = "lb_mtr_opt";
            this.lb_mtr_opt.Size = new System.Drawing.Size(19, 16);
            this.lb_mtr_opt.TabIndex = 66;
            this.lb_mtr_opt.Text = "---";
            // 
            // lb_mtr_sernr
            // 
            this.lb_mtr_sernr.AutoSize = true;
            this.lb_mtr_sernr.Location = new System.Drawing.Point(572, 165);
            this.lb_mtr_sernr.Name = "lb_mtr_sernr";
            this.lb_mtr_sernr.Size = new System.Drawing.Size(19, 16);
            this.lb_mtr_sernr.TabIndex = 67;
            this.lb_mtr_sernr.Text = "---";
            // 
            // lb_pwr_house
            // 
            this.lb_pwr_house.AutoSize = true;
            this.lb_pwr_house.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pwr_house.ForeColor = System.Drawing.Color.Black;
            this.lb_pwr_house.Location = new System.Drawing.Point(546, 308);
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
            this.lb_pwr_PV.Location = new System.Drawing.Point(8, 182);
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
            this.tb_Inv.Location = new System.Drawing.Point(251, 103);
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
            this.tb_chargepower.Location = new System.Drawing.Point(104, 558);
            this.tb_chargepower.Multiline = true;
            this.tb_chargepower.Name = "tb_chargepower";
            this.tb_chargepower.Size = new System.Drawing.Size(90, 16);
            this.tb_chargepower.TabIndex = 71;
            this.tb_chargepower.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Max/Peak";
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total.Location = new System.Drawing.Point(23, 579);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(19, 16);
            this.lb_total.TabIndex = 73;
            this.lb_total.Text = "---";
            // 
            // lb_tot_prod
            // 
            this.lb_tot_prod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_tot_prod.Location = new System.Drawing.Point(242, 317);
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
            this.lb_error.Location = new System.Drawing.Point(211, 13);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(24, 13);
            this.lb_error.TabIndex = 76;
            this.lb_error.Text = "OK";
            // 
            // pic_house_to
            // 
            this.pic_house_to.Image = global::EdgeMon.Properties.Resources.arrow3;
            this.pic_house_to.Location = new System.Drawing.Point(440, 272);
            this.pic_house_to.Name = "pic_house_to";
            this.pic_house_to.Size = new System.Drawing.Size(100, 116);
            this.pic_house_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_house_to.TabIndex = 30;
            this.pic_house_to.TabStop = false;
            // 
            // pic_bat_to
            // 
            this.pic_bat_to.Image = global::EdgeMon.Properties.Resources.arrow1R;
            this.pic_bat_to.Location = new System.Drawing.Point(141, 272);
            this.pic_bat_to.Name = "pic_bat_to";
            this.pic_bat_to.Size = new System.Drawing.Size(94, 116);
            this.pic_bat_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_bat_to.TabIndex = 28;
            this.pic_bat_to.TabStop = false;
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainpanel.BackColor = System.Drawing.Color.Transparent;
            this.mainpanel.Controls.Add(this.lb_version_copyright);
            this.mainpanel.Controls.Add(this.lb_upd);
            this.mainpanel.Controls.Add(this.lb_OptionMenu);
            this.mainpanel.Controls.Add(this.lb_batt_pwr);
            this.mainpanel.Controls.Add(this.AC_VOLTAGE_3);
            this.mainpanel.Controls.Add(this.AC_CURRENT_3);
            this.mainpanel.Controls.Add(this.tb_batManu);
            this.mainpanel.Controls.Add(this.pic_house_to);
            this.mainpanel.Controls.Add(this.lb_error);
            this.mainpanel.Controls.Add(this.lb_tot_prod);
            this.mainpanel.Controls.Add(this.lb_total);
            this.mainpanel.Controls.Add(this.label3);
            this.mainpanel.Controls.Add(this.tb_chargepower);
            this.mainpanel.Controls.Add(this.tb_Inv);
            this.mainpanel.Controls.Add(this.lb_pwr_PV);
            this.mainpanel.Controls.Add(this.lb_pwr_house);
            this.mainpanel.Controls.Add(this.lb_mtr_sernr);
            this.mainpanel.Controls.Add(this.lb_mtr_opt);
            this.mainpanel.Controls.Add(this.lb_mtr_ver);
            this.mainpanel.Controls.Add(this.lb_mtr_model);
            this.mainpanel.Controls.Add(this.lbl_mtr_manu);
            this.mainpanel.Controls.Add(this.label11);
            this.mainpanel.Controls.Add(this.lb_T_Av);
            this.mainpanel.Controls.Add(this.label9);
            this.mainpanel.Controls.Add(this.lb_bat_max);
            this.mainpanel.Controls.Add(this.label7);
            this.mainpanel.Controls.Add(this.lb_SOH);
            this.mainpanel.Controls.Add(this.lb_SOE_TXT);
            this.mainpanel.Controls.Add(this.lb_bat_stat);
            this.mainpanel.Controls.Add(this.lb_update);
            this.mainpanel.Controls.Add(this.lb_status);
            this.mainpanel.Controls.Add(this.lb_ac_pwr);
            this.mainpanel.Controls.Add(this.lb_dc_pwr);
            this.mainpanel.Controls.Add(this.MB_Pwr_3);
            this.mainpanel.Controls.Add(this.ImpExMeter);
            this.mainpanel.Controls.Add(this.pic_grid_to);
            this.mainpanel.Controls.Add(this.pic_grid_from);
            this.mainpanel.Controls.Add(this.pic_PV_from);
            this.mainpanel.Controls.Add(this.grid);
            this.mainpanel.Controls.Add(this.PV_off);
            this.mainpanel.Controls.Add(this.PV_on);
            this.mainpanel.Controls.Add(this.house);
            this.mainpanel.Controls.Add(this.bat_SOE);
            this.mainpanel.Controls.Add(this.battery);
            this.mainpanel.Controls.Add(this.pic_bat_from);
            this.mainpanel.Controls.Add(this.pic_bat_to);
            this.mainpanel.Controls.Add(this.lb_temp);
            this.mainpanel.Controls.Add(this.Inverter_PIC);
            this.mainpanel.Location = new System.Drawing.Point(1, 1);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(743, 632);
            this.mainpanel.TabIndex = 77;
            this.mainpanel.Tag = "FIXEDCOLOR";
            this.mainpanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewEdge_MouseClick);
            // 
            // lb_version_copyright
            // 
            this.lb_version_copyright.AutoSize = true;
            this.lb_version_copyright.Location = new System.Drawing.Point(525, 608);
            this.lb_version_copyright.Name = "lb_version_copyright";
            this.lb_version_copyright.Size = new System.Drawing.Size(131, 16);
            this.lb_version_copyright.TabIndex = 81;
            this.lb_version_copyright.Text = "VERSION_Copyright";
            this.lb_version_copyright.Visible = false;
            // 
            // lb_upd
            // 
            this.lb_upd.BackColor = System.Drawing.Color.White;
            this.lb_upd.Image = global::EdgeMon.Properties.Resources.update_icon;
            this.lb_upd.Location = new System.Drawing.Point(655, 19);
            this.lb_upd.Name = "lb_upd";
            this.lb_upd.Size = new System.Drawing.Size(20, 20);
            this.lb_upd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lb_upd.TabIndex = 79;
            this.lb_upd.TabStop = false;
            this.tt.SetToolTip(this.lb_upd, "Update available");
            this.lb_upd.Visible = false;
            this.lb_upd.MouseEnter += new System.EventHandler(this.lb_upd_MouseEnter);
            // 
            // lb_OptionMenu
            // 
            this.lb_OptionMenu.BackColor = System.Drawing.Color.White;
            this.lb_OptionMenu.Image = global::EdgeMon.Properties.Resources.burger;
            this.lb_OptionMenu.Location = new System.Drawing.Point(685, 13);
            this.lb_OptionMenu.Name = "lb_OptionMenu";
            this.lb_OptionMenu.Size = new System.Drawing.Size(35, 37);
            this.lb_OptionMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lb_OptionMenu.TabIndex = 80;
            this.lb_OptionMenu.TabStop = false;
            this.lb_OptionMenu.Click += new System.EventHandler(this.lb_OptionMenu_Click);
            this.lb_OptionMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_OptionMenu_MouseDown);
            // 
            // AC_VOLTAGE_3
            // 
            this.AC_VOLTAGE_3.BackColor = System.Drawing.Color.White;
            this.AC_VOLTAGE_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AC_VOLTAGE_3.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AC_VOLTAGE_3.ForeColor = System.Drawing.Color.Black;
            this.AC_VOLTAGE_3.Location = new System.Drawing.Point(550, 351);
            this.AC_VOLTAGE_3.Name = "AC_VOLTAGE_3";
            this.AC_VOLTAGE_3.Size = new System.Drawing.Size(182, 15);
            this.AC_VOLTAGE_3.TabIndex = 78;
            // 
            // AC_CURRENT_3
            // 
            this.AC_CURRENT_3.BackColor = System.Drawing.Color.White;
            this.AC_CURRENT_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AC_CURRENT_3.Font = new System.Drawing.Font("Britannic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AC_CURRENT_3.ForeColor = System.Drawing.Color.Black;
            this.AC_CURRENT_3.Location = new System.Drawing.Point(550, 330);
            this.AC_CURRENT_3.Name = "AC_CURRENT_3";
            this.AC_CURRENT_3.Size = new System.Drawing.Size(181, 15);
            this.AC_CURRENT_3.TabIndex = 77;
            // 
            // BurgerMenuStrip
            // 
            this.BurgerMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.BurgerMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BurgerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.detailsToolStripMenuItem,
            this.detailsToolStripMenuItem1,
            this.detailsToolStripMenuItem2});
            this.BurgerMenuStrip.Name = "BurgerMenuStrip";
            this.BurgerMenuStrip.ShowCheckMargin = true;
            this.BurgerMenuStrip.ShowImageMargin = false;
            this.BurgerMenuStrip.Size = new System.Drawing.Size(170, 108);
            this.BurgerMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BurgerMenuStrip_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.toolStripMenuItem1.Text = "Configuration";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Checked = true;
            this.detailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem1
            // 
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.detailsToolStripMenuItem1.Text = "Darkmode";
            // 
            // detailsToolStripMenuItem2
            // 
            this.detailsToolStripMenuItem2.Name = "detailsToolStripMenuItem2";
            this.detailsToolStripMenuItem2.Size = new System.Drawing.Size(169, 26);
            this.detailsToolStripMenuItem2.Text = "Screenshot";
            // 
            // tt
            // 
            this.tt.BackColor = System.Drawing.Color.White;
            this.tt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tt.UseAnimation = false;
            this.tt.UseFading = false;
            // 
            // NewEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewEdge";
            this.Text = "Edgemon";
            this.TopMost = true;
            this.ResizeBegin += new System.EventHandler(this.NewEdge_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.NewEdge_ResizeEnd);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewEdge_MouseClick);
            this.Move += new System.EventHandler(this.NewEdge_Move);
            ((System.ComponentModel.ISupportInitialize)(this.battery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inverter_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.house)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_on)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PV_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PV_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grid_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_house_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bat_to)).EndInit();
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lb_upd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_OptionMenu)).EndInit();
            this.BurgerMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_batManu;
        private System.Windows.Forms.PictureBox battery;
        private System.Windows.Forms.PictureBox Inverter_PIC;
        private System.Windows.Forms.ProgressBar bat_SOE;
        private System.Windows.Forms.Label lb_temp;
        private System.Windows.Forms.PictureBox house;
        private System.Windows.Forms.PictureBox PV_on;
        private System.Windows.Forms.PictureBox PV_off;
        private System.Windows.Forms.PictureBox grid;
        private System.Windows.Forms.PictureBox pic_PV_from;
        private System.Windows.Forms.PictureBox pic_grid_from;
        private System.Windows.Forms.PictureBox pic_bat_from;
        private System.Windows.Forms.PictureBox pic_grid_to;
        private System.Windows.Forms.TextBox ImpExMeter;
        private System.Windows.Forms.TextBox MB_Pwr_3;
        private System.Windows.Forms.Label lb_dc_pwr;
        private System.Windows.Forms.Label lb_ac_pwr;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label lb_update;
        private System.Windows.Forms.Label lb_bat_stat;
        private System.Windows.Forms.Label lb_SOE_TXT;
        private System.Windows.Forms.Label lb_SOH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_bat_max;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_T_Av;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_batt_pwr;
        private System.Windows.Forms.Label lbl_mtr_manu;
        private System.Windows.Forms.Label lb_mtr_model;
        private System.Windows.Forms.Label lb_mtr_ver;
        private System.Windows.Forms.Label lb_mtr_opt;
        private System.Windows.Forms.Label lb_mtr_sernr;
        private System.Windows.Forms.Label lb_pwr_house;
        private System.Windows.Forms.Label lb_pwr_PV;
        private System.Windows.Forms.TextBox tb_Inv;
        private System.Windows.Forms.TextBox tb_chargepower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.TextBox lb_tot_prod;
        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.PictureBox pic_house_to;
        private System.Windows.Forms.PictureBox pic_bat_to;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.TextBox AC_VOLTAGE_3;
        private System.Windows.Forms.TextBox AC_CURRENT_3;
        private System.Windows.Forms.PictureBox lb_upd;
        private System.Windows.Forms.PictureBox lb_OptionMenu;
        private System.Windows.Forms.ContextMenuStrip BurgerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Label lb_version_copyright;
    }
}