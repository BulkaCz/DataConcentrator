using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataConcentrator
{
    class SendVahaToSQL
    {
        private string connectionString;
        private SendDataToSQLResult result = new SendDataToSQLResult();

        public SendVahaToSQL(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public SendDataToSQLResult Send(VahaDataType vaha)
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
                da.SelectCommand.CommandText = "SELECT * FROM Vaha";

                da.InsertCommand = sqlConnection.CreateCommand();
                da.InsertCommand.CommandText = "INSERT INTO Vaha (id, cas, errorCode, vahaVykon, vahaABS, RychlostPasu) VALUES (@id, @cas, @errorCode, @vahaVykon, @vahaABS, @RychlostPasu)";
                da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                da.InsertCommand.Parameters.Add("@cas", SqlDbType.DateTime2, 8, "cas");
                da.InsertCommand.Parameters.Add("@errorCode", SqlDbType.Int, 4, "errorCode");
                da.InsertCommand.Parameters.Add("@vahaVykon", SqlDbType.Real, 4, "vahaVykon");
                da.InsertCommand.Parameters.Add("@vahaABS", SqlDbType.Real, 4, "vahaABS");
                da.InsertCommand.Parameters.Add("@RychlostPasu", SqlDbType.Real, 4, "RychlostPasu");

                da.Fill(ds);
                sqlConnection.Close();

                dr = ds.Tables[0].NewRow();
                dr["id"] = vaha.idMericihoBodu;
                dr["cas"] = vaha.cas;
                dr["errorCode"] = vaha.errorCode;
                dr["vahaVykon"] = vaha.okamzityVykon;
                dr["vahaABS"] = vaha.absolutniCitac;
                dr["RychlostPasu"] = vaha.rychlostPD;
                ds.Tables[0].Rows.Add(dr);
                result.rowsSended = da.Update(ds);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Úspěšný zápis dat z váhy do SQL");
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
