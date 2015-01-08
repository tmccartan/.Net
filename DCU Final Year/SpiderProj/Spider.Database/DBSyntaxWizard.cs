using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBSpider
{
    public class DBSyntaxWizard
    {
        public static bool AddXMLToDB(string XMLFile,string MessageName, string ConnectionString)
        {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO MasterSyntax (MessageName, XMLFile) VALUES(@title,@xml)",connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@title", MessageName);
                        cmd.Parameters.AddWithValue("@xml", XMLFile);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        throw ex;

                    }
                    
               
                    
                }
            }
            
        }
    }
}
