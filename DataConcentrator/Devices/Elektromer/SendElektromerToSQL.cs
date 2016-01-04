using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataConcentrator
{
    class SendElektromerToSQL
    {
        private string connectionString;
        private SendDataToSQLResult result = new SendDataToSQLResult();

        public SendElektromerToSQL(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public SendDataToSQLResult Send(ElektromerDataType elektromer)
        {
            result.exceptionMessage = "All OK :)";
            result.success = false;
            result.rowsSended = 0;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataRow dr;

                sqlConnection.Open();

                da.SelectCommand = sqlConnection.CreateCommand();
                da.SelectCommand.CommandText = "SELECT * FROM Elektromer";

                da.InsertCommand = sqlConnection.CreateCommand();
                da.InsertCommand.CommandText = "INSERT INTO Elektromer (id, cas, errorCode, cinnaEnergie, jalovaEnergie, cinnyVykon, jalovyVykon, ucinnik) VALUES (@id, @cas, @errorCode, @cinnaEnergie, @jalovaEnergie, @cinnyVykon, @jalovyVykon, @ucinnik)";
                da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                da.InsertCommand.Parameters.Add("@cas", SqlDbType.DateTime2, 8, "cas");
                da.InsertCommand.Parameters.Add("@errorCode", SqlDbType.Int, 4, "errorCode");
                da.InsertCommand.Parameters.Add("@cinnaEnergie", SqlDbType.Real, 4, "cinnaEnergie");
                da.InsertCommand.Parameters.Add("@jalovaEnergie", SqlDbType.Real, 4, "jalovaEnergie");
                da.InsertCommand.Parameters.Add("@cinnyVykon", SqlDbType.Real, 4, "cinnyVykon");
                da.InsertCommand.Parameters.Add("@jalovyVykon", SqlDbType.Real, 4, "jalovyVykon");
                da.InsertCommand.Parameters.Add("@ucinnik", SqlDbType.Real, 4, "ucinnik");

                da.Fill(ds);
                sqlConnection.Close();

                dr = ds.Tables[0].NewRow();
                dr["id"] = elektromer.idMericihoBodu;
                dr["cas"] = elektromer.cas;
                dr["errorCode"] = elektromer.errorCode;
                dr["cinnaEnergie"] = elektromer.cinnaEnergie;
                dr["jalovaEnergie"] = elektromer.jalovaEnergie;
                dr["cinnyVykon"] = elektromer.cinnyVykon;
                dr["jalovyVykon"] = elektromer.jalovyVykon;
                dr["ucinnik"] = elektromer.ucinnik;
                ds.Tables[0].Rows.Add(dr);
                result.rowsSended = da.Update(ds);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(DateTime.Now.ToString() + " Úspěšný zápis dat z elektroměru do SQL");
                Console.ForegroundColor = ConsoleColor.Gray;
                result.success = true;
            }

            catch(Exception ex)
            {
                result.success = false;
                result.exceptionMessage = ex.Message;
                Logging.Write(DateTime.Now.ToString() + " " + ex.Message);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            return result;
        }
    }
}
