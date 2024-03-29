﻿


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.IO;

using MAMconfig;

namespace EdgeMon
{
    public partial class NewEdge : Form
    {
        // MAMconfig.Config edgeconfig = new MAMconfig.Config("EdgeMon");
        EdgemonConfig pm;

    //    public static bool UsePrivateSettings = false;
        bool connected = false;
        bool have_battery = false;
        //bool retry_battery = false;



       // bool OneShot;// = Properties.Settings.Default.OneShot;
       int MultiShotIntervall;
       
        

        TcpModbus mb;
        Info infobox = new Info();

        public NewEdge()
        {
            pm = new EdgemonConfig();

            InitializeComponent();
           
      
            MultiShotIntervall = pm.MultiShotIntervall;
            

            timer2.Enabled = false;
            timer2.Interval = 10;
            lb_about.Text = infobox.AssemblyCopyright + " V." + infobox.AssemblyVersion;
            mb = null;

            //do_update();

            //if (File.Exists("UsePrivateSettings")) UsePrivateSettings = true;
            //// Copy user settings from previous application version if necessary
            //if (UsePrivateSettings && Properties.Settings.Default.UpdateSettings)
            //{
            //    MessageBox.Show("Upgrading to " + String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            //    Properties.Settings.Default.Upgrade();
            //    Properties.Settings.Default.UpdateSettings = false;
            //    Properties.Settings.Default.Save();
            //}

            timer2.Enabled = true;
        }


        private void init() {

            if (pm.battery_autodetect == true)
            {
                try
                {
                    if (mb.BatterySerialNr.Length > 0)
                        have_battery = true;
                }
                catch (Exception)
                {
                    have_battery = false;
                }
            }
            else
            {
                have_battery = pm.battery;
            }
   
            PV_on.Hide();
            PV_off.Hide();

            try
            {

                //STATIC GRAPH
                statusgraph_static();
                //

                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                lb_error.Text = ex.Message;
                lb_error.ForeColor = Color.DarkRed;
            }
            timer2.Interval = pm.refresh;


        }

        /// <summary>
        /// Handle all config data form ini files
        /// </summary>
        //public void GetAllConfigData()
        //{

        //    pm.TCP = Properties.Settings.Default.TCP;
        //    pm.port = Properties.Settings.Default.port; ;
        //    pm.battery = Properties.Settings.Default.battery;
        //    pm.refresh = Properties.Settings.Default.refresh;
        //    pm.saveBitmap = Properties.Settings.Default.saveBitmap;
        //    pm.OneShot = Properties.Settings.Default.OneShot;
        //    pm.MultiShotIntervall = Properties.Settings.Default.MultiShotIntervall;
        //    pm.battery_autodetect = Properties.Settings.Default.battery_autodetect;
        //    pm.gridflow_threshold = Properties.Settings.Default.gridflow_threshold;
          

            
        //    pm.TCP = edgeconfig.Get("TCP", pm.TCP);
        //    pm.port= edgeconfig.Get("port", pm.port);
        //    pm.battery = edgeconfig.Get("battery", pm.battery);
        //    pm.refresh = edgeconfig.Get("refresh", pm.refresh);
        //    pm.saveBitmap=edgeconfig.Get("saveBitmap", pm.saveBitmap);
        //    pm.OneShot =edgeconfig.Get("OneShot", pm.OneShot);
        //    pm.MultiShotIntervall=edgeconfig.Get("MultiShotIntervall", pm.MultiShotIntervall);
        //    pm.battery_autodetect =edgeconfig.Get("battery_autodetect", pm.battery_autodetect);
        //    pm.gridflow_threshold=edgeconfig.Get("gridflow_threshold", pm.gridflow_threshold);
            
            
        //    edgeconfig.WriteINI();

        //    MessageBox.Show(pm.gridflow_threshold.ToString());

        //}


        private void ConnectToModbus()
        {
            if (mb == null)
            {
                mb = new TcpModbus(pm.TCP, pm.port);
            }
            else //try reconnect. may take awhile...
            { 
                mb.Disconnect();
                Thread.Sleep(1000);
                mb.Connect(pm.TCP, pm.port);
            }
        
        }

        /// <summary>
        /// Static setup of graph
        /// </summary>
        private void statusgraph_static()
        {


            tb_Inv.Clear();

            tb_Inv.AppendText(mb.MTR_C_Manufacturer);
            tb_Inv.AppendText("\r\n" + mb.C_Model);
            tb_Inv.AppendText("\r\n" + mb.C_SerialNumber);
            tb_Inv.AppendText("\r\nSunspec:" + mb.C_SunSpec_DID);
            tb_Inv.AppendText("\r\nCPU:" + mb.C_Version);

            lbl_mtr_manu.Text = mb.MTR_C_Manufacturer;
            lb_mtr_model.Text = mb.MTR_C_Model;
            lb_mtr_sernr.Text = mb.MTR_C_SerNumber;
            lb_mtr_opt.Text = mb.MTR_C_Option;
            lb_mtr_ver.Text = mb.MTR_C_Version;

            tb_batManu.Clear();
            tb_chargepower.Clear();

            if (have_battery)
            {
                tb_batManu.AppendText(mb.BatteryManufacturerName);
                tb_batManu.AppendText("\r\n" + mb.BatteryModelName);
                tb_batManu.AppendText("\r\n" + mb.BatteryFirmware);
                tb_batManu.AppendText("\r\n" + mb.BatterySerialNr);
                tb_chargepower.AppendText(mb.Max_Charge_Continues_Power.ToString());
                tb_chargepower.AppendText(" | " + mb.Max_Charge_Peak_Power);
                lb_bat_max.Text = (mb.Batt_Max_Energy / 1000).ToString() + " kWh";
            }
            else
            {
                bat_SOE.Hide();
                pic_bat_from.Hide();
                pic_bat_to.Hide();
                battery.Hide();
                lb_T_Av.Hide();
                lb_batt_pwr.Hide();
                lb_bat_max.Hide();
                lb_batt_pwr.Hide();
                lb_bat_stat.Hide();
                lb_SOH.Hide();
                bat_SOE.Hide();
                lb_SOE_TXT.Text = "";
                lb_bat_stat.Text = "";
                lb_T_Av.Text = "";
                lb_batt_pwr.Text = "";
                label7.Hide();
                label9.Hide();
                label11.Hide();
                label3.Hide();
                lb_total.Hide();
            }
        }




        private void statusgraph_dyn()
        {
            double pwr_house, pwr_PV;
            double I_AC_Power = mb.I_AC_Power;
            double I_DC_Power = mb.I_DC_Power;
            double MTR_I_M_AC_Power = mb.MTR_I_M_AC_Power;
            double Instantaneous_Power = mb.Instantaneous_Power;
            

            
            
            
            if (have_battery)
            {
                lb_SOH.Text = mb.SOH.ToString("#0.00") + " %";
                bat_SOE.Value = (int)mb.SOE;
                lb_SOE_TXT.Text = mb.SOE.ToString("#0.00") + " %";
                if (mb.Bat_Status != null) { lb_bat_stat.Text = mb.Bat_Status.ToString(); }
                lb_T_Av.Text = mb.Batt_Average_Temperature.ToString("#0.00") + "°C";
                lb_batt_pwr.Text = Instantaneous_Power.ToString("N2") + " W \n\r" + mb.Instantaneous_Voltage.ToString("N0") + " V \n\r" + mb.Instantaneous_Current.ToString("N2") + " A ";
            }



            lb_status.Text = mb.I_Status.ToString();

            lb_ac_pwr.Text = I_AC_Power.ToString("N2") + " W";
            lb_dc_pwr.Text = I_DC_Power.ToString("N2") + " W";
            lb_temp.Text = mb.I_Temp_Sink.ToString("N2") + "°C";
            ImpExMeter.Text = MTR_I_M_AC_Power.ToString("N2") + " W";


            MB_Pwr_3.Text = mb.MTR_I_M_AC_Power_A.ToString()+" W" + " // " + mb.MTR_I_M_AC_Power_B.ToString()+" W" + " // " + mb.MTR_I_M_AC_Power_C.ToString()+" W";

            //  lb_T_max.Text = mb.Batt_Max_Temperature.ToString();
            pwr_house = I_AC_Power - MTR_I_M_AC_Power;
            pwr_PV = I_DC_Power + Instantaneous_Power;
            if (I_DC_Power < I_AC_Power) { pwr_house = pwr_house - (I_AC_Power - I_DC_Power); } //inverter drawing power from grid
            lb_pwr_house.Text = pwr_house.ToString("N2") + " W";


            //AC_CURRENT_3.Text = mb.I_AC_CurrentA.ToString() + " // " + mb.I_AC_CurrentB.ToString() + " // " + mb.I_AC_CurrentC.ToString();
            //AC_VOLTAGE_3.Text = (mb.I_AC_CurrentA*240).ToString() + " // " + (mb.I_AC_CurrentB * 240).ToString() + " // " + (mb.I_AC_CurrentC * 240).ToString();
         
           



            if (pwr_PV < 0) pwr_PV = 0;
            lb_pwr_PV.Text = pwr_PV.ToString("N2") + " W";
            if (pwr_PV > 0 && PV_on.Visible == false) { PV_off.Hide(); PV_on.Show(); pic_PV_from.Show(); }
            if (pwr_PV <= 0 && PV_off.Visible == false) { PV_off.Show(); PV_on.Hide(); pic_PV_from.Hide(); }
          

            if (MTR_I_M_AC_Power < -pm.gridflow_threshold) { pic_grid_to.Hide(); pic_grid_from.Show(); pic_house_to.Image = Properties.Resources.arrow3; }
            else
            if (MTR_I_M_AC_Power > pm.gridflow_threshold) { pic_grid_to.Show(); pic_grid_from.Hide(); pic_house_to.Image = Properties.Resources.arrow3_GREEN; }
            else
            { pic_grid_to.Hide(); pic_grid_from.Hide(); 
                
                pic_house_to.Image = Properties.Resources.arrow3_GREEN;
            }
            if (pwr_house == 0) { pic_house_to.Hide(); } else { pic_house_to.Show(); }
            if (have_battery)
            {
                if (Instantaneous_Power < 0) { pic_bat_to.Hide(); pic_bat_from.Show(); }
                else
                if (Instantaneous_Power > 0) { pic_bat_to.Show(); pic_bat_from.Hide(); }
                else
                { pic_bat_to.Hide(); pic_bat_from.Hide(); }

                lb_total.Text = "TotEx: " + mb.Lifetime_Export_Energy_Counter.ToString() + " Wh\r\nTotIm: " + mb.Lifetime_Import_Energy_Counter.ToString() + " Wh";
            }
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Continues_Power);
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Peak_Power);
            lb_tot_prod.Text = "Tot.Prod: " + (mb.I_AC_Energy_WH / 1000000).ToString("f2") + " MWh\r\n";



        }

        private void MainTimer_tick(object sender, EventArgs e)
        {
            try
            {
                if (connected == false)
                {
                    try
                    {
                        ConnectToModbus();
                        connected = true;
                        init();
                    }
                    catch (Exception ex)
                    {
                        lb_error.Text = ex.Message;
                        lb_error.ForeColor = Color.DarkRed;
                        return;
                    }
                }

                //Main Update processes
                do_update();
                //

                lb_update.Text = DateTime.Now.ToString();
                if (connected && pm.OneShot)
                {
                    ImpExMeter.BackColor = Color.White;
                    SaveAsBitmap(this.mainpanel, pm.saveBitmap);
                    Environment.Exit(0);
                }
                if (connected && MultiShotIntervall != 0)
                {
                    MultiShotIntervall--;
                    if (MultiShotIntervall == 0)
                    {
                        MultiShotIntervall = pm.MultiShotIntervall;
                        SaveAsBitmap(this.mainpanel, pm.saveBitmap);
                    }
                }
            }
            catch (Exception ex)
            {
                lb_error.Text = ex.Message;
                lb_error.ForeColor = Color.DarkRed;
            }

        }

        private void do_update()
        {
                   
            try
            {
                //if (have_battery == false && retry_battery == true) //no battery found, but config says there should be one...
                //{
                //    if (mb.BatterySerialNr.Length > 0 && Properties.Settings.Default.battery == true) { have_battery = true; retry_battery = false; }
                //}

                //Update dynamic values
                statusgraph_dyn();
                //

                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
                timer2.Interval = pm.refresh;

            }
            catch (Exception ex)
            {
                lb_error.Text = ex.Message;
                lb_error.ForeColor = Color.DarkRed;
                connected = false;
                timer2.Interval = 2000;
                mb.Disconnect();
              
            }
        }

        private void SaveAsBitmap(Panel form, string fileName)
        {
          
            try
            {
     
                Graphics g = form.CreateGraphics();
                Bitmap bmp = new Bitmap(form.Width, form.Height);
                //reverse order of overlaying controls - this is due to a bug in DrwaToBitmap
                lb_temp.SendToBack();
               bat_SOE.SendToBack();
                lb_ac_pwr.SendToBack();
                pic_bat_from.SendToBack();
                pic_bat_to.SendToBack();

                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));

                //restore order
               battery.SendToBack();
               Inverter_PIC.SendToBack();
                pic_grid_to.SendToBack();
                pic_grid_from.SendToBack();
                lb_batt_pwr.SendToBack();

                SaveImage(bmp, fileName);
                bmp.Dispose();
            }
            catch (Exception)
            {
                //restore order
                battery.SendToBack();
                Inverter_PIC.SendToBack();
         
            }
            
        }
     

        private void label4_Click(object sender, EventArgs e)
        {

            infobox.conf = this.pm;
            infobox.ShowDialog();
            this.pm = infobox.conf;

        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        private void NewEdge_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
               this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
