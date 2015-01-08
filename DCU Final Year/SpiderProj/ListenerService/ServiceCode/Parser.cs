using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace ListenerService.ServiceCode
{
    public class Parser
    {
        /// <summary>
        /// Parser The Message
        /// </summary>
        /// <param name="ClientMessage">HL7 Message</param>
        /// <param name="ConfigFile"> Path the ConfigFile</param>
        public static void ParseMessage(string ClientMessage, string ConfigFile)
        {
            
            string clientMessageXMLLocation = TransformMessage.ProcessClientMessage(ClientMessage);
            TextWriter output = new StreamWriter(@"C:\Users\Ter\Desktop\4th year\project\SpiderProj\ListenerService\temp\results.txt");
            XmlTextReader reader = new XmlTextReader(ConfigFile);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        switch (reader.Name)
                        {
                            case "segment":
                                string segid = reader.GetAttribute(1);
                                string segval = reader.GetAttribute(0);
                                XmlTextReader SegReaderClient = new XmlTextReader(clientMessageXMLLocation);
                                while (SegReaderClient.Read())
                                {
                                    switch (SegReaderClient.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            switch (SegReaderClient.Name)
                                            {
                                                case "segment":
                                                    if (segid.Equals(SegReaderClient.GetAttribute(1)))
                                                    {
                                                        string readerclientID = SegReaderClient.GetAttribute(1);
                                                        string clival = SegReaderClient.GetAttribute(0);
                                                        output.WriteLine(segval+"="+clival);
                                                        //added
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                }


                                break;
                            case "field":
                                string fieldid = reader.GetAttribute(1);
                                string fieldval = reader.GetAttribute(0);
                                XmlTextReader fieldReaderClient = new XmlTextReader(clientMessageXMLLocation);
                                while (fieldReaderClient.Read())
                                {
                                    switch (fieldReaderClient.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            switch (fieldReaderClient.Name)
                                            {
                                                case "field":
                                                    if (fieldid.Equals(fieldReaderClient.GetAttribute(1)))
                                                    {
                                                        string readerclientID = fieldReaderClient.GetAttribute(1);
                                                        string clival = fieldReaderClient.GetAttribute(0);
                                                        output.WriteLine(fieldval + "=" + clival);
                                                        //added
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "subfield":

                                string subfieldID = reader.GetAttribute(1);
                                string subfieldVal = reader.GetAttribute(0);
                                XmlTextReader subfieldReaderClient = new XmlTextReader(clientMessageXMLLocation);
                                while (subfieldReaderClient.Read())
                                {
                                    switch (subfieldReaderClient.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            switch (subfieldReaderClient.Name)
                                            {
                                                case "subfield":
                                                    if (subfieldID.Equals(subfieldReaderClient.GetAttribute(1)))
                                                    {
                                                        string readerclientID = subfieldReaderClient.GetAttribute(1);
                                                        string clival = subfieldReaderClient.GetAttribute(0);
                                                        output.WriteLine(subfieldVal + "=" + clival);
                                                        //added
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "subsubfield":
                                string subsubfieldID = reader.GetAttribute(1);
                                string subsubfieldVal = reader.GetAttribute(0);
                                XmlTextReader subsubfieldReaderClient = new XmlTextReader(clientMessageXMLLocation);
                                while (subsubfieldReaderClient.Read())
                                {
                                    switch (subsubfieldReaderClient.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            switch (subsubfieldReaderClient.Name)
                                            {
                                                case "subsubfield":
                                                    if (subsubfieldID.Equals(subsubfieldReaderClient.GetAttribute(1)))
                                                    {
                                                        string readerclientID = subsubfieldReaderClient.GetAttribute(1);
                                                        string clival = subsubfieldReaderClient.GetAttribute(0);
                                                        output.WriteLine(subsubfieldVal + "=" + clival);
                                                        //added
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        break;

                }

            }
            output.Close();
            
        }

        private static void TranverseXML(XmlTextReader XMLClientFileReader, XmlTextReader XMLConfigFileReader)
        {
            
        }
    }
}
