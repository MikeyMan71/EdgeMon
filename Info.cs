using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace EdgeMon
{
    partial class Info : Form
    {
        bool changed = false;

        public EdgemonConfig conf { get; set; }


        public Info()
        {
            InitializeComponent();
            this.Text = String.Format("Info about {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright + " (credits to MAM)";
            //  this.labelCompanyName.Text = AssemblyCompany;
            this.linkLabel.Text = AssemblyDescription;
            this.textBoxDescription.Text = "EasyModbus Client Library Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.textBoxDescription.Text += "\nCopyright (c) Stefan Rossmann Engineering Solutions";
            this.textBoxDescription.Text += "\nIcons by www.reshot.com";

        }

        #region Assemblyattributaccessoren




        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public Version AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        //private void okButton_Click(object sender, EventArgs e)
        //{
        //    if (changed)
        //    {
        //        conf.SetAllConfigData();
        //        conf.WriteINI();
        //        Application.Restart();
        //    }
        //    this.Hide();

        //    this.Close();
        //}





        private void Info_Shown(object sender, EventArgs e)
        {

            FillGrid();

        }



        /// <summary>
        /// GRID SETTINGS
        /// </summary>
        public void FillGrid()
        {
            DataGridViewCheckBoxCell cbc_Battery = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_OneShot = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_battery_autodetect = new DataGridViewCheckBoxCell();
            //  DataGridViewCheckBoxCell cbc_showDetails = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_Darkmode = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_checkUpdates = new DataGridViewCheckBoxCell();
            DataGridViewComboBoxCell combobc_DetailLevel = new DataGridViewComboBoxCell();
            // DataGridViewCheckBoxCell cbc_SubiconLayout = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_debug = new DataGridViewCheckBoxCell();

            combobc_DetailLevel.Items.Add(0);
            combobc_DetailLevel.Items.Add(1);
            combobc_DetailLevel.Items.Add(2);
            combobc_DetailLevel.Items.Add(3);
            combobc_DetailLevel.ValueType = typeof(int);
            DataGridViewButtonCell bt_dataGridViewButtonCellBitmap = new DataGridViewButtonCell();
            DataGridViewButtonCell bt_dataGridViewButtonCellData = new DataGridViewButtonCell();

            cbc_Battery.Value = conf.battery;
            cbc_OneShot.Value = conf.OneShot;
            cbc_battery_autodetect.Value = conf.battery_autodetect;
            // cbc_showDetails.Value = conf.showDetails;
            cbc_Darkmode.Value = conf.Darkmode;
            cbc_checkUpdates.Value = conf.checkUpdates;
            combobc_DetailLevel.Value = conf.DetailLevel;
            //  cbc_SubiconLayout.Value = conf.SubiconLayout;
            cbc_debug.Value = conf.debug;


            bt_dataGridViewButtonCellBitmap.Value = conf.saveBitmap;
            bt_dataGridViewButtonCellData.Value = conf.saveData;

            ConfigGrid.Columns.Clear();
            ConfigGrid.Rows.Clear();
            ConfigGrid.Columns.Add("Setting", "Setting");
            ConfigGrid.Columns.Add("Value", "Value");

            ConfigGrid.Rows.Add("IP", conf.TCP);//0

            ConfigGrid.Rows.Add("Port (0=auto)", conf.port);//1


            ConfigGrid.Rows.Add("Battery");
            ConfigGrid.Rows[2].Cells[1] = cbc_Battery;

            ConfigGrid.Rows.Add("Refresh", conf.refresh);

            ConfigGrid.Rows.Add("saveData", conf.saveData);
            ConfigGrid.Rows[4].Cells[1] = bt_dataGridViewButtonCellData;

            ConfigGrid.Rows.Add("saveBitmap", conf.saveBitmap);
            ConfigGrid.Rows[5].Cells[1] = bt_dataGridViewButtonCellBitmap;

            ConfigGrid.Rows.Add("OneShot", conf.OneShot);
            ConfigGrid.Rows[6].Cells[1] = cbc_OneShot;

            ConfigGrid.Rows.Add("MultiShotIntervall", conf.MultiShotIntervall);

            ConfigGrid.Rows.Add("battery_autodetect");
            ConfigGrid.Rows[8].Cells[1] = cbc_battery_autodetect;

            ConfigGrid.Rows.Add("gridflow_threshold", conf.gridflow_threshold);

            // ConfigGrid.Rows.Add("showDetails");


            ConfigGrid.Rows.Add("DetailLevel", conf.DetailLevel);
            ConfigGrid.Rows[10].Cells[1] = combobc_DetailLevel;

            ConfigGrid.Rows.Add("Darkmode");
            ConfigGrid.Rows[11].Cells[1] = cbc_Darkmode;

            ConfigGrid.Rows.Add("checkUpdates");
            ConfigGrid.Rows[12].Cells[1] = cbc_checkUpdates;

            ConfigGrid.Rows.Add("loc_latitude", conf.loc_latitude.ToString(CultureInfo.InvariantCulture));
            ConfigGrid.Rows.Add("loc_longitude", conf.loc_longitude.ToString(CultureInfo.InvariantCulture));
            ConfigGrid.Rows.Add("total_add (MWh)", conf.total_add.ToString(CultureInfo.InvariantCulture));
            ConfigGrid.Rows.Add("debug");
            ConfigGrid.Rows[16].Cells[1] = cbc_debug;
            ConfigGrid.Rows[16].Visible = false;
            //  ConfigGrid.Rows.Add("SubiconLayout");
            //  ConfigGrid.Rows[13].Cells[1] = cbc_SubiconLayout;
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            int res;
            bool res_bool;
            bool error = false;
            double doubleres;

            if (changed)
            {

                foreach (DataGridViewRow row in ConfigGrid.Rows) { row.Cells[1].ErrorText = ""; }


                conf.TCP = ConfigGrid.Rows[0].Cells[1].Value.ToString();
                if (conf.TCP.Contains("http"))
                {
                    conf.TCP = conf.TCP.Replace("http:", "");
                    conf.TCP = conf.TCP.Replace("\\", "");
                    conf.TCP = conf.TCP.Replace("/", "");
                }

                if (int.TryParse(ConfigGrid.Rows[1].Cells[1].Value.ToString(), out res))
                { conf.port = res; }
                else { ConfigGrid.Rows[1].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[2].Cells[1].Value.ToString(), out res_bool))
                { conf.battery = res_bool; }
                else { ConfigGrid.Rows[2].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[3].Cells[1].Value.ToString(), out res))
                { conf.refresh = res; }
                else { ConfigGrid.Rows[3].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                conf.saveData = ConfigGrid.Rows[4].Cells[1].Value.ToString();

                conf.saveBitmap = ConfigGrid.Rows[5].Cells[1].Value.ToString();
                //if (Directory.Exists(Path.GetDirectoryName(conf.saveBitmap))== false)
                //{
                //    conf.saveBitmap = "";
                //}

                


                if (bool.TryParse(ConfigGrid.Rows[6].Cells[1].Value.ToString(), out res_bool))
                { conf.OneShot = res_bool; }
                else { ConfigGrid.Rows[5].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                
                
                if (int.TryParse(ConfigGrid.Rows[7].Cells[1].Value.ToString(), out res))
                { conf.MultiShotIntervall = res; }
                else { ConfigGrid.Rows[7].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[8].Cells[1].Value.ToString(), out res_bool))
                { conf.battery_autodetect = res_bool; }
                else { ConfigGrid.Rows[8].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[9].Cells[1].Value.ToString(), out res))
                { conf.gridflow_threshold = res; }
                else { ConfigGrid.Rows[9].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }


                //  if (bool.TryParse(ConfigGrid.Rows[9].Cells[1].Value.ToString(), out res_bool))
                //  { conf.showDetails = res_bool; }
                //  else { ConfigGrid.Rows[9].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[10].Cells[1].Value.ToString(), out res))
                { conf.DetailLevel = res; }
                else { ConfigGrid.Rows[10].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[11].Cells[1].Value.ToString(), out res_bool))
                { conf.Darkmode = res_bool; }
                else { ConfigGrid.Rows[11].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[12].Cells[1].Value.ToString(), out res_bool))
                { conf.checkUpdates = res_bool; }
                else { ConfigGrid.Rows[12].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (ConfigGrid.Rows[13].Cells[1].Value == null) { ConfigGrid.Rows[12].Cells[1].Value = double.NaN; }


                if (double.TryParse(ConfigGrid.Rows[13].Cells[1].Value.ToString().Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out doubleres))
                { conf.loc_latitude = doubleres; }
                else { ConfigGrid.Rows[13].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (ConfigGrid.Rows[14].Cells[1].Value == null) { ConfigGrid.Rows[13].Cells[1].Value = double.NaN; }

                if (double.TryParse(ConfigGrid.Rows[14].Cells[1].Value.ToString().Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out doubleres))
                { conf.loc_longitude = doubleres; }
                else { ConfigGrid.Rows[14].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (double.TryParse(ConfigGrid.Rows[15].Cells[1].Value.ToString().Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out doubleres))
                { conf.total_add = doubleres; }
                else { ConfigGrid.Rows[15].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }


                if (bool.TryParse(ConfigGrid.Rows[16].Cells[1].Value.ToString(), out res_bool))
                { conf.debug = res_bool; }
                else { ConfigGrid.Rows[16].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                //     if (bool.TryParse(ConfigGrid.Rows[13].Cells[1].Value.ToString(), out res_bool))
                //    { conf.SubiconLayout = res_bool; }
                //     else { ConfigGrid.Rows[13].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                //if (!error) changed = true;

                //  this.DialogResult = DialogResult.OK;
                // this.Close();

                if (!error)
                {
                    conf.SetAllConfigData();
                    conf.WriteINI();
                    this.DialogResult = DialogResult.Abort;
                    //Application.Restart();
                }

            }
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.changed = false;
            bt_accept.Text = "CLOSE";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reset all settings to application default?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else if (dr == DialogResult.OK)
            {
                // conf.Remove();
                // conf.GetAllConfigData();
                conf.Remove();
                conf.GetConfigFromXML();
                FillGrid();
                changed = true;
            }



        }

        private void ConfigGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void ConfigGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bt_accept.Text = "ACCEPT+CLOSE";
            changed = true;
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }

        private void Info_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) { this.TopMost = true; } else { this.TopMost = false; }
        }

        private void ConfigGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {


            bt_accept.Text = "ACCEPT+CLOSE";
            changed = true;

        }

        private void ConfigGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error in Row" + e.RowIndex);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("COMSPEC"), "/C " + "start " + "https://edgemon.helioho.st");

        }

        private void bt_cl_Click(object sender, EventArgs e)
        {
            TextFileViewer textFileViewer = new TextFileViewer("changelog.txt");
            textFileViewer.Show();
            textFileViewer.TopMost = true;

        }

        private void bt_lic_Click(object sender, EventArgs e)
        {
            TextFileViewer textFileViewer = new TextFileViewer("licenses.txt");
            textFileViewer.Show();
            textFileViewer.TopMost = true;
        }

        private void ConfigGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.CurrentCell is DataGridViewButtonCell &&
                e.RowIndex == 5)
            {
                if (saveFileDialog_screenshot.ShowDialog() == DialogResult.OK)
                {
                   
                        conf.saveBitmap = saveFileDialog_screenshot.FileName;
                 
                    FillGrid();
                    ConfigGrid_CellValueChanged(this, e);
                }


            }

            if (senderGrid.CurrentCell is DataGridViewButtonCell &&
               e.RowIndex == 4)
            {
                if (saveFileDialog_data.ShowDialog() == DialogResult.OK)
                {
                 
                        conf.saveData = saveFileDialog_data.FileName;
              
                    FillGrid();
                    ConfigGrid_CellValueChanged(this, e);
                }


            }

        }

        private void ConfigGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if ((e.ColumnIndex == this.ConfigGrid.Columns[0].Index)
   && e.Value != null)
            {
                DataGridViewCell cell =
                    this.ConfigGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                switch (cell.RowIndex)
                {
                    case 0:
                        cell.ToolTipText = "Enter IP Address as xxx.xxx.xxx.xxx , or devicename";
                        break;
                    case 1:
                        cell.ToolTipText = "Enter Port number or 0 for autodetection";
                        break;
                    case 2:
                        cell.ToolTipText = "Select if your system has a battery storage";
                        break;
                    case 3:
                        cell.ToolTipText = "Enter refresh rate in Milliseconds";
                        break;
                    case 4:
                        cell.ToolTipText = "Choose directory and filename for data";
                        break;
                    case 5:
                        cell.ToolTipText = "Choose directory and filename for screenshots";

                        break;
                    case 6:
                        cell.ToolTipText = "If activated, Edgemon will do a screenshot once and close immedeately. Hold SHIFT to ignore this setting when starting Edgemon";

                        break;
                    case 7:
                        cell.ToolTipText = "If active, a screenshot will be done every Nth refresh";

                        break;
                    case 8:
                        cell.ToolTipText = "Select for battery autodetect";

                        break;
                    case 9:
                        cell.ToolTipText = "Threshold value for grid power. Values above this will be considered valid";

                        break;
                    case 10:
                        cell.ToolTipText = "Select default detail level";

                        break;
                    case 11:
                        cell.ToolTipText = "Select to activate darkmode as a default mode";

                        break;
                    case 12:
                        cell.ToolTipText = "Select to automatically check for EdgeMon updates";
                        break;
                    case 13:
                        cell.ToolTipText = "Enter location latitude. Enter NaN to auto-detect position (must be activated in windows)";

                        break;
                    case 14:
                        cell.ToolTipText = "Enter location longitude. Enter NaN to auto-detect position (must be activated in windows)";

                        break;
                    case 15:
                        cell.ToolTipText = "Offset in MWh to be added to total produced energy - to be used if your system had an inverter change";
                        break;
                    case 16:
                        cell.ToolTipText = "Write a debug file to %appdata%\\Edgemon";
                        break;

                    default:
                        break;
                }



            }
        }

        private void saveFileDialog_data_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
        }

        private void saveFileDialog_screenshot_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

       
        }
    }
    }
    












