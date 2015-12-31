using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    static public class VahaPolls
    {
        public const byte commandCount = 1;
        public const byte function = 3;
        public const byte slaveAddress = 12;
        public const ushort startAddress = 10;
        public const ushort numberOfRegisters = 6;
    }
}
