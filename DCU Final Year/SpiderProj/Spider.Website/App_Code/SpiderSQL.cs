using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectWebApp.AppCode
{
    public class SpiderSQL
    {
        /*public static DataTable GetUserDetails(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpiderCS"].ToString()))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID, UserName, Password FROM Users WHERE UserName = @userName AND Password = @password",connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            

                            dt.Columns.Add("userName");
                            dt.Columns.Add("password");
                            dt.Columns.Add("userID");

                            while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dr["userName"] = reader["userName"].ToString();
                                dr["password"] = reader["password"].ToString();
                                dr["userID"] = reader["userID"].ToString();

                                dt.Rows.Add(dr);
                            }
                            return dt;
                        }
                        catch(Exception ex)
                        {
                            return dt;
                        }
               
                    }
                }
            }
        }
        public static bool CheckUserLogOn(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpiderCS"].ToString()))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID FROM Users WHERE UserName = @userName AND Password = @password",connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool IsSuccess = false;
                        try
                        {
                            int userID;

                            while (reader.Read())
                            {
                               userID = Int32.Parse(reader["userID"].ToString());
                               if(userID>0)
                               {
                                   IsSuccess = true;
                                   
                               }
                            }
                            return IsSuccess;
                           
                        }
                        catch (Exception ex)
                        {
                            return IsSuccess;
                        }

                    }
                }
            }
        }*/
    }
}
