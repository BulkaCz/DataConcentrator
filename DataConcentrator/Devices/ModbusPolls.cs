using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    class ModbusPolls
    {
        public byte function;
        public byte slaveAddress;
        public ushort startAddress;
        public ushort numberOfRegisters;

        public ModbusPolls(byte _function, byte _slaveAddress, ushort _startAddress, ushort _numberOfRegisters)
        {
            function = _function;
            slaveAddress = _slaveAddress;
            startAddress = _startAddress;
            numberOfRegisters = _numberOfRegisters;
        }
        
    }
}
