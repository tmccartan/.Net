using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSpider;
using System.Data;
using Spider.Business;


    public class UserService
    {

        public static BOUser GetBOUser(string userName, string password)
        {
            BOUser user = new BOUser();

            DataTable UserDetails = DBUser.GetUserDetails(userName, password, BOLookup.ConnectionString);
            foreach (DataRow dr in UserDetails.Rows)
            {
                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.UserName = dr["UserName"].ToString();
                user.Password = dr["Password"].ToString();
                user.IsAdvanced = Boolean.Parse(dr["IsAdvanced"].ToString());
            }
            return user;
        }
        public static bool CheckUserLogin(string userName, string password)
        {
            return DBUser.CheckUserLogOn(userName, password,BOLookup.ConnectionString);
        }

        public static DataSet GetAllUsers()
        {
            return DBUser.GetAllUsersReturnDataSet(BOLookup.ConnectionString);
        }

        public static bool UpdateUserDetails(string UserName, string Password, int UserID, bool IsAdvanced)
        {
            return DBUser.UpdateUserRecord(UserName, Password, UserID, IsAdvanced, BOLookup.ConnectionString);
        }

        public static bool CreateNewUser(string UserName, string Password, bool IsAdvanced)
        {
            return DBUser.CreateUserRecord(UserName, Password, IsAdvanced,BOLookup.ConnectionString);
        }

        public static BOUser GetBOUserByUserID(int userID)
        {
            BOUser user = new BOUser();

            DataTable UserDetails = DBUser.GetUserDetailsByID(userID, BOLookup.ConnectionString);
            foreach (DataRow dr in UserDetails.Rows)
            {
                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.UserName = dr["UserName"].ToString();
                user.Password = dr["Password"].ToString();
                user.IsAdvanced = Boolean.Parse(dr["IsAdvanced"].ToString());
            }
            return user;
        }
    }

