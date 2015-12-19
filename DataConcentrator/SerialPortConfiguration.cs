using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO.Ports;

namespace DataConcentrator
{
    static class SerialPortConfiguration
    {
        enum Device { Elektromer, Vaha, Popelomer, None };

        public static byte SerialPort1Configuration(ref SerialPort _sp1)
        {
            _sp1 = new SerialPort();
            int port1_BaudRate = Int32.Parse(ConfigurationSettings.AppSettings["Port1_BaudRate"]);
            int port1_DataBit = Int32.Parse(ConfigurationSettings.AppSettings["Port1_DataBit"]);
            int port1_StopBit = Int32.Parse(ConfigurationSettings.AppSettings["Port1_StopBit"]);
            string port1_Parity = ConfigurationSettings.AppSettings["port1_Parity"];
            string port1_Name = ConfigurationSettings.AppSettings["port1_Name"];

            _sp1.PortName = port1_Name;
            _sp1.BaudRate = port1_BaudRate;
            _sp1.DataBits = port1_DataBit;
            if (port1_Parity == "E") _sp1.Parity = Parity.Even;
            else if (port1_Parity == "O") _sp1.Parity = Parity.Odd;
            else if (port1_Parity == "N") _sp1.Parity = Parity.None;
            else _sp1.Parity = Parity.None;

            if (port1_StopBit == 0) _sp1.StopBits = StopBits.None;
            else if (port1_StopBit == 1) _sp1.StopBits = StopBits.One;
            else if (port1_StopBit == 2) _sp1.StopBits = StopBits.Two;
            else _sp1.StopBits = StopBits.One;

            return Byte.Parse(ConfigurationSettings.AppSettings["Port1_Device"]);
        }

        public static byte SerialPort2Configuration(ref SerialPort _sp2)
        {
            _sp2 = new SerialPort();
            int port2_BaudRate = Int32.Parse(ConfigurationSettings.AppSettings["Port2_BaudRate"]);
            int port2_DataBit = Int32.Parse(ConfigurationSettings.AppSettings["Port2_DataBit"]);
            int port2_StopBit = Int32.Parse(ConfigurationSettings.AppSettings["Port2_StopBit"]);
            string port2_Parity = ConfigurationSettings.AppSettings["port2_Parity"];
            string port2_Name = ConfigurationSettings.AppSettings["port2_Name"];

            _sp2.PortName = port2_Name;
            _sp2.BaudRate = port2_BaudRate;
            _sp2.DataBits = port2_DataBit;
            if (port2_Parity == "E") _sp2.Parity = Parity.Even;
            else if (port2_Parity == "O") _sp2.Parity = Parity.Odd;
            else if (port2_Parity == "N") _sp2.Parity = Parity.None;
            else _sp2.Parity = Parity.None;

            if (port2_StopBit == 0) _sp2.StopBits = StopBits.None;
            else if (port2_StopBit == 1) _sp2.StopBits = StopBits.One;
            else if (port2_StopBit == 2) _sp2.StopBits = StopBits.Two;
            else _sp2.StopBits = StopBits.One;

            return Byte.Parse(ConfigurationSettings.AppSettings["Port2_Device"]);
        }
    }
}
