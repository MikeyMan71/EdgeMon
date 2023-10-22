


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace EdgeMon
{
    public partial class NewEdge : Form
    {
        bool connected = false;
        bool have_battery = false;
        bool oneShot = Properties.Settings.Default.OneShot;
        int shotcounter = Properties.Settings.Default.MultiShotIntervall;
      
                
            
    TcpModbus mb;
        Info infobox = new Info();
   
        public NewEdge()
        {
            
            InitializeComponent();
           

            timer2.Enabled = false;
            timer2.Interval = 10;
            lb_about.Text = infobox.AssemblyCopyright;
            mb = null;

            //do_update();
            timer2.Enabled = true;
            
        }


        private void init() { 
            //Battery present?
            try
            {
                if (mb.BatterySerialNr.Length > 0 && Properties.Settings.Default.battery == true)
                    have_battery = true;
            }
            catch (Exception)
            {
                have_battery=false;
            }

            PV_on.Hide();
            PV_off.Hide();

            try
            {
                statusgraph_static();
                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                lb_error.Text = ex.Message;
                lb_error.ForeColor = Color.DarkRed;
            }
            timer2.Interval = Properties.Settings.Default.refresh;


        }

        private void ConnectToModbus()
        {
            if (mb == null)
            {
                mb = new TcpModbus(Properties.Settings.Default.TCP, Properties.Settings.Default.port);
            }
            else //try reconnect. may take awhile...
            { 
                mb.Disconnect();
                Thread.Sleep(1000);
                mb.Connect(Properties.Settings.Default.TCP, Properties.Settings.Default.port);
            }
        
        }


        private void statusgraph_static()
        {
            
            


            tb_Inv.Clear();

            tb_Inv.AppendText(mb.MTR_C_Manufacturer);
            tb_Inv.AppendText("\r\n" + mb.C_Model);
            tb_Inv.AppendText("\r\n" + mb.C_SerialNumber);
            tb_Inv.AppendText("\r\nSunspec:" + mb.C_SunSpec_DID);
            tb_Inv.AppendText("\r\nCPU:" + mb.C_Version);



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

            lbl_mtr_manu.Text = mb.MTR_C_Manufacturer;
            lb_mtr_model.Text = mb.MTR_C_Model;
            lb_mtr_sernr.Text = mb.MTR_C_SerNumber;
            lb_mtr_opt.Text = mb.MTR_C_Option;
            lb_mtr_ver.Text = mb.MTR_C_Version;
           
                

            if (!have_battery)
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
                lb_SOH.Text = mb.SOH.ToString("#0.0") + " %";
                bat_SOE.Value = (int)mb.SOE;
                lb_SOE_TXT.Text = mb.SOE.ToString("#0.0") + " %";
                if (mb.Bat_Status != null) { lb_bat_stat.Text = mb.Bat_Status.ToString(); }
                lb_T_Av.Text = mb.Batt_Average_Temperature.ToString("#0.0") + "°C";
                lb_batt_pwr.Text = Instantaneous_Power.ToString() + " W \n\r" + mb.Instantaneous_Voltage.ToString("N0") + " V \n\r" + mb.Instantaneous_Current.ToString("N3") + " A ";
            }



            lb_status.Text = mb.I_Status.ToString();
           
            lb_ac_pwr.Text = I_AC_Power.ToString() + " W";
            lb_dc_pwr.Text = I_DC_Power.ToString() + " W";
            lb_temp.Text = mb.I_Temp_Sink.ToString() + "°C";
            ImpExMeter.Text = MTR_I_M_AC_Power.ToString() + " W";


            MB_Pwr_3.Text = mb.MTR_I_M_AC_Power_A.ToString() + " // " + mb.MTR_I_M_AC_Power_B.ToString() + " // " + mb.MTR_I_M_AC_Power_C.ToString();

            //  lb_T_max.Text = mb.Batt_Max_Temperature.ToString();
            pwr_house = I_AC_Power - MTR_I_M_AC_Power;
            pwr_PV = I_DC_Power + Instantaneous_Power;
            if (I_DC_Power < I_AC_Power) { pwr_house = pwr_house - (I_AC_Power - I_DC_Power); } //inverter drawing power from grid
            lb_pwr_house.Text = pwr_house.ToString() + " W";

            if (pwr_PV < 0) pwr_PV = 0;
            lb_pwr_PV.Text = pwr_PV.ToString("N1") + " W";
            if (pwr_PV > 0 && PV_on.Visible == false) { PV_off.Hide(); PV_on.Show(); }
            if (pwr_PV <= 0 && PV_off.Visible == false) { PV_off.Show(); PV_on.Hide(); }

            if (MTR_I_M_AC_Power < 0) { pic_grid_to.Hide(); pic_grid_from.Show(); }
            else
            if (MTR_I_M_AC_Power > 0) { pic_grid_to.Show(); pic_grid_from.Hide(); }
            else
            { pic_grid_to.Hide(); pic_grid_from.Hide(); }

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
            lb_tot_prod.Text = "Tot.Prod: " + (mb.I_AC_Energy_WH / 1000000).ToString("f3") + " MWh\r\n";



        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            do_update();
            lb_update.Text = DateTime.Now.ToString();
            if (connected && oneShot)
            {
                ImpExMeter.BackColor = Color.White;
                SaveAsBitmap(this.mainpanel, Properties.Settings.Default.saveBitmap);
                Environment.Exit(0);
            }
            if (connected && shotcounter != 0)
            {
                shotcounter--;
                if (shotcounter == 0) 
                { shotcounter = Properties.Settings.Default.MultiShotIntervall;
                    SaveAsBitmap(this.mainpanel, Properties.Settings.Default.saveBitmap);
                }
            }

           
        }

        private void do_update()
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


            try
            {
                statusgraph_dyn();
                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
                timer2.Interval = Properties.Settings.Default.refresh;

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

                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));

                //restore order
               battery.SendToBack();
               Inverter_PIC.SendToBack();
           
               
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
           
            infobox.Show();
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
