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
                string date = DateTime.Now.ToShortDateString().Replace('.', '-');
                //date = date.Replace('/', '-');
                StreamWriter log = new StreamWriter("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\" + date + ".log", true);
                log.WriteLine(zaznam);
                log.Close();
                DateTime datetime = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(zaznam);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch(Exception ex)
            {

            }

        }
    }
}