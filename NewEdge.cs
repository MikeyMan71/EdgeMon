


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.IO;
using MAMconfig;
using System.Net;
using System.Text;
using WindowsInstaller;
using System.Security.Policy;

namespace EdgeMon
{
    public partial class NewEdge : Form
    {
        // MAMconfig.Config edgeconfig = new MAMconfig.Config("EdgeMon");
        EdgemonConfig pm;

        //    public static bool UsePrivateSettings = false;
        bool connected = false;
        bool have_battery = false;
        bool firstrun = false;
        //bool retry_battery = false;
        int detail_level = 2;
        bool show_details = true;

        // bool OneShot;// = Properties.Settings.Default.OneShot;
        int MultiShotIntervall;



        TcpModbus mb;
        Info infobox = new Info();

        public NewEdge()
        {
            


            
            pm = new EdgemonConfig(infobox.AssemblyVersion.ToString());

            InitializeComponent();
            this.Text += " "+infobox.AssemblyVersion.ToString();
            if (pm.TCP == "INVERTER") firstrun = true;


            MultiShotIntervall = pm.MultiShotIntervall;
            show_details = pm.showDetails;
            detail_level = pm.DetailLevel;


            timer2.Enabled = false;
            timer2.Interval = 10;
            // lb_about.Text = infobox.AssemblyCopyright + " V." + infobox.AssemblyVersion;
            mb = null;


            Thread.Sleep(1000);
            timer2.Enabled = true;


        }

        private bool checkForUpdate()
        {
            if (pm.checkUpdates)
            {
                bool res = false;
                try
                {

                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("https://edgemon.helioho.st/version");
                    StreamReader reader = new StreamReader(stream);
                    String content = reader.ReadToEnd();
                    Version Ver_running = infobox.AssemblyVersion;
                    Version Ver_server = new Version(content);
                    if (Ver_server.CompareTo(Ver_running) > 0)
                    {


                        res = true;
                    }


                    return res;
                }
                catch
                {
                    return res;
                }
            }
            return false;
        }

        private void init() {

           
          lb_upd.Visible = checkForUpdate();
          


            if (pm.battery_autodetect == true)
            {
                try
                {
                    if (mb.BatteryModelName.Length > 0 && mb.BatteryModelName != "NONE")
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
                if (ex is IndexOutOfRangeException) { }
                else
                {
                    lb_error.Text = ex.Message;
                    lb_error.ForeColor = Color.DarkRed;
                    optionalScreenshot(true);
                }
            }
            timer2.Interval = pm.refresh;

            if (pm.Darkmode) effect_darkmode();
            ((ToolStripMenuItem)(BurgerMenuStrip.Items[2])).Checked = pm.Darkmode;
            ((ToolStripMenuItem)(BurgerMenuStrip.Items[1])).Checked = pm.showDetails;
            


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
            lb_version_copyright.Text = "V " + infobox.AssemblyVersion.ToString() + " " + infobox.AssemblyCopyright.ToString();

            if (show_details && detail_level > 1)
            {

                lbl_mtr_manu.Show();
                lb_mtr_model.Show();
                lb_mtr_sernr.Show();
                lb_mtr_opt.Show();
                lb_mtr_ver.Show();

                tb_Inv.AppendText(mb.MTR_C_Manufacturer);
                tb_Inv.AppendText("\r\n" + mb.C_Model);
                tb_Inv.AppendText("\r\n" + mb.C_SerialNumber);
                tb_Inv.AppendText("\r\nSunspec:" + mb.C_SunSpec_DID);
                tb_Inv.AppendText("\r\nCPU:" + mb.C_Version);
                tb_Inv.AppendText("\r\nBUS_ID:" + mb.C_Device_Address);
                lbl_mtr_manu.Text = mb.MTR_C_Manufacturer;
                lb_mtr_model.Text = mb.MTR_C_Model;
                lb_mtr_sernr.Text = mb.MTR_C_SerNumber;
                lb_mtr_opt.Text = mb.MTR_C_Option;
                lb_mtr_ver.Text = mb.MTR_C_Version;
            }
            else
            {
                lbl_mtr_manu.Hide();
                lb_mtr_model.Hide();
                lb_mtr_sernr.Hide();
                lb_mtr_opt.Hide();
                lb_mtr_ver.Hide();

            }

            tb_batManu.Clear();
            tb_chargepower.Clear();

            if (have_battery)
            {
                if (show_details)
                {
                    if (detail_level > 0)
                    {
                        label_SOH.Show();
                        tb_chargepower.Hide();
                        lb_bat_max.Hide();
                        label9.Hide();
                        label3.Hide();
                    }
                    if (detail_level > 1)
                    {
                        tb_batManu.Show();
                        tb_chargepower.Show();
                        lb_bat_max.Show();
                        label9.Show();
                        label3.Show();

                        tb_batManu.AppendText(mb.BatteryManufacturerName);
                        tb_batManu.AppendText("\r\n" + mb.BatteryModelName);
                        tb_batManu.AppendText("\r\n" + mb.BatteryFirmware);
                        tb_batManu.AppendText("\r\n" + mb.BatterySerialNr);
                        tb_chargepower.AppendText(mb.Max_Charge_Continues_Power.ToString());
                        tb_chargepower.AppendText(" | " + mb.Max_Charge_Peak_Power);
                        lb_bat_max.Text = (mb.Batt_Max_Energy / 1000).ToString() + " kWh";
                    }
                    
                }


                else
                {
                    tb_batManu.Hide();
                    tb_chargepower.Hide();
                    lb_bat_max.Hide();
                    label9.Hide();
                    label3.Hide();
                    label_SOH.Hide();

                }
             

            }
            else
            {
                label_SOH.Hide();
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
              //  bat_SOE.Hide();
                lb_SOE_TXT.Text = "";
                lb_bat_stat.Text = "";
                lb_T_Av.Text = "";
                lb_batt_pwr.Text = "";
                label_SOH.Hide();
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
                if (show_details && detail_level > 0)
                {
                    

                    lb_SOH.Text = mb.SOH.ToString("#0.00") + " %";
                }
                else {
                   

                    lb_SOH.Text = ""; }
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

            if (show_details && detail_level > 0)
            {
                MB_Pwr_3.Text = mb.MTR_I_M_AC_Power_A.ToString() + " W" + " // " + mb.MTR_I_M_AC_Power_B.ToString() + " W" + " // " + mb.MTR_I_M_AC_Power_C.ToString() + " W";
            }
            else { MB_Pwr_3.Text = ""; }

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

                if (show_details && detail_level > 0)
                {
                    lb_total.Text = "TotEx: " + mb.Lifetime_Export_Energy_Counter.ToString() + " Wh\r\nTotIm: " + mb.Lifetime_Import_Energy_Counter.ToString() + " Wh";
                }
                else { lb_total.Text = ""; }
            }
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Continues_Power);
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Peak_Power);

            if (show_details && detail_level > 0)
            {
                lb_tot_prod.Text = "Tot.Prod: " + (mb.I_AC_Energy_WH / 1000000).ToString("f2") + " MWh\r\n";
            }
            else
            { lb_tot_prod.Text = ""; }


        }

        private void MainTimer_tick(object sender, EventArgs e)
        {


            try
            {

                if (firstrun)
                {
                    this.Hide();
                    timer2.Enabled = false;
                    Application.DoEvents();

                    MessageBox.Show("You seem to use Edegemon for the first time." + "\n" + "Please configure your inverter settings");
                   // if (pm.local_config)
                    {
                        DoConfig();
                        //infobox.conf = this.pm;
                        //infobox.conf.EditINI();
                        //this.pm = infobox.conf;

                    }
                    Application.Exit();
                }

                if (connected == false)
                {
                    try
                    {
                        Application.DoEvents();
                        ConnectToModbus();
                        connected = true;
                        init();
                    }
                    catch (Exception ex)
                    {
                        lb_error.Text = ex.Message;
                        lb_error.ForeColor = Color.DarkRed;
                        optionalScreenshot(true);
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

                optionalScreenshot();

            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException) { }
                else
                {
                    lb_error.Text = ex.Message;
                    lb_error.ForeColor = Color.DarkRed;
                    optionalScreenshot(true);
                }
            }

        }

        private void optionalScreenshot(bool err=false)
        {
            if ((connected || err) && MultiShotIntervall != 0)
            {
                MultiShotIntervall--;
                if (MultiShotIntervall == 0)
                {
                    MultiShotIntervall = pm.MultiShotIntervall;
                    SaveAsBitmap(this.mainpanel, pm.saveBitmap);
                }
            }
        }





        private void do_update()
        {
                   
          try
            {
         

                //Update dynamic values
                statusgraph_dyn();
                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
                timer2.Interval = pm.refresh;

            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException) { }
                else
                {


                    lb_error.Text = ex.Message;
                    lb_error.ForeColor = Color.Blue;

                }
                connected = false;
                timer2.Interval = 2000;
                mb.Disconnect();
                optionalScreenshot(true);


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
                lb_status.SendToBack();
                lb_version_copyright.Show();
                lb_OptionMenu.Hide();
                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
                lb_OptionMenu.Show();
                lb_version_copyright.Hide();  
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

        private void lb_set_Click(object sender, EventArgs e)
        {
          
        }

        private void Inverter_PIC_Click(object sender, EventArgs e)
        {
        






        }

      

        private void effect_details()
        {
           
            show_details = !show_details;
            this.statusgraph_static();
        }

        private void effect_darkmode()
        {

            //Darkmode
            if (this.mainpanel.BackColor == Color.White)
            {
                foreach (Control ctrl in this.mainpanel.Controls)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "FIXEDCOLOR") break;
                    if (ctrl is Label)
                    {
                        ((Label)ctrl).ForeColor = Color.White;
                    }
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ForeColor = Color.White;
                        ((TextBox)ctrl).BackColor = Color.Black;
                    }
                }
                this.mainpanel.BackColor = Color.Black;
                //Dirty bug workaround, I have no Idea why I need this... 
                ImpExMeter.BackColor = Color.Black;
                ImpExMeter.ForeColor = Color.White;
                MB_Pwr_3.BackColor = Color.Black;
                MB_Pwr_3.ForeColor = Color.White;
                grid.Image = Transform(grid.Image);
                PV_off.Image = Transform(PV_off.Image);
                battery.Image = Transform(battery.Image);
                lb_OptionMenu.Image = Transform(lb_OptionMenu.Image);
                lb_upd.Image = Transform(lb_upd.Image);
            }
            else
            {
                foreach (Control ctrl in this.mainpanel.Controls)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "FIXEDCOLOR") break;
                    if (ctrl is Label)
                    {
                        ((Label)ctrl).ForeColor = Color.Black;

                    }
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ForeColor = Color.Black;
                        ((TextBox)ctrl).BackColor = Color.White;
                    }
                }
                this.mainpanel.BackColor = Color.White;
                ImpExMeter.BackColor = Color.White;
                ImpExMeter.ForeColor = Color.Black;
                MB_Pwr_3.BackColor = Color.White;
                MB_Pwr_3.ForeColor = Color.Black;
                grid.Image = Transform(grid.Image);
                PV_off.Image = Transform(PV_off.Image);
                battery.Image = Transform(battery.Image);
                lb_OptionMenu.Image = Transform(lb_OptionMenu.Image);
                lb_upd.Image = Transform(lb_upd.Image);
            }
           
        }




        public Image Transform(Image source)
        {

            Bitmap pic = new Bitmap(source);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            //source = pic;
            return pic;
            
           // //create a blank bitmap the same size as original
           // Bitmap newBitmap = new Bitmap(source.Width, source.Height);

           // //get a graphics object from the new image
           // Graphics g = Graphics.FromImage(newBitmap);

           // // create the negative color matrix
           // ColorMatrix colorMatrix = new ColorMatrix();
           //  colorMatrix.Matrix00 = colorMatrix.Matrix11 = colorMatrix.Matrix22 = -1f;
           //  colorMatrix.Matrix33 = colorMatrix.Matrix44 = 1f;
           //// colorMatrix.Matrix00 = -1;
           //// colorMatrix.Matrix11 = 1;
           //// colorMatrix.Matrix22 = 1;
           //// colorMatrix.Matrix33 = 1;
           //// colorMatrix.Matrix44 = 1;



           // // create some image attributes
           // ImageAttributes attributes = new ImageAttributes();

           // attributes.SetColorMatrix(colorMatrix);

           // g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
           //             0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);

           // //dispose the Graphics object
           // g.Dispose();

           // return newBitmap;
        }


        private void lb_OptionMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var relativeClickedPosition = e.Location;
                var screenClickedPosition = (sender as Control).PointToScreen(relativeClickedPosition);
                BurgerMenuStrip.Show(screenClickedPosition);
               
                //BurgerMenuStrip.Visible = false;

            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DoConfig()
        {
            timer2.Stop();
            infobox.conf = this.pm;
            infobox.ShowDialog();
            this.pm = infobox.conf;
            timer2.Start();
        }

        private void BurgerMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text != "")
            {
                if (e.ClickedItem.Text == "Configuration")
                {
                   DoConfig();  

                }


                if (e.ClickedItem.Text == "Details")
                {
                    effect_details();
                    ((ToolStripMenuItem)(e.ClickedItem)).Checked = !((ToolStripMenuItem)(e.ClickedItem)).Checked;
                }
                if (e.ClickedItem.Text== "Darkmode")
                {
                    effect_darkmode();
                    ((ToolStripMenuItem)(e.ClickedItem)).Checked = !((ToolStripMenuItem)(e.ClickedItem)).Checked;
                    
                }
                if (e.ClickedItem.Text == "Screenshot")
                {
                    try { SaveAsBitmap(this.mainpanel, pm.saveBitmap); }
                    catch { }
                    MessageBox.Show("Screenshot saved in " + pm.saveBitmap);
                }
            }
        }

        private void NewEdge_Move(object sender, EventArgs e)
        {
            
        }

        private void NewEdge_ResizeEnd(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void NewEdge_ResizeBegin(object sender, EventArgs e)
        {
            timer2.Stop();
        }

      

        private void lb_upd_MouseEnter(object sender, EventArgs e)
        {
         
          //  tt.SetToolTip(lb_upd, "UPDATE AVAILABLE");
        }

        private void BurgerMenuStrip_VisibleChanged(object sender, EventArgs e)
        {
            if(!BurgerMenuStrip.Visible) {timer2.Start();} else {timer2.Stop();}
        }

        private void BurgerMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void lb_pwr_PV_Click(object sender, EventArgs e)
        {

        }

        private void lb_upd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("COMSPEC"), "/C " + "start " + "https://edgemon.helioho.st");
        }

        private void PV_off_Click(object sender, EventArgs e)
        {

        }
    }
}
