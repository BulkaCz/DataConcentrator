using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    class Program
    {
        static void Main(string[] args)
        {
            ElektromerDataType elektromer = new ElektromerDataType();
            elektromer.idMericihoBodu = 1;
            elektromer.cas = DateTime.Now;
            elektromer.cinnaEnergie = 111.0f;
            elektromer.jalovaEnergie = 222.0f;
            elektromer.cinnyVykon = 33.0f;
            elektromer.jalovyVykon = 44.0f;
            elektromer.ucinnik = 0.99f;
            SendDataToSQL sendDataToSQL = new SendDataToSQL("Data Source=DESKTOP-OKII9AL\\SQLEXPRESS;Initial Catalog = CevelSQL; Integrated Security = True");
            sendDataToSQL.Send(elektromer);
            Console.ReadLine();
        }
    }
}
