using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataConcentrator
{
    static class Logging
    {
        static public void Write(string zaznam)
        {
            try
            {
                StreamWriter log = new StreamWriter("log.txt", true);
                log.WriteLine(zaznam);
                log.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}