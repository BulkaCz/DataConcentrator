using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace DataConcentrator
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=tcp:cevelsql.database.windows.net,1433; Database=CevelDB; User ID=BulkaCz@cevelsql; Password=Hovnohovno11; Trusted_Connection=False; Encrypt=True; Connection Timeout=10;";
            //string connectionString = "Server=tcp:cevelsql.database.windows.net,1433; Database=CevelSQL; User ID=BulkaCz@cevelsql; Password=Hovnohovno11; Encrypt=True; TrustServerCertificate=False; Connection Timeout=10;";
            //string connectionString = "Data Source=DESKTOP-OKII9AL\\SQLEXPRESS;Initial Catalog = CevelSQL; Integrated Security = True; Connection Timeout=3";
            ElektromerDataType elektromer = new ElektromerDataType();
            elektromer.idMericihoBodu = 1;
            elektromer.cas = DateTime.Now;
            elektromer.cinnaEnergie = 111.0f;
            elektromer.jalovaEnergie = 222.0f;
            elektromer.cinnyVykon = 33.0f;
            elektromer.jalovyVykon = 44.0f;
            elektromer.ucinnik = 0.99f;
            SendDataToSQL sendDataToSQL = new SendDataToSQL(connectionString);
            int result = sendDataToSQL.Send(elektromer);
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
