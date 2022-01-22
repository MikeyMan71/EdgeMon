using System;
using System.Windows.Forms;
using System.Drawing;

namespace EdgeMon
{
    public partial class EdgeMon : Form
    {
        TcpModbus mb; 


        public EdgeMon()
        {
            InitializeComponent();
            timer1.Enabled = false;
            mb = null;
            try
            {
                mb = new TcpModbus(Properties.Settings.Default.TCP, Properties.Settings.Default.port);
            }
            catch (Exception)
            {
                MessageBox.Show("No SE device found on address [" + Properties.Settings.Default.TCP + "] , Port [" + Properties.Settings.Default.port+"]");
                Application.Exit();
            }



            statusgraph_static();
            timer1.Enabled = true;
        }


        private void statusgraph_static()
        {
           
            lb_version.Text = mb.C_Version;

            tb_batManu.Clear();
            tb_batManu.AppendText(mb.BatteryManufacturerName);
            tb_batManu.AppendText("\r\n"+mb.BatteryModelName);
            tb_batManu.AppendText("\r\n" + mb.BatteryFirmware);
            tb_batManu.AppendText("\r\n" + mb.BatterySerialNr);
            lbl_mtr_manu.Text = mb.MTR_C_Manufacturer;
            lb_mtr_model.Text = mb.MTR_C_Model;
            lb_mtr_sernr.Text = mb.MTR_C_SerNumber;
            lb_mtr_opt.Text = mb.MTR_C_Option;
            lb_mtr_ver.Text = mb.MTR_C_Version;
            lb_bat_max.Text = (mb.Batt_Max_Energy/1000).ToString()+ " kWh";
        }
        private void statusgraph_dyn()
        {
            
            lb_SOH.Text = mb.SOH.ToString()+" %";
            bat_SOE.Value = (int)mb.SOE;
            lb_SOE_TXT.Text = mb.SOE.ToString() + " %";
            lb_bat_stat.Text = mb.Bat_Status.ToString();
            lb_status.Text = mb.I_Status.ToString();
            lb_update.Text = DateTime.Now.ToString();
            lb_ac_pwr.Text = mb.I_AC_Power.ToString()+" W";
            lb_dc_pwr.Text = mb.I_DC_Power.ToString()+ " W";
            lb_temp.Text = mb.I_Temp_Sink.ToString()+"°C";
            ImpExMeter.Text = mb.MTR_I_M_AC_Power.ToString() + " W";
            lb_batt_pwr.Text = mb.Instantaneous_Power.ToString() + " W";
            MB_Pwr_3.Text = mb.MTR_I_M_AC_Power_A.ToString() + " // " + mb.MTR_I_M_AC_Power_B.ToString() + " // " + mb.MTR_I_M_AC_Power_C.ToString();
            lb_T_Av.Text = mb.Batt_Average_Temperature.ToString()+ "°C";
            //  lb_T_max.Text = mb.Batt_Max_Temperature.ToString();
          


        }



        private void textinfo()
        {
            textBox1.Clear();

            textBox1.AppendText("C_Manufacturer " + mb.C_Manufacturer);
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("C_Model " + mb.C_Model);
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.C_SerialNumber);
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.C_Version);
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.C_SunSpec_DID.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_DC_Voltage.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_AC_Current.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_AC_CurrentA.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_AC_CurrentB.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_AC_CurrentC.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("I_AC_Energy_WH" + mb.I_AC_Energy_WH.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.I_DC_Current.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("I_DC_Power " + mb.I_DC_Power.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("I_Temp_Sink " + mb.I_Temp_Sink.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("I_Status " + mb.I_Status.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.Lifetime_Export_Energy_Counter.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText(mb.Lifetime_Import_Energy_Counter.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("Instantaneous_Power " + mb.Instantaneous_Power.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("Batt_Avail_Energy " + mb.Batt_Avail_Energy.ToString());
            textBox1.Text += System.Environment.NewLine;
            textBox1.AppendText("Batt_Max_Energy " + mb.Batt_Max_Energy.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusgraph_dyn();
        }

        private void lb_batManu_Click(object sender, EventArgs e)
        {

        }

        private void lb_batManu_ClientSizeChanged(object sender, EventArgs e)
        {

        }

      
    }
}
