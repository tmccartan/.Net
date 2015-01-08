using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace ListenerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //DataTable dt = GetParams();
            //string ip;
            //string pn;
            //DataRow dr = dt.Rows[0];
            //ip = dr["IP"].ToString();
            //pn = dr["PortNumber"].ToString();
            string ip;
            string pn;
            TextReader tw = new StreamReader(@"C:\temp\Streams.txt");
            ip = tw.ReadLine();
            pn = tw.ReadLine();
            tw.Close();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new SpiderListener() 
            };
            ServiceBase.Run(ServicesToRun);
        }
      
    }
}
