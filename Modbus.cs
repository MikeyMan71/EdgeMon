using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using EnumsNET;

namespace EdgeMon
{
    class TcpModbus : EasyModbus.ModbusClient
    {

        public TcpModbus(string IpAddress, int port ):base(IpAddress, port)
        {
            Connect();
            

        }


        /// <summary>
        /// Converts 16 - Bit Register values to String
        /// </summary>
        /// <param name="registers">Register array received via Modbus</param>
        /// <param name="offset">First Register containing the String to convert</param>
        /// <param name="stringLength">number of characters in String (must be even)</param>
        /// <returns>Converted String</returns>
        public static string ConvertRegistersToString(int[] registers, int offset, int stringLength, RegisterOrder registerOrder=RegisterOrder.LowHigh)
        {
            byte[] result = new byte[stringLength];
            byte[] registerResult = new byte[2];

            for (int i = 0; i < stringLength / 2; i++)
            {
                registerResult = BitConverter.GetBytes(registers[offset + i]);
                result[i * 2] = registerResult[registerOrder==RegisterOrder.HighLow?0:1];
                result[i * 2 + 1] = registerResult[registerOrder == RegisterOrder.HighLow ? 1 : 0];
            }
            return System.Text.Encoding.Default.GetString(result);
        }


        public static short ConvertRegistersToShort(int[] registers, RegisterOrder registerOrder=RegisterOrder.LowHigh)
        {
            return (short)registers[0];
        }


        string GetModbusString(int registers, int size)
        {
            int[] reg = ReadHoldingRegisters(registers, size);
            return ConvertRegistersToString(reg, 0, size * 2).Trim('\0');
        }

        int GetModubusUint32(int registers)
        {
            int[] reg = ReadHoldingRegisters(registers, 2);
            return ConvertRegistersToShort(reg);
        }
        int GetModubusUint16(int registers)
        {
            int[] reg = ReadHoldingRegisters(registers, 1);
            return ConvertRegistersToShort(reg, RegisterOrder.LowHigh);
        }

        double GetModbusScaledShort(int registers, int scaling=1)
        {
            double res;
            int[] reg = ReadHoldingRegisters(registers, scaling+1);
            res = reg[0];
            if (scaling >0) res*=Math.Pow(10, reg[scaling]);
            return res;
        }

        double GetModbusScaledLong(int registers, int scaling =2)
        {
            double res;
            int[] reg = ReadHoldingRegisters(registers, scaling+1);
            res = ConvertRegistersToInt(reg, RegisterOrder.HighLow); 
            if (scaling > 0) res *= Math.Pow(10, reg[scaling]);
            return res;
           
        }


        double GetModbusdLong(int registers)
        {
            double res;
            int[] reg = ReadHoldingRegisters(registers, 4);
            res = ConvertRegistersToLong(reg);
            
            return res;

        }

        double GetModbusFloat32(int registers)
        {
            double res;
            int[] reg = ReadHoldingRegisters(registers,2);
            res = ConvertRegistersToFloat(reg);
            
            return res;
        }

        public enum I_STAT
        {
            [Description("OFF")]
            I_STATUS_OFF = 1,
            [Description("SLEEPING")]
            I_STATUS_SLEEPING = 2,//Sleeping(auto-shutdown) – Night mode
            [Description("STARTING")]
            I_STATUS_STARTING = 3,//Grid Monitoring/wake-up
            [Description("MPPT")]
            I_STATUS_MPPT = 4,//Inverter is ON and producing power
            [Description("THROTTLED")]
            I_STATUS_THROTTLED = 5,//Production(curtailed)
            [Description("SHUTTING_DOWN")]
            I_STATUS_SHUTTING_DOWN = 6,//Shutting down
            [Description("FAULT")]
            I_STATUS_FAULT = 7,//Fault
            [Description("STANDBY")] //Maintenance/setup
            I_STATUS_STANDBY = 8 


    }

        public enum SolarEdgeBatteryStatusFlagEnum
        {
            [Description("OFF")]
            Off = 0,
            [Description("Standby")]
            Standby = 10,
            [Description("Init")]
            Init = 2,
            [Description("Charge")]
            Charge = 3,
            [Description("Discharge")]
            Discharge = 4,
            [Description("Fault")]
            Fault = 5,
            [Description("Idle")]
            Idle = 7,
            [Description("Idle_Full")]
            Idle_full = 6,
        }





        public string C_Manufacturer { get { return GetModbusString(40004, 16); }  }
        public string C_Model { get { return GetModbusString(40020, 16); } }
        public string C_Version { get { return GetModbusString(40044, 8); } }
        public string C_SerialNumber { get { return GetModbusString(40052, 16); } }
        public int C_SunSpec_DID { get { return GetModubusUint16(40069); } }
        
        public double I_AC_Current { get { return GetModbusScaledShort(40071, 4);  }  }
        public double I_AC_CurrentA { get { return GetModbusScaledShort(40072, 3); } }
        public double I_AC_CurrentB { get { return GetModbusScaledShort(40073, 2); } }
        public double I_AC_CurrentC { get { return GetModbusScaledShort(40074, 1); } }
        public double I_AC_Power { get { return GetModbusScaledShort(40083, 1); } }
        public double I_AC_Frequency { get { return GetModbusScaledShort(40085, 1); } }
        public double I_AC_VA { get { return GetModbusScaledShort(40087, 1); } }
        public double I_AC_VAR { get { return GetModbusScaledShort(40089, 1); } }
        public double I_AC_PF { get { return GetModbusScaledShort(40091, 1); } }
        public double I_AC_Energy_WH { get { return GetModbusScaledLong(40093,2); } }
        public double I_DC_Current { get { return GetModbusScaledShort(40096, 1); } }
        public double I_DC_Voltage { get { return GetModbusScaledShort(40098, 1); } }
        public double I_DC_Power { get { return GetModbusScaledShort(40100, 1); } }
        public double I_Temp_Sink { get { return GetModbusScaledShort(40103, 3); } }


        public string I_Status { get { return ((I_STAT)GetModbusScaledShort(40107)).AsString(EnumFormat.Description); } }

        //Meters
        public string MTR_C_Manufacturer { get { return GetModbusString(40123, 16); } }
        public string MTR_C_Model { get { return GetModbusString(40139, 16); } }
        public string MTR_C_SerNumber { get { return GetModbusString(40171, 16); } }
        public string MTR_C_Option { get { return GetModbusString(40155, 8); } }
        public string MTR_C_Version { get { return GetModbusString(40163, 8); } }
        public double MTR_I_M_AC_Power { get {return GetModbusScaledShort(40206,4); } }
        public double MTR_I_M_AC_Power_A { get { return GetModbusScaledShort(40207, 3); } }
        public double MTR_I_M_AC_Power_B { get { return GetModbusScaledShort(40208, 2); } }
        public double MTR_I_M_AC_Power_C { get { return GetModbusScaledShort(40209, 1); } }










        public double Instantaneous_Power { get { return GetModbusFloat32(0xE174); } }

        public double Instantaneous_Voltage { get { return GetModbusFloat32(0xE170); } }
        public double Instantaneous_Current { get { return GetModbusFloat32(0xE172); } }
        public double Lifetime_Export_Energy_Counter { get { return GetModbusdLong(57718); } }
        public double Lifetime_Import_Energy_Counter { get { return GetModbusdLong(57722); } }

        public double Batt_Max_Energy { get { return GetModbusFloat32(57726); } }
        public double Batt_Avail_Energy { get { return GetModbusFloat32(0xE180); } }

        public double Max_Charge_Continues_Power { get { return GetModbusFloat32(0xE144); } }
        public double Max_Discharge_Continues_Power { get { return GetModbusFloat32(0xE146); } }
        public double Max_Charge_Peak_Power { get { return GetModbusFloat32(0xE148 ); } }
        public double Max_Discharge_Peak_Power { get { return GetModbusFloat32(0xE14A ); } }



        public double Batt_Average_Temperature { get { return GetModbusFloat32(0xE16C ); } }

        public double Batt_Max_Temperature { get { return GetModbusFloat32(0xE16E); } }

      




        public double SOH { get { return GetModbusFloat32 (0xE182); } }
        public double SOE { get { return GetModbusFloat32(0xE184); } }
        public string BatteryManufacturerName { get { return GetModbusString(0xE100,  16 ); } }
        public string BatteryModelName { get { return GetModbusString(0xE110, 16); } }
       public string BatteryFirmware { get { return GetModbusString(0xE120, 16); } }
        public string BatterySerialNr { get { return GetModbusString(0xE130, 16); } }

        public string Bat_Status { get {return  ((SolarEdgeBatteryStatusFlagEnum)GetModubusUint32 (0xE186)).AsString(EnumFormat.Description); } }
        public string Bat_Status_Int { get { return GetModubusUint32(0xE188).ToString(); } }
        public string Event_Log { get { return GetModubusUint16(0xE192).ToString(); } }

    }
}
