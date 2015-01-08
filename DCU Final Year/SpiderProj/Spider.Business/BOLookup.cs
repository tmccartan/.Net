using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider.Business
{
    public class BOLookup
    {

        private static string _ConnectionString;

        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value;}

        }
    }
}
