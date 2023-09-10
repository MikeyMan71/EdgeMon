


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
    public partial class NewEdge : Form
    {
        bool have_battery = false;
        TcpModbus mb;
        public NewEdge()
        {
            InitializeComponent();
            timer2.Enabled = false;
            mb = null;
            try
            {
                mb = new TcpModbus(Properties.Settings.Default.TCP, Properties.Settings.Default.port);
            }
            catch (Exception)
            {
                MessageBox.Show("No SE device found on address [" + Properties.Settings.Default.TCP + "] , Port [" + Properties.Settings.Default.port + "]");
                Environment.Exit(0);
            }
            //Battery present?
            try
            {
                if (mb.BatterySerialNr.Length > 0 && Properties.Settings.Default.battery == true)
                    have_battery = true;
            }
            catch (Exception)
            {

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
         
            timer2.Enabled = true;
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
                lb_SOH.Text = mb.SOH.ToString() + " %";
                bat_SOE.Value = (int)mb.SOE;
                lb_SOE_TXT.Text = mb.SOE.ToString() + " %";
                lb_bat_stat.Text = mb.Bat_Status.ToString();
                lb_T_Av.Text = mb.Batt_Average_Temperature.ToString() + "°C";
                lb_batt_pwr.Text = Instantaneous_Power.ToString() + " W \n\r" + mb.Instantaneous_Voltage.ToString("N0") + " V \n\r" + mb.Instantaneous_Current.ToString("N3") + " A ";
            }



            lb_status.Text = mb.I_Status.ToString();
            lb_update.Text = DateTime.Now.ToString();
            lb_ac_pwr.Text = I_AC_Power.ToString() + " W";
            lb_dc_pwr.Text = I_DC_Power.ToString() + " W";
            lb_temp.Text = mb.I_Temp_Sink.ToString() + "°C";
            ImpExMeter.Text = MTR_I_M_AC_Power.ToString() + " W";


            MB_Pwr_3.Text = mb.MTR_I_M_AC_Power_A.ToString() + " // " + mb.MTR_I_M_AC_Power_B.ToString() + " // " + mb.MTR_I_M_AC_Power_C.ToString();

            //  lb_T_max.Text = mb.Batt_Max_Temperature.ToString();
            pwr_house = I_AC_Power - MTR_I_M_AC_Power;
            lb_pwr_house.Text = pwr_house.ToString() + " W";
            pwr_PV = I_DC_Power + Instantaneous_Power;
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
            try
            {
                statusgraph_dyn();
                lb_error.Text = "OK";
                lb_error.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
               lb_error.Text = ex.Message;
               lb_error.ForeColor = Color.DarkRed;
            }
           
        }


    }
}
