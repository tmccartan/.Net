using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class BOUser
    {
        private string _UserName;
        private int _UserID;
        private string _Password;
        private bool _isAdvanced;

        public BOUser()
        {

        }
                
        public string UserName
        {
            get{return _UserName;}
            set { _UserName = value; }
        }

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public bool IsAdvanced
        {
            get { return _isAdvanced; }
            set { _isAdvanced = value; }
        }
    }

