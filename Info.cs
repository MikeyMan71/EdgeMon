using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeMon
{
    partial class Info : Form
    {
        bool changed = false;

       public EdgemonConfig conf { get; set; }


        public  Info()
        {
            InitializeComponent();
            this.Text = String.Format("Info über {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright + " (credits to MAM)";
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            


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
            DataGridViewCheckBoxCell cbc_showDetails = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_Darkmode = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell cbc_checkUpdates = new DataGridViewCheckBoxCell();

            cbc_Battery.Value = conf.battery;
            cbc_OneShot.Value = conf.OneShot;
            cbc_battery_autodetect.Value = conf.battery_autodetect;
            cbc_showDetails.Value = conf.showDetails;
            cbc_Darkmode.Value = conf.Darkmode;
            cbc_checkUpdates.Value = conf.checkUpdates;



            ConfigGrid.Columns.Clear();
            ConfigGrid.Rows.Clear();
            ConfigGrid.Columns.Add("Setting", "Setting");
            ConfigGrid.Columns.Add("Value", "Value");

            ConfigGrid.Rows.Add("TCP", conf.TCP);

            ConfigGrid.Rows.Add("Port", conf.port);

            ConfigGrid.Rows.Add("Battery");
            ConfigGrid.Rows[2].Cells[1] = cbc_Battery;

            ConfigGrid.Rows.Add("Refresh", conf.refresh);

            ConfigGrid.Rows.Add("saveBitmap", conf.saveBitmap);

            ConfigGrid.Rows.Add("OneShot", conf.OneShot);

            ConfigGrid.Rows.Add("MultiShotIntervall", conf.MultiShotIntervall);

            ConfigGrid.Rows.Add("battery_autodetect");
            ConfigGrid.Rows[7].Cells[1] = cbc_battery_autodetect;

            ConfigGrid.Rows.Add("gridflow_threshold", conf.gridflow_threshold);

            ConfigGrid.Rows.Add("showDetails");
            ConfigGrid.Rows[9].Cells[1] = cbc_showDetails;

            ConfigGrid.Rows.Add("detailLeveel",conf.DetailLevel);

            ConfigGrid.Rows.Add("Darkmode");
            ConfigGrid.Rows[11].Cells[1] = cbc_Darkmode;

            ConfigGrid.Rows.Add("checkUpdates");
            ConfigGrid.Rows[12].Cells[1] = cbc_checkUpdates;

        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            int res;
            bool res_bool;
            bool error = false;

            if (changed)
            {

                foreach (DataGridViewRow row in ConfigGrid.Rows) { row.Cells[1].ErrorText = ""; }


                conf.TCP = ConfigGrid.Rows[0].Cells[1].Value.ToString();

                if (int.TryParse(ConfigGrid.Rows[1].Cells[1].Value.ToString(), out res))
                { conf.port = res; }
                else { ConfigGrid.Rows[1].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[2].Cells[1].Value.ToString(), out res_bool))
                { conf.battery = res_bool; }
                else { ConfigGrid.Rows[2].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[3].Cells[1].Value.ToString(), out res))
                { conf.refresh = res; }
                else { ConfigGrid.Rows[3].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                conf.saveBitmap = ConfigGrid.Rows[4].Cells[1].Value.ToString();

                if (bool.TryParse(ConfigGrid.Rows[5].Cells[1].Value.ToString(), out res_bool))
                { conf.OneShot = res_bool; }
                else { ConfigGrid.Rows[5].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[6].Cells[1].Value.ToString(), out res))
                { conf.MultiShotIntervall = res; }
                else { ConfigGrid.Rows[6].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[7].Cells[1].Value.ToString(), out res_bool))
                { conf.battery_autodetect = res_bool; }
                else { ConfigGrid.Rows[7].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[8].Cells[1].Value.ToString(), out res))
                { conf.gridflow_threshold = res; }
                else { ConfigGrid.Rows[8].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }


                if (bool.TryParse(ConfigGrid.Rows[9].Cells[1].Value.ToString(), out res_bool))
                { conf.showDetails = res_bool; }
                else { ConfigGrid.Rows[ 9].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (int.TryParse(ConfigGrid.Rows[10].Cells[1].Value.ToString(), out res))
                { conf.DetailLevel = res; }
                else { ConfigGrid.Rows[10].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[11].Cells[1].Value.ToString(), out res_bool))
                { conf.Darkmode = res_bool; }
                else { ConfigGrid.Rows[11].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }

                if (bool.TryParse(ConfigGrid.Rows[12].Cells[1].Value.ToString(), out res_bool))
                { conf.checkUpdates = res_bool; }
                else { ConfigGrid.Rows[12].Cells[1].ErrorText = "FORMAT ERROR"; error = true; }


                //if (!error) changed = true;

                //  this.DialogResult = DialogResult.OK;
                // this.Close();

                if (!error)
                {
                    conf.SetAllConfigData();
                    conf.WriteINI();
                  
                   Application.Restart();
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
            if (this.Visible) {this.TopMost = true;}  else {this.TopMost = false;}
        }

        private void ConfigGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
            
                bt_accept.Text = "ACCEPT+CLOSE";
                changed = true;
            
        }
    }










}

