using System;



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
        public string saveData { get; set; }
        public bool OneShot { get; set; }
        public int MultiShotIntervall { get; set; }
        public bool battery_autodetect { get; set; }
        public int gridflow_threshold { get; set; }
        public bool showDetails { get; set; }
        public bool Darkmode { get; set; }
        public bool checkUpdates { get; set; }

        public int DetailLevel { get; set; }

        public double loc_longitude { get; set; }
        public double loc_latitude { get; set; }
        //  public bool SubiconLayout { get; set; }
        public double total_add { get; set; }

        public bool debug { get; set; }

        public EdgemonConfig(string ver) : base("EdgeMon", ver)
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
            this.saveBitmap = Properties.Settings.Default.saveData;
            this.OneShot = Properties.Settings.Default.OneShot;
            this.MultiShotIntervall = Properties.Settings.Default.MultiShotIntervall;
            this.battery_autodetect = Properties.Settings.Default.battery_autodetect;
            this.gridflow_threshold = Properties.Settings.Default.gridflow_threshold;
            //   this.showDetails = Properties.Settings.Default.showDetails;
            this.DetailLevel = Properties.Settings.Default.detailLevel;
            this.Darkmode = Properties.Settings.Default.Darkmode;
            this.checkUpdates = Properties.Settings.Default.checkUpdates;
            this.loc_latitude = Properties.Settings.Default.loc_latitude;
            this.loc_longitude = Properties.Settings.Default.loc_longitude;
            this.total_add = Properties.Settings.Default.total_add;
            this.debug = Properties.Settings.Default.debug;
            //   this.SubiconLayout = Properties.Settings.Default.k;

        }

        public void SetAllConfigData()
        {
            Set("TCP", this.TCP);
            Set("port", this.port);
            Set("battery", this.battery);
            Set("refresh", this.refresh);
            Set("saveBitmap", this.saveBitmap);
            Set("saveData", this.saveData);
            Set("OneShot", this.OneShot);
            Set("MultiShotIntervall", this.MultiShotIntervall);
            Set("battery_autodetect", this.battery_autodetect);
            Set("gridflow_threshold", this.gridflow_threshold);
            Set("showDetails", this.showDetails);
            Set("DetailLevel", this.DetailLevel);
            Set("Darkmode", this.Darkmode);
            Set("checkUpdates", this.checkUpdates);
            Set("loc_latitude", this.loc_latitude);
            Set("loc_longitude", this.loc_longitude);
            Set("total_add", this.total_add);
            Set("debug", this.debug);
            // Set("loc_latitude", this.loc_latitude.ToString(CultureInfo.InvariantCulture));
            // Set("loc_longitude", this.loc_longitude.ToString(CultureInfo.InvariantCulture));

            //   Set("SubiconLayout", this.SubiconLayout);

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
                this.showDetails = Get("showDetails", this.showDetails);
                this.Darkmode = Get("Darkmode", this.Darkmode);
                this.checkUpdates = Get("checkUpdates", this.checkUpdates);
                this.DetailLevel = Get("DetailLevel", this.DetailLevel);
                this.total_add = Get("total_add", this.total_add);
                this.debug = Get("debug", this.debug);
                this.saveData = Get("saveData", this.saveData);
                try
                {
                    this.loc_latitude = Get("loc_latitude", this.loc_latitude);
                    this.loc_longitude = Get("loc_longitude", this.loc_longitude);

                    // this.loc_latitude = double.Parse(Get("loc_latitude", this.loc_latitude.ToString(CultureInfo.InvariantCulture)),CultureInfo.InvariantCulture);
                    // this.loc_longitude = double.Parse(Get("loc_longitude", this.loc_longitude.ToString(CultureInfo.InvariantCulture)),CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    this.loc_latitude = double.NaN;
                    this.loc_longitude = double.NaN;
                }

                //    this.SubiconLayout = Get("SubiconLayout", this.SubiconLayout);
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
