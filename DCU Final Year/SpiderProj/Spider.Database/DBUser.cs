using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBSpider
{
    public class DBUser
    {
        public static DataTable GetUserDetails(string userName, string password, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID, UserName, Password, IsAdvanced FROM Users WHERE UserName = @userName AND Password = @password", connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        try
                        {


                            dt.Columns.Add("UserName");
                            dt.Columns.Add("Password");
                            dt.Columns.Add("UserID");
                            dt.Columns.Add("IsAdvanced");

                            while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dr["UserName"] = reader["UserName"].ToString();
                                dr["Password"] = reader["Password"].ToString();
                                dr["UserID"] = reader["UserID"].ToString();
                                dr["IsAdvanced"] = reader["IsAdvanced"].ToString();

                                dt.Rows.Add(dr);
                            }
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            return dt;
                        }

                    }
                }
            }
        }
        public static bool CheckUserLogOn(string userName, string password, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID FROM Users WHERE UserName = @userName AND Password = @password", connection))
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
                                userID = Int32.Parse(reader["UserID"].ToString());
                                if (userID > 0)
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
        }

        public static DataSet GetAllUsersReturnDataSet(string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID,UserName FROM Users", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.SelectCommand.CommandTimeout = 0;        
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        public static bool UpdateUserRecord(string UserName, string Password, int UserID, bool IsAdvanced, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Update Users set UserName = @userName,Password = @password, IsAdvanced = @IsAdvanced WHERE UserID = @UserID", connection))
                {
                    try
                    {
                        bool result = false;
                        cmd.Parameters.AddWithValue("@userName", UserName);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@IsAdvanced", IsAdvanced);
                        cmd.ExecuteNonQuery();
                        result = true;
                        return result;

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        public static bool CreateUserRecord(string UserName, string Password, bool IsAdvanced, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, Password, IsAdvanced) VALUES (@userName,@password,@isAdvanced) ", connection))
                {
                    try
                    {
                        bool result = false;
                        cmd.Parameters.AddWithValue("@userName", UserName);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@isAdvanced", IsAdvanced);
                        cmd.ExecuteNonQuery();
                        result = true;
                        return result;

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static DataTable GetUserDetailsByID(int userID, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Select UserID, UserName, Password, IsAdvanced FROM Users WHERE UserID = @userID", connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        try
                        {


                            dt.Columns.Add("UserName");
                            dt.Columns.Add("Password");
                            dt.Columns.Add("UserID");
                            dt.Columns.Add("IsAdvanced");

                            while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dr["UserName"] = reader["UserName"].ToString();
                                dr["Password"] = reader["Password"].ToString();
                                dr["UserID"] = reader["UserID"].ToString();
                                dr["IsAdvanced"] = reader["IsAdvanced"].ToString();

                                dt.Rows.Add(dr);
                            }
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            return dt;
                        }

                    }
                }
            }
        }
    }
}
