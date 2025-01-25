namespace EdgeMon
{
    internal class HWData
    {
        internal string SOH { get; set; }
        internal int SOE { get; set; }
        internal string bat_SOE { get; set; }
        internal string Bat_Status { get; set; }
        internal string T_AV { get; set; }
        internal string batt_pwr { get; set; }
        internal string batt_pwr_main { get; set; }
        internal string ac_pwr { get; set; }
        internal string dc_pwr { get; set; }
        internal string temp { get; set; }
        internal string ImpExMeter { get; set; }
        internal string MB_Pwr3 { get; set; }
        internal string status { get; set; }
        internal string pwr_house { get; set; }
        internal string pwr_PV { get; set; }
        internal string total { get; set; }
        internal string tot_prod { get; set; }

        internal string tot_prod_overall {get;set;}


        public HWData() { }
    }
}

