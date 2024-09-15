using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EdgeMon
{

    public class EdgemonConfig : MAMconfig.Config
    {
        //MAMconfig.Config edgeconfig = new MAMconfig.Config("EdgeMon");

        public string TCP { get; set; }
        public int port { get; set; }
        public bool battery { get; set; }
        public int refresh { get; set; }
        public string saveBitmap { get; set; }
        public bool OneShot { get; set; }
        public int MultiShotIntervall { get; set; }
        public bool battery_autodetect { get; set; }
        public int gridflow_threshold { get; set; }
       public bool showDetails { get; set; }
        public bool Darkmode { get; set; }
        public bool checkUpdates { get; set; }



        public EdgemonConfig(string ver) : base("Edgemon", ver)
        {
            
            GetAllConfigData();
        }



        internal void GetConfigFromXML()
        {
            this.TCP = Properties.Settings.Default.TCP;
            this.port = Properties.Settings.Default.port; ;
            this.battery = Properties.Settings.Default.battery;
            this.refresh = Properties.Settings.Default.refresh;
            this.saveBitmap = Properties.Settings.Default.saveBitmap;
            this.OneShot = Properties.Settings.Default.OneShot;
            this.MultiShotIntervall = Properties.Settings.Default.MultiShotIntervall;
            this.battery_autodetect = Properties.Settings.Default.battery_autodetect;
            this.gridflow_threshold = Properties.Settings.Default.gridflow_threshold;
            this.showDetails = Properties.Settings.Default.showDetails;
            this.Darkmode = Properties.Settings.Default.Darkmode;
            this.checkUpdates = Properties.Settings.Default.checkUpdates;

        }

        public void SetAllConfigData()
        {
            Set("TCP", this.TCP);
            Set("port", this.port);
            Set("battery", this.battery);
            Set("refresh", this.refresh);
            Set("saveBitmap", this.saveBitmap);
            Set("OneShot", this.OneShot);
            Set("MultiShotIntervall", this.MultiShotIntervall);
            Set("battery_autodetect", this.battery_autodetect);
            Set("gridflow_threshold", this.gridflow_threshold);
            Set("showDetails", this.showDetails);
            Set("Darkmode", this.Darkmode);
            Set("checkUpdates", this.checkUpdates);

        }


            /// <summary>
            /// Handle all config data form ini files
            /// </summary>
            public void GetAllConfigData()
            {
            GetConfigFromXML();


           
            {
                this.TCP = Get("TCP", this.TCP);
                this.port = Get("port", this.port);
                this.battery = Get("battery", this.battery);
                this.refresh = Get("refresh", this.refresh);
                this.saveBitmap = Get("saveBitmap", this.saveBitmap);
                this.OneShot = Get("OneShot", this.OneShot);
                this.MultiShotIntervall = Get("MultiShotIntervall", this.MultiShotIntervall);
                this.battery_autodetect = Get("battery_autodetect", this.battery_autodetect);
                this.gridflow_threshold = Get("gridflow_threshold", this.gridflow_threshold);
                this.showDetails = Get("showDetails",this.showDetails);
                this.Darkmode = Get("Darkmode", this.Darkmode);
                this.checkUpdates = Get("checkUpdates", this.checkUpdates);

                WriteINI();
            }
        }

        public void VanillaEditINI()
        {
        
            // wenn Änderungen anstehen, erstmal wegschreiben, damit der Benutzer den aktuellen Stand zu Gesicht
            // bekommt. MAM 03.03.2024
           // if (Geaendert) { WriteINI(); }
            //Config cf = new Config(this);
           
           
            
            //cf.FillGrid();

            //DialogResult dr = cf.ShowDialog();
            //if (dr == DialogResult.OK) { SetAllConfigData(); }

            //cf.Dispose();
        }



    }
}
