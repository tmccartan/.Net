using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using ListenerService.ServiceCode;
using Spider.Business;
using System.Configuration;

namespace ListenerService
{
    public partial class SpiderListener : ServiceBase
    {
        internal static string serverMSG;
        private TcpListener tcpListener;
        private Thread listenThread;
        private string IPAdress ;//="127.0.0.1";
        private string PortNumber;// = "3000";


        public SpiderListener()
        {
            InitializeComponent();
            
        }
        
        protected override void OnStart(string[] args)
        {
                        
            FileStream fs = new FileStream(@"c:\temp\mcWindowsService.txt",
            FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(" mcWindowsService: Service Started \n");
            m_streamWriter.Flush();
            
            DataTable StreamTable = ServiceForListener.GetStreamsForService(@"Data Source=localhost\SQLEXPRESS;Initial Catalog= SpiderV1;Persist Security Info=True; User ID= SpiderUser;Password=sp1d3r");
            m_streamWriter.WriteLine("FetchedStreams");
            m_streamWriter.Flush();
            
            foreach (DataRow dr in StreamTable.Rows)
            {
                          
                TcpListener tcpListener = new TcpListener(IPAddress.Parse(dr["IPAddress"].ToString().Trim()), Convert.ToInt32(dr["PortNumber"]));
                Thread listenThread = new Thread(new ParameterizedThreadStart(ListenForClients));
                listenThread.Start(tcpListener);
            }
            m_streamWriter.WriteLine(" SetupClients");
            m_streamWriter.Flush();
            m_streamWriter.Close();
            
        }

        protected override void OnStop()
        {
            FileStream fs = new FileStream(@"c:\temp\mcWindowsService.txt",
            FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(" mcWindowsService: Service Stopped \n"); m_streamWriter.Flush();
            m_streamWriter.Close(); 
        }
        private void ListenForClients(object Listener)
        {
            TcpListener tcpListener = (TcpListener)Listener;
            tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();

                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                string clientMessage = encoder.GetString(message, 0, bytesRead);

                //call HL7 decoder
                serverMSG = clientMessage;
                Regex reg = new Regex(@"([A-Z]:\\[^/:\*\?<>\|]+\.\w{2,6})|(\\{2}[^/:\*\?<>\|]+\.\w{2,6})");
                Match regexPatternMatch  =  reg.Match(serverMSG);
                serverMSG = serverMSG.Replace(regexPatternMatch.ToString(), string.Empty);
                serverMSG = serverMSG.Replace("$$", string.Empty);
                string configFile = regexPatternMatch.ToString();

                TextWriter tw = new StreamWriter(@"c:\temp\mcWindowsService.txt", true);
                tw.WriteLine(serverMSG);
                tw.WriteLine("Parsing with" + configFile);
                Parser.ParseMessage(clientMessage, configFile);
                tw.WriteLine("Parse Successful");
                tw.WriteLine(configFile);
                tw.Close();
           
                
                
            }

            tcpClient.Close();
        }
    }
}
