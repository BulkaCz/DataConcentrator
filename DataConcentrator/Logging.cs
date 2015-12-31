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
                StreamWriter log = new StreamWriter("C:\\Users\\Bulka\\Source\\Repos\\DataConcentrator\\" + date + ".log", true);
                log.WriteLine(zaznam);
                log.Close();
                DateTime datetime = DateTime.Now;
                Console.WriteLine(date);         
            }
            catch(Exception ex)
            {

            }

        }
    }
}