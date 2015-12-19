using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    static public class ElektromerPolls
    {
        public const byte commandCount = 1;
        public const byte function = 3;
        public const byte slaveAddress = 1;
        public const ushort startAddress = 0;
        public const ushort numberOfRegisters = 10;
    }
}
