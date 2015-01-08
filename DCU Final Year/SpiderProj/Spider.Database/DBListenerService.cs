using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Spider.Database
{
    public class DBListenerService
    {
        public static DataTable GetStreams(string ConnectionString)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(@"Select StreamsID,IPAddress,PortNumber FROM Streams", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        DataTable dt = new DataTable();
                        try
                        {


                            dt.Columns.Add("StreamsID");
                            dt.Columns.Add("IPAddress");
                            dt.Columns.Add("PortNumber");

                            while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dr["StreamsID"] = reader["StreamsID"].ToString();
                                dr["IPAddress"] = reader["IPAddress"].ToString();
                                dr["PortNumber"] = reader["PortNumber"].ToString();

                                dt.Rows.Add(dr);
                            }
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }



                }
            }
        }
    }
}
