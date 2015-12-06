using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataConcentrator
{
    class SendDataToSQL
    {
        private string connectionString;
        private SendDataToSQLResult result = new SendDataToSQLResult();
        private ElektromerDataType elektromer;

        public SendDataToSQL(string _connectionString)
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
                da.InsertCommand.CommandText = "INSERT INTO Elektromer (id, cas, cinnaEnergie, jalovaEnergie, cinnyVykon, jalovyVykon, ucinnik) VALUES (@id, @cas, @cinnaEnergie, @jalovaEnergie, @cinnyVykon, @jalovyVykon, @ucinnik)";
                da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                da.InsertCommand.Parameters.Add("@cas", SqlDbType.DateTime2, 8, "cas");
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
                dr["cinnaEnergie"] = elektromer.cinnaEnergie;
                dr["jalovaEnergie"] = elektromer.jalovaEnergie;
                dr["cinnyVykon"] = elektromer.cinnyVykon;
                dr["jalovyVykon"] = elektromer.jalovyVykon;
                dr["ucinnik"] = elektromer.ucinnik;
                ds.Tables[0].Rows.Add(dr);
                result.rowsSended = da.Update(ds);
                result.success = true;
            }

            catch(Exception ex)
            {
                result.success = false;
                result.exceptionMessage = ex.Message;
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
