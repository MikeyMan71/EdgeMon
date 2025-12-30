




#define DEBUG

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EdgeMon
{
    public partial class MainEdge : Form
    {
        MyWebClient client = new MyWebClient();


        // MAMconfig.Config edgeconfig = new MAMconfig.Config("EdgeMon");
        EdgemonConfig pm;

        Debugfile dbg;

        //    public static bool UsePrivateSettings = false;
        bool Suppress_Mainthread = false;
        bool connected = false;
        bool have_battery = false;
        bool firstrun = false;
        bool neverconnected = true;
        //bool retry_battery = false;
        int detail_level = 2;
        bool show_details = true;
        bool initialized = false;
        bool suppress_oneshot = false;
        // bool OneShot;// = Properties.Settings.Default.OneShot;
        int MultiShotIntervall;
        int errcount = 0;
        int retrycount = 0;
        string precision = "N0";
        bool hasupdate = false;
        DateTime startdate = DateTime.Now;
        DateTime lastdailyupdate = DateTime.Now;
        TimeSpan checklocation = new TimeSpan(0, 30, 0);

        TcpModbus mb;
        Info infobox = new Info();
        SunriseSunset sundata;
        Color dark = Color.FromArgb(30, 30, 30);

        Point def_PV_off;
        Point def_PV_on;
        Point def_fullPVpanel;
        Point def_grid;
        Point def_house;
        Point def_battery;
        Point def_lb_SOE_TXT;
        Point def_bat_SOE;
        Point def_lb_m_batt_pwr_main;
        Point def_lb_m_ImpExMeter;
        Point def_lb_m_pwr_house;
        Point def_lb_m_pwr_PV;

        int ec = 1;
        string es = "";

        HWData hwdata = new HWData();

        public MainEdge()
        {

            if (Process.GetProcessesByName("EdgeMon").Length > 1)
            {
                MessageBox.Show("There is already an instance of EdgeMon running");
                Environment.Exit(0);
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Thread.CurrentThread.CurrentUICulture.ToString());
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = "";


            InitializeComponent();
            maketransparent(lb_status, Inverter_PIC);
            maketransparent(lb_temp, Inverter_PIC);

            foreach (Control item in mainpanel.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Click += new EventHandler(tb_Inv_Enter);
                
                }


            }


            this.Splashpanel.Size = this.mainpanel.Size;
            pm = new EdgemonConfig(infobox.AssemblyVersion.ToString());
            if (pm.debug)
            {
                dbg = new Debugfile("Edgemon");
                dbg.add(DateTime.Now.ToString());
                dbg.add(pm.Version);
               
            }


            def_PV_off = PV_off.Location;
            def_PV_on = PV_on.Location;
            def_fullPVpanel = fullPVpanel.Location;
            def_grid = grid.Location;
            def_house = house.Location;
            def_battery = battery.Location;
            def_lb_SOE_TXT = lb_SOE_TXT.Location;
            def_bat_SOE = bat_SOE.Location;
            def_lb_m_batt_pwr_main = lb_m_batt_pwr_main.Location;
            def_lb_m_ImpExMeter = lb_m_ImpExMeter.Location;
            def_lb_m_pwr_house = lb_m_pwr_house.Location;
            def_lb_m_pwr_PV = lb_m_pwr_PV.Location;

            ComboDetailLevel.ComboBox.DataSource = new int[] { 0, 1, 2, 3 };
            ComboDetailLevel.SelectedIndex = pm.DetailLevel;



            restartMe();
        }

        private void MainTimer_tick(object sender, EventArgs e)
        {
            if (Suppress_Mainthread)
            {
                
               
                return;
            }
            try
            {
                if ((!sundata.isvalid) && (startdate > DateTime.Now.Subtract(checklocation)))
                {


                    if (sundata.getlocation())
                    {
                        dailyTasks(true);
                    }

                }


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
                 //       Application.DoEvents();
                        timer2.Stop();
                        ConnectToModbus();
                        timer2.Start();
                        connected = true;
                        neverconnected = false;
                        init();
                        Splashpanel.Hide();
                        Splashpanel.Tag = null;
                    }
                    catch (Exception ex)
                    {
                        if (pm.debug)
                        {
                            if (connected && !initialized)
                            {
                                // Get stack trace for the exception with source file information
                                var st = new StackTrace(ex, true);
                                // Get the top stack frame
                                var frame = st.GetFrame(0);
                                // Get the line number from the stack frame
                                var line = frame.GetFileLineNumber();
                                //timer2.Stop();

                                dbg.add("Unexpected Error: " + ex.ToString() + " in line " + line.ToString() + "\n" + "Errorcode+String: " + ec.ToString() + " " + es);
                                //                         Environment.Exit(0);
                            }

                        }
                        lb_error.ForeColor = Color.DarkRed;
                        lb_error.Text = ex.Message;

                        if (neverconnected && Splashpanel.Visible)
                        {
                            if (Splashpanel.Tag == null || !Splashpanel.Tag.ToString().Contains("small"))
                            {
                                foreach (Control c in Splashpanel.Controls) { c.Location = new Point(c.Location.X, c.Location.Y - 40); }

                                Splashpanel.Location = new Point(Splashpanel.Location.X, Splashpanel.Location.Y + 40);
                                Splashpanel.Size = new Size(this.Width, this.Height - 40);
                                lb_sp_connecting.Visible = true;
                                Splashpanel.Tag = "small";

                            }
                        }
                        else
                        {
                        
                        }

                        errcount++;
                        if (errcount > 5 || pm.port == 0)
                        {
                            errcount = 0;
                            if (pm.port != 0)
                            {
                                lb_error.Text = ex.Message;
                                lb_error.ForeColor = Color.DarkRed;
                                optionalScreenshot(true);
                            }
                            if (neverconnected || pm.port == 0)
                            {
                                switch (pm.port)
                                {
                                    case 502:
                                        pm.port = 1502;
                                        pm.SetAllConfigData();
                                        pm.WriteINI();
                                        break;
                                    case 1502:
                                        pm.port = 502;
                                        pm.SetAllConfigData();
                                        pm.WriteINI();
                                        break;
                                    default:
                               /*         if (pm.port != 1502)
                                        {
                                            pm.port = 1502;
                                            pm.SetAllConfigData();
                                            pm.WriteINI();
                                        }*/
                                        break;
                                }

                            }
                        }

                        timer2.Start();
                        // return;
                    }
                }

                //Main Update processes

                if (connected) do_update();
                //

                lb_update.Text = DateTime.Now.ToString();
                if (connected && pm.OneShot && !suppress_oneshot)
                {
                    lb_m_ImpExMeter.BackColor = Color.White;
                    SaveBitmapAndData(this.mainpanel, pm.saveBitmap);

                    Environment.Exit(0);
                }

                optionalScreenshot();
                lb_upd.Visible = hasupdate;
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


        public void restartMe()
        {
            reset_all_detaillevel();




            neverconnected = true;
            lb_sunrise.Text = "";
            lb_sunset.Text = "";
            sundata = new SunriseSunset(pm.loc_latitude, pm.loc_longitude, TimeZoneInfo.Local);

            timer2.Stop();
            connected = false;
            this.Text = "EdgeMon " + infobox.AssemblyVersion.ToString();
            if (pm.TCP == "INVERTER") firstrun = true;

            MultiShotIntervall = pm.MultiShotIntervall;
            show_details = true;
            //  show_details = pm.showDetails;
            detail_level = pm.DetailLevel;
            reset_all_detaillevel();
            //   SubiconLayout = pm.SubiconLayout;
            //   timer2.Enabled = false;
            timer2.Interval = 20;
            // lb_about.Text = infobox.AssemblyCopyright + " V." + infobox.AssemblyVersion;

            if (mb != null) {
                var rest = mb.receiveData;
                mb.Disconnect();
                 }
            mb = null;


            Thread.Sleep(100);

            //timer2.Enabled = true;
            timer2.Start();
            startdate = DateTime.Now;

        }


        private void init()
        {


             //mb.LogFileFilename = dbg.Pfad + "\\" + "modbuslog.txt";


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

if (pm.debug)            ec = ec >> 1;




            try
            {
                

                //STATIC GRAPH
                statusgraph_static();
                //
                if (pm.debug) {
                    ec = ec >> 1;
                    es = tb_Inv.Text + " XXX " + lb_mtr_model.Text + " XXX ";
                }

                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
if (pm.debug)
                { 
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                es += "statusgraph_static error: Line " + line.ToString();
}


                if (ex is IndexOutOfRangeException) { }
                else
                {
                    lb_error.Text = ex.Message;
                    lb_error.ForeColor = Color.DarkRed;
                    optionalScreenshot(true);
                }
            }
            
            timer2.Interval = pm.refresh;

          
            statusgraph_dyn();
      

if (pm.debug)            ec = ec>>1;

            if (pm.Darkmode) darkmode_on(true); else darkmode_off();
            Splashpanel.Hide();
            this.Update();
            

           // if (pm.Darkmode) darkmode_on(); else darkmode_off();

            ((ToolStripMenuItem)(BurgerMenuStrip.Items[2])).Checked = pm.Darkmode;
            ((ToolStripMenuItem)(BurgerMenuStrip.Items[1])).Checked = pm.showDetails;
            initialized = true;
            this.Update();

          

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

        private async Task ConnectToModbus()
        {
          
            
            if (mb == null)
            {
                
                mb = new TcpModbus(pm.TCP, pm.port);
                
            }
            else //try reconnect. may take awhile...
            {
                retrycount++;
                if (retrycount > 5)
                {
                    retrycount = 0;
                    var restdata = mb.receiveData;
                    mb.Disconnect();
                    mb = null;

                    lb_error.ForeColor = Color.Orange;
                   lb_error.Text = "Retry in 3min";
                    Suppress_Mainthread = true;
                    this.Refresh();

                 

                    for (int i = 3*60; i  >0; i--)
                    {
                        lb_error.Text = "Retry in " + i.ToString() + " sec";
                        lb_update.Text = DateTime.Now.ToString();
                        Thread.Sleep(1000);
                        this.Refresh();
                        Application.DoEvents();
                    }

                    Suppress_Mainthread = false;
                   

                    mb = new TcpModbus(pm.TCP, pm.port);
                }
                else
                {
                    var rest = mb.receiveData;
                    mb.Disconnect();
                    Thread.Sleep(100);
                    mb.Connect(pm.TCP, pm.port);
                }

            }

        }


        private void checkForUpdate()
        {

            //HttpClient client = new HttpClient();
            if (Update_check_timer.Interval < 100000) Update_check_timer.Interval = 9000000;

            //#if MSSTORE
            if (pm.checkUpdates)
            {


                Task.Run(() =>
                {

                    try
                    {
                        //client.GetStringAsync("https://edgemon.helioho.st/version");
                        String content = client.DownloadString("https://edgemon.helioho.st/version");
                        Version Ver_running = infobox.AssemblyVersion;
                        Version Ver_server = new Version(content);
                        if (Ver_server.CompareTo(Ver_running) > 0)
                        {
                            hasupdate = true;
                        }

                    }
                    catch
                    {
                        hasupdate = false;
                    }
                });
            }
            //#endif

        }

        /// <summary>
        /// Static setup of graph
        /// </summary>
        private void statusgraph_static()
        {
            
           // var debgread = mb.C_Manufacturer;
           // debgread += mb.C_Manufacturer;

            if (pm.debug)
            {
               // dbg.add("DEBGREAD: "+debgread);
                string dbgread = "NULL";
                try
                {
                    dbgread = mb.C_Manufacturer;
                    dbg.add("C_Manufacturer: " + dbgread);
                }
                catch (Exception)
                {
                    dbg.add("ERR: C_Manufacturer: "+dbgread);
                }
                try
                {
                    dbgread = mb.MTR_C_Manufacturer;
                    dbg.add("MTR_C_Manufacturer: " + dbgread);
                }
                catch (Exception)
                {
                    dbg.add("ERR: MTR_C_Manufacturer: " + dbgread);
                }
                try
                {
                    dbgread = mb.C_Version.ToString();
                    dbg.add("C_Version: " + dbgread);
                }
                catch (Exception)
                {
                    dbg.add("ERR: C_Version: " + dbgread);
                }
                try
                {
                    dbgread = mb.C_Device_Address.ToString();
                    dbg.add("C_Device_Address: " + dbgread);
                }
                catch (Exception)
                {
                    dbg.add("ERR: C_Device_Address: " + dbgread);
                }
                try
                {
                    dbgread = mb.C_SunSpec_DID.ToString();
                    dbg.add("C_SunSpec_DID: " + dbgread);
                }
                catch (Exception)
                {
                    dbg.add("ERR: C_SunSpec_DID: " + dbgread);
                }
            
            
            }


            tb_Inv.Clear();
            lb_version_copyright.Text = "EdgeMon V " + infobox.AssemblyVersion.ToString() + " " + infobox.AssemblyCopyright.ToString();
            lb_ac_pwr.Text = "";
            lb_dc_pwr.Text = "";
            MB_Pwr_3.Text = "";
            vanillaview(false);

            if (show_details && detail_level > 2)
            {

                lbl_mtr_manu.Show();
                lb_mtr_model.Show();
                lb_mtr_sernr.Show();
                lb_mtr_opt.Show();
                lb_mtr_ver.Show();
               // var rest = mb.receiveData;
                tb_Inv.AppendText(mb.C_Manufacturer);
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
                lb_T_Av.Hide();
                lb_SOH.Hide();
                label11.Hide();
                label_SOH.Hide();

                bat_SOE.Show();
                battery.Show();
                label3.Hide();
                label9.Hide();
                tb_chargepower.Hide();
                lb_bat_max.Hide();

                lb_m_batt_pwr.Hide();
                lb_m_batt_pwr_main.Show();
                if (show_details & detail_level > 0)
                {


                    lb_bat_stat.Show();


                    if (show_details & detail_level > 1)
                    {

                        lb_T_Av.Show();
                        label11.Show();
                        label_SOH.Show();
                        lb_SOH.Show();
                        // tb_chargepower.Hide();
                        // lb_bat_max.Hide();


                        lb_m_batt_pwr.Show();



                        if (detail_level > 2)
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
                   
                }

                else
                {


                    lb_bat_stat.Hide();
                    lb_T_Av.Hide();
                    tb_batManu.Hide();
                    tb_chargepower.Hide();
                    lb_bat_max.Hide();
                    label9.Hide();
                    label3.Hide();
                    label_SOH.Hide();
                    label11.Hide();
                }


            }
            else
            {
                label_SOH.Hide();
                pic_bat_no.Visible = false;
                pic_bat_from.Hide();
                pic_bat_to.Hide();
                pic_bat_no.Hide();
                battery.Hide();
                lb_m_batt_pwr_main.Hide();
                lb_m_batt_pwr.Hide();
                lb_bat_max.Hide();
                lb_bat_stat.Hide();
                lb_SOH.Hide();
                bat_SOE.Hide();
                lb_SOE_TXT.Text = "";
                lb_bat_stat.Text = "";
                lb_T_Av.Text = "";
                lb_m_batt_pwr.Text = "";
                label_SOH.Hide();
                label9.Hide();
                label11.Hide();
                label3.Hide();
                lb_total.Hide();
            }
            if (!show_details || detail_level <= 1)
            //  if (pm.SubiconLayout)
            {
                vanillaview(true);

            }

            dailyTasks(true);
            //if (show_details && detail_level > 0 && sundata != null && sundata.isvalid)
            //{
            //    lb_sunrise.Visible = true;
            //    lb_sunset.Visible = true;
            //    pic_sunsetrise.Visible = true;
            //}
            //else
            //{
            //    lb_sunrise.Visible = false;
            //    lb_sunset.Visible = false;
            //    pic_sunsetrise.Visible = false;
            //}
            if (pm.debug) { dbg.add("Static Data  section End Reached"); }

        }



        private void statusgraph_dyn()
        {
            ///
            ///GATHER DATA
            ///


            


            double pwr_house, pwr_PV;
            double I_AC_Power = mb.I_AC_Power;
            double I_DC_Power = mb.I_DC_Power;
            double MTR_I_M_AC_Power = mb.MTR_I_M_AC_Power;
            double Instantaneous_Power = mb.Instantaneous_Power;
            double MTR_I_M_AC_Power_A =  mb.MTR_I_M_AC_Power_A;
            double MTR_I_M_AC_Power_B = mb.MTR_I_M_AC_Power_B;
            double MTR_I_M_AC_Power_C =  mb.MTR_I_M_AC_Power_C;

            

          

            if (have_battery)
            {
                hwdata.SOH = mb.SOH.ToString(precision) + " %";

                hwdata.bat_SOE = mb.SOE.ToString("N1") + " %";
                hwdata.SOE = (int)mb.SOE;
                if (mb.Bat_Status != null) { hwdata.Bat_Status = mb.Bat_Status.ToString(); }
                hwdata.T_AV = mb.Batt_Average_Temperature.ToString(precision) + "°C";
                hwdata.batt_pwr_main = Instantaneous_Power.ToString(precision) + " W";
                //if (show_details && detail_level > 0)
                hwdata.batt_pwr = (mb.Instantaneous_Voltage.ToString("N0") + " V \n\r" + mb.Instantaneous_Current.ToString(precision) + " A ");

            }

         
            if (mb.I_Status != null)
            {
                Thread.Sleep(1000);
                if (mb.I_Status != null)
                {
                    hwdata.status = mb.I_Status.ToString();
                }
            }
            else {
                if (pm.debug) { dbg.add("InverterStatus NULL ERROR"); }
                hwdata.status = "ERROR";
                throw new Exception("INVERTER STATUS READ ERROR");
            }
            hwdata.ac_pwr = I_AC_Power.ToString(precision) + " W";
            hwdata.dc_pwr = I_DC_Power.ToString(precision) + " W";
            hwdata.temp = mb.I_Temp_Sink.ToString(precision) + "°C";
            hwdata.ImpExMeter = MTR_I_M_AC_Power.ToString(precision) + " W";
            
            hwdata.MB_Pwr3 = string.Format("{0:####0}",MTR_I_M_AC_Power_A) + " W" + " | " + string.Format("{0:####0}",MTR_I_M_AC_Power_B) + " W"     + " | " + string.Format("{0:####0}", MTR_I_M_AC_Power_C) + " W";
         // hwdata.MB_Pwr3 ="-12345 W|-12345 W "+timer2.Interval.ToString();
           // Thread.Sleep(3000);

            pwr_house = I_AC_Power - MTR_I_M_AC_Power;
            pwr_PV = I_DC_Power + Instantaneous_Power;
            if (I_DC_Power < I_AC_Power) { pwr_house = pwr_house - (I_AC_Power - I_DC_Power); } //inverter drawing power from grid
            hwdata.pwr_house = pwr_house.ToString(precision) + " W";
            hwdata.tot_prod = "Tot. Prod:\t" + (mb.I_AC_Energy_WH / 1000000).ToString("####.000") + " MWh";
            hwdata.tot_prod_overall = " Alltime:\t" + (mb.I_AC_Energy_WH / 1000000 + pm.total_add).ToString("####.000") + " MWh";
            hwdata.pwr_PV = pwr_PV.ToString(precision);
            hwdata.total = "TotEx: " + mb.Lifetime_Export_Energy_Counter.ToString() + " Wh\r\nTotIm: " + mb.Lifetime_Import_Energy_Counter.ToString() + " Wh";
            

            

            ///
            /// START DISPLAY
            ///

            if (have_battery)
            {
                lb_m_batt_pwr.Text = hwdata.batt_pwr;
                lb_m_batt_pwr_main.Text = hwdata.batt_pwr_main;


                lb_SOE_TXT.Text = hwdata.bat_SOE;
                if (detail_level > 0)
                {
                    if (mb.Bat_Status != null) { lb_bat_stat.Text = hwdata.Bat_Status; }
                }


            }

            if (show_details && detail_level > 1)
            {


                lb_T_Av.Text = hwdata.T_AV;
                lb_SOH.Text = hwdata.SOH;


            }
            else
            {
                lb_SOH.Text = "";

            }
            bat_SOE.Value = hwdata.SOE;
            //if (hwdata.Bat_Status.Contains("Standby"))
            //{
            //    bat_SOE.ForeColor = Color.Red;
            //    bat_SOE.BackColor = Color.Red;
            //}
            //else
            //{
            //    bat_SOE.ForeColor = Color.Green;
            //    bat_SOE.BackColor= Color.Green;
            //}


            lb_m_ImpExMeter.Text = hwdata.ImpExMeter;


            lb_status.Text = hwdata.status;
            lb_temp.Text = hwdata.temp;
            lb_temp.Focus();

            if (show_details && detail_level > 1)
            {
                lb_ac_pwr.Text = hwdata.ac_pwr;
                lb_dc_pwr.Text = hwdata.dc_pwr;
                MB_Pwr_3.Text = hwdata.MB_Pwr3;


            }
            else { MB_Pwr_3.Text = ""; }

            //  lb_T_max.Text = mb.Batt_Max_Temperature.ToString();
            pwr_house = I_AC_Power - MTR_I_M_AC_Power;
            pwr_PV = I_DC_Power + Instantaneous_Power;
            if (I_DC_Power < I_AC_Power) { pwr_house = pwr_house - (I_AC_Power - I_DC_Power); } //inverter drawing power from grid
            lb_m_pwr_house.Text = pwr_house.ToString(precision) + " W";


            //AC_CURRENT_3.Text = mb.I_AC_CurrentA.ToString() + " // " + mb.I_AC_CurrentB.ToString() + " // " + mb.I_AC_CurrentC.ToString();
            //AC_VOLTAGE_3.Text = (mb.I_AC_CurrentA*240).ToString() + " // " + (mb.I_AC_CurrentB * 240).ToString() + " // " + (mb.I_AC_CurrentC * 240).ToString();





            if (pwr_PV < 0) pwr_PV = 0;
            lb_m_pwr_PV.Text = pwr_PV.ToString(precision) + " W";
            if (pwr_PV > 0 && PV_on.Visible == false) { PV_off.Hide(); PV_on.Show(); pic_PV_from.Show(); pic_pv_no.Hide(); }
            if (pwr_PV <= 0 && PV_off.Visible == false) { PV_off.Show(); PV_on.Hide(); pic_PV_from.Hide(); pic_pv_no.Show(); }


            if (MTR_I_M_AC_Power < -pm.gridflow_threshold) { pic_grid_no.Hide(); pic_grid_to.Hide(); pic_grid_from.Show(); pic_house_to.Image = Properties.Resources.arrow3; }
            else
            if (MTR_I_M_AC_Power > pm.gridflow_threshold) { pic_grid_no.Hide(); pic_grid_to.Show(); pic_grid_from.Hide(); pic_house_to.Image = Properties.Resources.arrow3_GREEN; }
            else
            {
                pic_grid_to.Hide(); pic_grid_from.Hide(); pic_grid_no.Show();

                pic_house_to.Image = Properties.Resources.arrow3_GREEN;
            }
            if (pwr_house == 0) { pic_house_to.Hide(); pic_house_no.Show(); } else { pic_house_to.Show(); pic_house_no.Hide(); }
            if (have_battery)
            {
                if (Instantaneous_Power < 0) { pic_bat_to.Hide(); pic_bat_from.Show(); pic_bat_no.Hide(); }
                else
                if (Instantaneous_Power > 0) { pic_bat_to.Show(); pic_bat_from.Hide(); pic_bat_no.Hide(); }
                else
                { pic_bat_to.Hide(); pic_bat_from.Hide(); pic_bat_no.Show(); }

                if (show_details && detail_level > 1)
                {
                    lb_total.Text = hwdata.total;
                }
                else { lb_total.Text = ""; }
            }
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Continues_Power);
            //tb_chargepower.AppendText("\r\n" + mb.Max_Discharge_Peak_Power);


            if (show_details && detail_level > 1 && pm.total_add != 0)
            {

                lb_tot_prod.Text = hwdata.tot_prod + Environment.NewLine + hwdata.tot_prod_overall;

            }
            else if (show_details && detail_level > 0)
            {
                lb_tot_prod.Text = hwdata.tot_prod;
            }
            else
            { lb_tot_prod.Text = ""; }

           // throw new Exception("TESTFEHLER");


            dailyTasks();
            // sundata.checklocation();
        }

        private void dailyTasks(bool force = false)
        {
            if (force || (DateTime.Now.Date > lastdailyupdate.Date))
            {
                if (DateTime.Now.Month == 12 && DateTime.Now.Day > 20) { pb_xmas.Image = EdgeMon.Properties.Resources.CMT; pb_xmas.Visible = true; }
                else { pb_xmas.Image = null; pb_xmas.Visible = false; }


                lastdailyupdate = DateTime.Now;



                if (show_details && detail_level > 0 && sundata != null && sundata.isvalid)
                {
                    lb_sunrise.Text = sundata.getSunrise();
                    lb_sunset.Text = sundata.getSunset();
                    lb_sunrise.Visible = true;
                    lb_sunset.Visible = true;
                    pic_sunsetrise.Visible = true;
                }
                else
                {
                    lb_sunrise.Visible = false;
                    lb_sunset.Visible = false;
                    pic_sunsetrise.Visible = false;
                }
            }
        }


        private void vanillaview(bool vanilla_on)
        {
            if (vanilla_on)
            {

                // PV_off.Top -= 30;
                // PV_on.Top -= 30;
                fullPVpanel.Top -= 30;
                grid.Top -= 30;
                house.Top += 30;
                battery.Top += 30;
                lb_SOE_TXT.Top += 30;
                bat_SOE.Top += 30;
                lb_m_batt_pwr_main.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb_m_ImpExMeter.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb_m_pwr_house.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb_m_pwr_PV.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb_m_batt_pwr_main.Location = new Point(battery.Left - (lb_m_batt_pwr_main.Width - battery.Width) / 2, battery.Top - 32);
                lb_m_batt_pwr_main.TextAlign = ContentAlignment.MiddleCenter;
                lb_m_ImpExMeter.TextAlign = ContentAlignment.MiddleCenter;
                lb_m_ImpExMeter.Location = new Point(grid.Left - (lb_m_ImpExMeter.Width - grid.Width) / 2, grid.Bottom + 5);
                lb_m_pwr_house.TextAlign = ContentAlignment.MiddleCenter;
                lb_m_pwr_house.Location = new Point(house.Left - (lb_m_pwr_house.Width - house.Width) / 2, lb_m_batt_pwr_main.Top);
                lb_m_pwr_PV.TextAlign = ContentAlignment.MiddleCenter;
                lb_m_pwr_PV.Location = new Point(PV_off.Left + fullPVpanel.Left - (lb_m_pwr_PV.Width - PV_off.Width) / 2, lb_m_ImpExMeter.Top);
                pb_xmas.Location = new Point(pb_xmas.Left, house.Bottom - pb_xmas.Height);
                lb_bat_stat.Location = new Point(lb_bat_stat.Left, battery.Top + (battery.Height - lb_bat_stat.Height) / 2);


            }
            else
            {
                lb_m_batt_pwr_main.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb_m_ImpExMeter.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb_m_pwr_house.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb_m_pwr_PV.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                //PV_off.Location = def_PV_off;
                //PV_on.Location = def_PV_on;
                fullPVpanel.Location = def_fullPVpanel;
                grid.Location = def_grid;
                house.Location = def_house;
                battery.Location = def_battery;
                lb_SOE_TXT.Location = def_lb_SOE_TXT;
                bat_SOE.Location = def_bat_SOE;
                lb_m_pwr_PV.TextAlign = ContentAlignment.MiddleRight;
                lb_m_batt_pwr_main.TextAlign = ContentAlignment.MiddleRight;
                lb_m_ImpExMeter.TextAlign = ContentAlignment.MiddleLeft;
                lb_m_pwr_house.TextAlign = ContentAlignment.MiddleLeft;


                lb_m_batt_pwr_main.Location = def_lb_m_batt_pwr_main;
                lb_m_batt_pwr_main.TextAlign = ContentAlignment.MiddleRight;
                lb_m_ImpExMeter.Location = def_lb_m_ImpExMeter;
                lb_m_pwr_house.Location = def_lb_m_pwr_house;
                lb_m_pwr_PV.Location = def_lb_m_pwr_PV;
                lb_m_pwr_PV.TextAlign = ContentAlignment.MiddleRight;
                pb_xmas.Location = new Point(pb_xmas.Left, house.Bottom - pb_xmas.Height);
                lb_bat_stat.Location = new Point(lb_bat_stat.Left, battery.Top + (battery.Height - lb_bat_stat.Height) / 2);
            }

            lb_m_batt_pwr.SendToBack();

        }






        private void optionalScreenshot(bool err = false)
        {
            if (String.IsNullOrEmpty(pm.saveBitmap)) { return; }
            if ((connected || err) && MultiShotIntervall != 0)
            {
                MultiShotIntervall--;
                if (MultiShotIntervall == 0)
                {
                    MultiShotIntervall = pm.MultiShotIntervall;
                    SaveBitmapAndData(this.mainpanel, pm.saveBitmap);
                }
            }
        }







        private void SaveBitmapAndData(Panel form, string fileName)
        {
            try
            {
                //Save Data
                string[] outdata = new string[6];

                outdata[0] = "Total_Production[MWh]" + ";" + hwdata.tot_prod_overall.Split(new char[] { '\t', ' ' })[2].Trim().Replace(',', '.'); 
                outdata[1] = "PV_Power[W]" + ";" + hwdata.pwr_PV.Split(' ')[0].Replace(',', '.'); ;
                outdata[2] = "Grid_Power[W]" + ";" + hwdata.ImpExMeter.Split(' ')[0].Replace(',', '.'); ;
                outdata[3] = "House_Power[W]" + ";" + hwdata.pwr_house.Split(' ')[0].Replace(',', '.'); ;
                outdata[4] = "Battery_Power[W]" + ";" + hwdata.batt_pwr_main.Split(' ')[0].Replace(',', '.'); ;
                outdata[5] = "Battery_SOE[%]" + ";" + hwdata.bat_SOE.Split(' ')[0].Replace(',','.');
                

                File.WriteAllLines(pm.saveData, outdata);
                //
            }
            catch { }


            try
            {
               


              

                Graphics g = form.CreateGraphics();
                Bitmap bmp = new Bitmap(form.Width, form.Height);
                //reverse order of overlaying controls - this is due to a bug in DrwaToBitmap
                lb_temp.SendToBack();
                lb_ac_pwr.SendToBack();
                pic_bat_from.SendToBack();
                pic_bat_to.SendToBack();
                lb_status.SendToBack();
                lb_version_copyright.Show();
                pic_Logo_Website.Hide();
                lb_OptionMenu.Hide();
                lb_SOE_TXT.SendToBack();
                battery.SendToBack();
                bat_SOE.SendToBack();
                PV_on.SendToBack();
                PV_off.SendToBack();

                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));

                lb_OptionMenu.Show();
                lb_version_copyright.Hide();
                //restore order
                battery.SendToBack();
                Inverter_PIC.SendToBack();
                pic_grid_to.SendToBack();
                pic_grid_from.SendToBack();
                lb_m_batt_pwr.SendToBack();
                pic_Logo_Website.Show();
                lb_sunrise.SendToBack();
                lb_sunset.SendToBack();
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


        ////  private void label4_Click(object sender, EventArgs e)
        // // {

        //      infobox.conf = this.pm;
        //      infobox.ShowDialog();
        //      this.pm = infobox.conf;
        //      if (infobox.DialogResult == DialogResult.Abort) { restartMe(); }


        //  }

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
            Toggle_Border();
        }


        private void Toggle_Border()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.None;
        }

        private void effect_details()
        {

            //          show_details = !show_details;
            //          this.statusgraph_static();
        }


        private void darkmode_on(bool force = false)
        {
            if (!Splashpanel.Visible || force)
            {

                bool was_off = false;
                if (this.mainpanel.BackColor == Color.White) { was_off = true; }
                foreach (Control ctrl in this.mainpanel.Controls)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "FIXEDCOLOR") break;
                    if (ctrl is Label)
                    {
                        ((Label)ctrl).BackColor = dark;
                        ((Label)ctrl).ForeColor = Color.White;
                    }
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).BackColor = dark;
                        ((TextBox)ctrl).ForeColor = Color.White;
                    }
                }

                this.mainpanel.BackColor = dark;
                //Dirty bug workaround, I have no Idea why I need this... 
                lb_m_ImpExMeter.BackColor = dark;
                lb_m_ImpExMeter.ForeColor = Color.White;
                MB_Pwr_3.BackColor = dark;
                MB_Pwr_3.ForeColor = Color.White;
                tb_Inv.BackColor = dark;
                tb_Inv.ForeColor = Color.White;
                lb_m_batt_pwr.ForeColor = Color.White;

                lb_update.ForeColor = Color.White;
                if (was_off)
                {
                    grid.Image = Transform(grid.Image);
                    PV_off.Image = Transform(PV_off.Image);
                    battery.Image = Transform(battery.Image);
                    lb_OptionMenu.Image = Transform(lb_OptionMenu.Image);
                    //  lb_upd.Image = Transform(lb_upd.Image);
                }
                this.BackColor = dark;
                lb_sunrise.BackColor = dark;
                lb_sunrise.ForeColor = Color.White;
                lb_sunset.BackColor = dark;
                lb_sunset.ForeColor = Color.White;
            }
        }
        private void darkmode_off()
        {

            bool was_off = false;
            if (this.mainpanel.BackColor == Color.White) { was_off = true; }

            foreach (Control ctrl in this.mainpanel.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "FIXEDCOLOR") break;
                if (ctrl is Label)
                {
                    ((Label)ctrl).ForeColor = dark;
                    ((Label)ctrl).BackColor = Color.White;

                }
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).ForeColor = dark;
                    ((TextBox)ctrl).BackColor = Color.White;
                }
            }
            this.mainpanel.BackColor = Color.White;
            lb_m_ImpExMeter.BackColor = Color.White;
            lb_m_ImpExMeter.ForeColor = dark;
            MB_Pwr_3.BackColor = Color.White;
            MB_Pwr_3.ForeColor = dark;
            tb_Inv.BackColor = Color.White;
            tb_Inv.ForeColor = dark;
            lb_m_batt_pwr.ForeColor = dark;

            lb_update.ForeColor = dark;
            if (!was_off)
            {
                grid.Image = Transform(grid.Image);
                PV_off.Image = Transform(PV_off.Image);
                battery.Image = Transform(battery.Image);
                lb_OptionMenu.Image = Transform(lb_OptionMenu.Image);
                // lb_upd.Image = Transform(lb_upd.Image);
            }
            this.BackColor = Color.White;
            lb_sunrise.BackColor = Color.White;
            lb_sunrise.ForeColor = dark;
            lb_sunset.BackColor = Color.White;
            lb_sunset.ForeColor = dark;
        }


        private void effect_darkmode_switch()
        {

            //Darkmode
            if (this.mainpanel.BackColor == Color.White)
            {
                darkmode_on();
            }
            else
            {
                darkmode_off();
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







        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DoConfig()
        {
            //  timer2.Enabled = false;
            timer2.Stop();
            infobox.conf = this.pm;
            infobox.ShowDialog();
            this.pm = infobox.conf;
            if (infobox.DialogResult == DialogResult.Abort) { restartMe(); }

            //timer2.Enabled = true;
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
                if (e.ClickedItem.Text == "Darkmode")
                {
                    effect_darkmode_switch();
                    ((ToolStripMenuItem)(e.ClickedItem)).Checked = !((ToolStripMenuItem)(e.ClickedItem)).Checked;

                }
                if (e.ClickedItem.Text == "Screenshot")
                {
                    try { SaveBitmapAndData(this.mainpanel, pm.saveBitmap); }
                    catch { }
                    MessageBox.Show("Screenshot saved in " + pm.saveBitmap);
                }


            }
            timer2.Start();
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



        private void lb_upd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("COMSPEC"), "/C " + "start " + "https://edgemon.helioho.st/EdgemonSetup.msi");



        }




        private void Update_check_timer_Tick(object sender, EventArgs e)
        {
            checkForUpdate();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_Logo_Website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("COMSPEC"), "/C " + "start " + "https://edgemon.helioho.st");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pb_xmas_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Month == 12)
            {
                MessageBox.Show("Happy Holidays to all EdgeMon users !\nWishing you a sunny " + (DateTime.Now.Year + 1));
            }
        }



        private void lb_OptionMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    var relativeClickedPosition = e.Location;
            //    var screenClickedPosition = (sender as Control).PointToScreen(relativeClickedPosition);
            //    BurgerMenuStrip.Show(screenClickedPosition);

            //    //BurgerMenuStrip.Visible = false;

            //}
        }

        private void lb_OptionMenu_Click(object sender, EventArgs e)
        {
            // if (e.Button == MouseButtons.Left)
            {
                //   var relativeClickedPosition = e.Location;
                //   var screenClickedPosition = (sender as Control).PointToScreen(relativeClickedPosition);
                BurgerMenuStrip.Show(lb_OptionMenu, 0, lb_OptionMenu.Height);

                //BurgerMenuStrip.Visible = false;

            }
        }

        private void BurgerMenuStrip_Click(object sender, EventArgs e)
        {

        }

        private void BurgerMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {

        }

        private void BurgerMenuStrip_Opened(object sender, EventArgs e)
        {
            timer2.Stop();
        }


        public void maketransparent(Label lb, PictureBox pb)
        {
            var pos = lb.Parent.PointToScreen(lb.Location);
            pos = pb.PointToClient(pos);
            lb.Parent = pb;
            lb.Location = pos;
            lb.BackColor = Color.Transparent;
        }
        private void ComboDetailLevel_DropDownClosed(object sender, EventArgs e)
        {
            BurgerMenuStrip.Close();
        }

        private void ComboDetailLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialized) return;
            int res;
            if (ComboDetailLevel.ComboBox.SelectedItem != null)
            {

                if (int.TryParse(ComboDetailLevel.ComboBox.SelectedItem.ToString(), out res))
                {
                    detail_level = res;
                    try
                    {
                        this.statusgraph_static();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
        }

        private void MainEdge_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) != 0)
            {
                suppress_oneshot = true;
            }
        }



        private void reset_all_detaillevel()
        {
            foreach (ToolStripMenuItem item in ls_detailLevel.DropDownItems)
            {
                if (item.Text.Contains(detail_level.ToString()))
                { item.Checked = true; }
                else
                    item.Checked = false;
            }

        }

        private void ts_lvl0_Click(object sender, EventArgs e)
        {
            timer2.Start();
            detail_level = 0;
            reset_all_detaillevel();


            this.statusgraph_static();
            timer2.Start();
        }

        private void ts_lvl1_Click(object sender, EventArgs e)
        {
            timer2.Start();
            detail_level = 1;
            reset_all_detaillevel();

            this.statusgraph_static();

        }

        private void ts_lvl2_Click(object sender, EventArgs e)
        {
            timer2.Start();
            detail_level = 2;
            reset_all_detaillevel();

            this.statusgraph_static();
        }

        private void ts_lvl3_Click(object sender, EventArgs e)
        {
            timer2.Start();
            detail_level = 3;
            reset_all_detaillevel();

            this.statusgraph_static();
        }

        private void tb_Inv_Enter(object sender, EventArgs e)
        {

            Toggle_Border();
           (sender as TextBox).Enabled = false;
           (sender as TextBox).Enabled = true;

        }

        private void MainEdge_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer2.Stop();
            try
            {
                mb.Disconnect();
            }
            catch (Exception)
            {

            }
        }
    }
    }
    





class MyWebClient : System.Net.WebClient
{
    protected override WebRequest GetWebRequest(Uri uri)
    {
        WebRequest w = base.GetWebRequest(uri);
        //w.Timeout = 5 * 1000;
        return w;
    }
}