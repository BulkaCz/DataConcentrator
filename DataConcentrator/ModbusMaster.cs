using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;

namespace DataConcentrator
{
    class ModbusMaster
    {
        ModbusSerialMaster master;
        ElektromerDataType elektromerData = new ElektromerDataType();
        
        public ModbusMaster(ref SerialPort sp)
        {
            master = ModbusSerialMaster.CreateRtu(sp);
            master.Transport.ReadTimeout = 1000;
            master.Transport.Retries = 0;
            sp.Open();
        }
  
        public ElektromerDataType RequestElektromer()
        {
            ushort[] result = new ushort[ElektromerPolls.numberOfRegisters];
            try
            {
                result = master.ReadHoldingRegisters(ElektromerPolls.slaveAddress, ElektromerPolls.startAddress, ElektromerPolls.numberOfRegisters);
                elektromerData.errorCode = 0; 
            }
            catch (Exception ex)
            {
                ModbusException(ex);
                Logging.Write(DateTime.Now.ToString() + " " + ex.Message);
            }
            elektromerData = ResultToElektromer(result);
            return elektromerData;
        }

        private ElektromerDataType ResultToElektromer(ushort[] inputData)
        {
            elektromerData.cas = DateTime.Now;
            elektromerData.cinnaEnergie = UshortToFloat(inputData[0], inputData[1]);
            elektromerData.jalovaEnergie = UshortToFloat(inputData[2], inputData[3]);
            elektromerData.cinnyVykon = UshortToFloat(inputData[4], inputData[5]);
            elektromerData.jalovyVykon = UshortToFloat(inputData[6], inputData[7]);
            elektromerData.ucinnik = UshortToFloat(inputData[8], inputData[9]);
            return elektromerData;
        }

        private void ModbusException(Exception ex)
        {
            if (ex.Source.Equals("System"))
            {
                elektromerData.errorCode = -1;
                Logging.Write(DateTime.Now.ToString() + " " + "Elektromer Modbus Timeout");
            }
            else if (ex.Source.Equals("Modbus"))
            {
                string str = ex.Message;
                int FunctionCode;
                string ExceptionCode;
                str = str.Remove(0, str.IndexOf("\r\n") + 17);
                FunctionCode = Convert.ToInt16(str.Remove(str.IndexOf("\r\n")));
                Console.WriteLine("Function Code: " + FunctionCode.ToString("X"));
                str = str.Remove(0, str.IndexOf("\r\n") + 17);
                ExceptionCode = str.Remove(str.IndexOf("-"));
                elektromerData.errorCode = Int32.Parse(ExceptionCode.Trim());
                Logging.Write(DateTime.Now.ToString() + " " + "Elektromer Modbus error code : " + elektromerData.errorCode.ToString());
            }
            else
            {
                elektromerData.errorCode = -2;
                Logging.Write(DateTime.Now.ToString() + " " + "Elektromer Modbus unknown error ");

            }
        }

        private float UshortToFloat(ushort buffer1, ushort buffer2)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(buffer2 & 0xFF);
            bytes[1] = (byte)(buffer2 >> 8);
            bytes[2] = (byte)(buffer1 & 0xFF);
            bytes[3] = (byte)(buffer1 >> 8);
            float value = BitConverter.ToSingle(bytes, 0);
            return value;
        }
    }
}
