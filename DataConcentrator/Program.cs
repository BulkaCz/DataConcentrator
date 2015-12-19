using System;
using System.Timers;
using System.IO.Ports;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DataConcentrator
{
    class Program
    {
        static string connectionString;
        static int port1_ID;
        static byte port1Device;
        static SerialPort sp1;
        static SerialPort sp2;
        static Timer port1Timer;
        static Timer port2Timer;
        static ModbusMaster modbusMaster1;
        static ModbusMaster modbusMaster2;
        static SendDataToSQLResult port1_SQLresult = new SendDataToSQLResult();
        static SendDataToSQLResult port2_SQLresult = new SendDataToSQLResult();
        static ElektromerDataType elektromer = new ElektromerDataType();

        enum Device { Elektromer, Vaha, Popelomer };

        static void Main(string[] args)
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            string p1Enabled = ConfigurationSettings.AppSettings["Port1_Enabled"];
            bool port1Enabled = Boolean.Parse(p1Enabled);
            string p2Enabled = ConfigurationSettings.AppSettings["Port2_Enabled"];
            bool port2Enabled = Boolean.Parse(p2Enabled);
            if (port1Enabled)
            {         
                int port1PollInterval = Int32.Parse(ConfigurationSettings.AppSettings["Port1_PollInterval"]);
                port1Timer = new Timer(port1PollInterval);
                port1Timer.AutoReset = false;
                sp1 = new SerialPort();
                port1Device = SerialPortConfiguration.SerialPort1Configuration(ref sp1);
                modbusMaster1 = new ModbusMaster(ref sp1);
                port1_ID = Int32.Parse(ConfigurationSettings.AppSettings["Port1_DeviceID"]);
                port1Timer.Elapsed += new ElapsedEventHandler(Port1TimerTick);
                port1Timer.Start();             
            }
            if (port2Enabled)
            {
                byte port2Device = SerialPortConfiguration.SerialPort2Configuration(ref sp2);
            }

            Console.ReadLine();
        }

        private static void Port1TimerTick(object source, ElapsedEventArgs e)
        {
            switch (port1Device)
            {
                case 1:
                    elektromer = modbusMaster1.RequestElektromer();
                    elektromer.idMericihoBodu = port1_ID;
                    SendElektromerToSQL sendElektromerToSQL = new SendElektromerToSQL(connectionString);
                    port1_SQLresult = sendElektromerToSQL.Send(elektromer);
                    port1Timer.Start();
                    break;
                default:
                    port1Timer.Start();
                    break;
            }
        }
    }
}
