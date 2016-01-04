using System;
using System.Timers;
using System.IO.Ports;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DataConcentrator
{
    class Program
    {
        static string connectionString;
        static int port1_ID;
        static int port2_ID;
        static string port1Device;
        static string port2Device;
        static SerialPort sp1;
        static SerialPort sp2;
        static Timer port1Timer;
        static Timer port2Timer;
        static ModbusRTUMaster modbusMaster1;
        static ModbusRTUMaster modbusMaster2;
        static SendDataToSQLResult port1_SQLresult = new SendDataToSQLResult();
        static SendDataToSQLResult port2_SQLresult = new SendDataToSQLResult();
        

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
                modbusMaster1 = new ModbusRTUMaster(ref sp1);
                port1_ID = Int32.Parse(ConfigurationSettings.AppSettings["Port1_DeviceID"]);
                port1Timer.Elapsed += new ElapsedEventHandler(Port1TimerTick);
                port1Timer.Start();             
            }
            if (port2Enabled)
            {
                int port2PollInterval = Int32.Parse(ConfigurationSettings.AppSettings["Port2_PollInterval"]);
                port2Timer = new Timer(port2PollInterval);
                port2Timer.AutoReset = false;
                sp2 = new SerialPort();
                port2Device = SerialPortConfiguration.SerialPort2Configuration(ref sp2);
                modbusMaster2 = new ModbusRTUMaster(ref sp2);
                port2_ID = Int32.Parse(ConfigurationSettings.AppSettings["Port2_DeviceID"]);
                port2Timer.Elapsed += new ElapsedEventHandler(Port2TimerTick);
                port2Timer.Start();
            }

            Console.ReadLine();
        }

        private static void Port1TimerTick(object source, ElapsedEventArgs e)
        {
            ElektromerDataType elektromer = new ElektromerDataType();
            VahaDataType vaha = new VahaDataType();

            switch (port1Device)
            {
                case "Elektromer":
                    elektromer = modbusMaster1.RequestElektromer();
                    elektromer.idMericihoBodu = port1_ID;
                    SendElektromerToSQL sendElektromerToSQL = new SendElektromerToSQL(connectionString);
                    port1_SQLresult = sendElektromerToSQL.Send(elektromer);
                    port1Timer.Start();
                    break;
                case "Vaha":
                    vaha = modbusMaster1.RequestVaha();
                    vaha.idMericihoBodu = port1_ID;
                    SendVahaToSQL sendVahaToSQL = new SendVahaToSQL(connectionString);
                    port1_SQLresult = sendVahaToSQL.Send(vaha);
                    port1Timer.Start();
                    break;
                default:
                    port1Timer.Start();
                    break;
            }
        }

        private static void Port2TimerTick(object source, ElapsedEventArgs e)
        {
            ElektromerDataType elektromer = new ElektromerDataType();
            VahaDataType vaha = new VahaDataType();

            switch (port2Device)
            {
                case "Elektromer":
                    elektromer = modbusMaster2.RequestElektromer();
                    elektromer.idMericihoBodu = port2_ID;
                    SendElektromerToSQL sendElektromerToSQL = new SendElektromerToSQL(connectionString);
                    port2_SQLresult = sendElektromerToSQL.Send(elektromer);
                    port2Timer.Start();
                    break;
                case "Vaha":
                    vaha = modbusMaster2.RequestVaha();
                    vaha.idMericihoBodu = port2_ID;
                    SendVahaToSQL sendVahaToSQL = new SendVahaToSQL(connectionString);
                    port2_SQLresult = sendVahaToSQL.Send(vaha);
                    port2Timer.Start();
                    break;
                default:
                    port2Timer.Start();
                    break;
            }
        }
    }
}
