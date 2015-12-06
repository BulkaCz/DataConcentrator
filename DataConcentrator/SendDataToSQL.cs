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
        string connectionString;
        ElektromerDataType elektromer;

        public SendDataToSQL(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public int Send(ElektromerDataType elektromer)
        {
            int result = 0;
            Console.WriteLine("Navazuji spojeni ...");
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Spojeni navazano :) ");

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = sqlConnection.CreateCommand();

                da.SelectCommand = sqlConnection.CreateCommand();
                da.SelectCommand.CommandText = "SELECT * FROM Elektromer";

                da.InsertCommand.CommandText = "INSERT INTO Elektromer (id, cas, cinnaEnergie, jalovaEnergie, cinnyVykon, jalovyVykon, ucinnik) VALUES (@id, @cas, @cinnaEnergie, @jalovaEnergie, @cinnyVykon, @jalovyVykon, @ucinnik)";
                da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                da.InsertCommand.Parameters.Add("@cas", SqlDbType.DateTime2, 8, "cas");
                da.InsertCommand.Parameters.Add("@cinnaEnergie", SqlDbType.Real, 4, "cinnaEnergie");
                da.InsertCommand.Parameters.Add("@jalovaEnergie", SqlDbType.Real, 4, "jalovaEnergie");
                da.InsertCommand.Parameters.Add("@cinnyVykon", SqlDbType.Real, 4, "cinnyVykon");
                da.InsertCommand.Parameters.Add("@jalovyVykon", SqlDbType.Real, 4, "jalovyVykon");
                da.InsertCommand.Parameters.Add("@ucinnik", SqlDbType.Real, 4, "ucinnik");

                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlConnection.Close();

                DataRow dr = ds.Tables[0].NewRow();
                dr["id"] = elektromer.idMericihoBodu;
                dr["cas"] = DateTime.Now;
                dr["cinnaEnergie"] = elektromer.cinnaEnergie;
                dr["jalovaEnergie"] = elektromer.jalovaEnergie;
                dr["cinnyVykon"] = elektromer.cinnyVykon;
                dr["jalovyVykon"] = elektromer.jalovyVykon;
                dr["ucinnik"] = elektromer.ucinnik;
                ds.Tables[0].Rows.Add(dr);
                da.Update(ds);
                result = 1;
            }

            catch(Exception ex)
            {
                result = 0;
            }

            return result;
        }
    }
}
