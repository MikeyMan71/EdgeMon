using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EdgeMon
{

    internal class EdgemonConfig:MAMconfig.Config
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
        public bool local_config { get; set; } = false;

        public EdgemonConfig() : base("Edgemon")
        {
            local_config = File.Exists("UsePrivateSettings"); 
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
          
        }


            /// <summary>
            /// Handle all config data form ini files
            /// </summary>
            public void GetAllConfigData()
            {
            GetConfigFromXML();


            if (local_config)
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


                WriteINI();
            }
        } 
    }
}
