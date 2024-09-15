using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeMon
{
    public partial class Config : Form
    {

        EdgemonConfig pm;

        public Config(EdgemonConfig pm)
        {
            InitializeComponent();
            this.pm = pm;
        }

        //public void  FillGrid()
        //{

        //    ConfigGrid.Columns.Add("Setting", "Setting");
        //    ConfigGrid.Columns.Add("Value", "Value");
           
        //    ConfigGrid.Rows.Add("TCP",pm.TCP);
        //    ConfigGrid.Rows.Add("Port",pm.port);
        //    ConfigGrid.Rows.Add("Battery", pm.battery);
        //    ConfigGrid.Rows.Add("Refresh", pm.refresh);
        //    ConfigGrid.Rows.Add("saveBitmap", pm.saveBitmap);
        //    ConfigGrid.Rows.Add("OneShot", pm.OneShot);
        //    ConfigGrid.Rows.Add("MultiShotIntervall", pm.MultiShotIntervall);
        //    ConfigGrid.Rows.Add("battery_autodetect", pm.battery_autodetect);
        //    ConfigGrid.Rows.Add("gridflow_threshold", pm.gridflow_threshold);


        //}

        //private void bt_accept_Click(object sender, EventArgs e)
        //{
        //    int res;
        //    bool res_bool;

        //    pm.TCP = ConfigGrid.Rows[0].Cells[1].Value.ToString();

        //    if (int.TryParse(ConfigGrid.Rows[1].Cells[1].Value.ToString(), out res))
        //    { pm.port = res; }
        //    else { ConfigGrid.Rows[1].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    if (bool.TryParse(ConfigGrid.Rows[2].Cells[1].Value.ToString(), out res_bool))
        //    { pm.battery = res_bool; }
        //    else { ConfigGrid.Rows[2].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    if (int.TryParse(ConfigGrid.Rows[3].Cells[1].Value.ToString(), out res))
        //    { pm.refresh = res; }
        //    else { ConfigGrid.Rows[3].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    pm.saveBitmap = ConfigGrid.Rows[4].Cells[1].Value.ToString();

        //    if (bool.TryParse(ConfigGrid.Rows[5].Cells[1].Value.ToString(), out res_bool))
        //    { pm.OneShot = res_bool; }
        //    else { ConfigGrid.Rows[5].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    if (int.TryParse(ConfigGrid.Rows[6].Cells[1].Value.ToString(), out res))
        //    { pm.MultiShotIntervall = res; }
        //    else { ConfigGrid.Rows[6].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    if (bool.TryParse(ConfigGrid.Rows[7].Cells[1].Value.ToString(), out res_bool))
        //    { pm.battery_autodetect = res_bool; }
        //    else { ConfigGrid.Rows[7].Cells[1].ErrorText = "FORMAT ERROR"; }

        //    if (int.TryParse(ConfigGrid.Rows[8].Cells[1].Value.ToString(), out res))
        //    { pm.gridflow_threshold = res; }
        //    else { ConfigGrid.Rows[8].Cells[1].ErrorText = "FORMAT ERROR"; }




        //    this.DialogResult = DialogResult.OK;
        //    this.Close();   
        //}

        //private void bt_cancel_Click(object sender, EventArgs e)
        //{
           
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close();   
        //}
    }
}
