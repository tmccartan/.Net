using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;
using System.Configuration;
using System.IO;


/// <summary>
/// Summary description for SyntaxWriter
/// </summary>
public class TransformMessage
{
    private XmlTextWriter XMLWriter;
    private string XMLFilePath;

    public TransformMessage()
    {
        
    }
    /// <summary>
    /// Convert Message to XML
    /// </summary>
    /// <param name="HL7SyntaxString"></param>
    /// <returns>Path of XML File</returns>
    public static string ProcessClientMessage(string HL7SyntaxString)
    {
        try
        {
            
            string[] HL7Splited = SplitSegments(HL7SyntaxString);
            HL7Message Message = new HL7Message();

            foreach (string segment in HL7Splited)
            {
                if(!segment.Equals(string.Empty))
                {

                    Segment seg = new Segment();
                    seg.Name = segment.Substring(0, segment.IndexOf('|'));
                    seg = GetFieldsFromSegment(segment,seg);
                    Message.SegmentMembers.Add(seg);
                }
            }

            return WriteXML(Message);
        }
        catch (Exception ex)
        {
            throw;
        }
        


        
    }

    private static string WriteXML(HL7Message Message)
    {
        try
        {

            int counter = 1;
            string path = @"C:\Users\Ter\Desktop\4th year\project\SpiderProj\ListenerService\temp\";
            Random rdn = new Random(Directory.GetFiles(path).Length);
            string filename = rdn.Next() + "_" +
                                 Directory.GetFiles(path).Length + ".xml";
            //string filename = MessageTitle;
            XmlTextWriter XMLWriter = new XmlTextWriter(path+filename, null);
            
            List<Segment> segs = Message.SegmentMembers;

            XMLWriter.WriteStartElement("type");
            XMLWriter.WriteStartAttribute("name");
            XMLWriter.WriteValue("AO1");
            foreach (Segment s in segs)
            {
                XMLWriter.WriteStartElement("segment");
                XMLWriter.WriteStartAttribute("value");
                XMLWriter.WriteValue(s.Name);
                XMLWriter.WriteStartAttribute("number");
                XMLWriter.WriteValue(counter);
                counter++;
                List<Field> fields = s.FieldMembers;

                foreach (Field fi in fields)
                {
                    XMLWriter.WriteStartElement("field");
                    XMLWriter.WriteStartAttribute("value");
                    XMLWriter.WriteValue(fi.Name);
                    XMLWriter.WriteStartAttribute("number");
                    XMLWriter.WriteValue(counter);
                    counter++;

                    List<SubField> subfields = fi.SubFieldMembers;

                    foreach (SubField sub in subfields)
                    {
                        XMLWriter.WriteStartElement("subfield");
                        XMLWriter.WriteStartAttribute("value");
                        XMLWriter.WriteValue(sub.Name);
                        XMLWriter.WriteStartAttribute("number");
                        XMLWriter.WriteValue(counter);
                        counter++;

                        List<SubSubField> ssf = sub.SubSubFieldMembers;
                        foreach (SubSubField sSubF in ssf)
                        {
                            XMLWriter.WriteStartElement("subsubfield");
                            XMLWriter.WriteStartAttribute("value");
                            XMLWriter.WriteValue(sSubF.Name);
                            XMLWriter.WriteStartAttribute("number");
                            XMLWriter.WriteValue(counter);
                            counter++;
                            XMLWriter.WriteEndElement();
                        }
                        XMLWriter.WriteEndElement();
                    }
                    XMLWriter.WriteEndElement();
                }
                XMLWriter.WriteEndElement();
            }
            XMLWriter.WriteEndElement();

            string DBString = XMLWriter.ToString();
            XMLWriter.Close();
            //BOSyntaxWizard.AddXMLToDB(filename, MessageTitle, ConfigurationManager.ConnectionStrings["SpiderCS"].ToString());
            return path+filename;
        }
        catch (Exception ex)
        {
            return string.Empty;
            throw;
            
        }
    }
    private static string[] SplitSegments(string HL7SyntaxString)
    {
        HL7SyntaxString = HL7SyntaxString.Replace("\r\n","\r");
        char segSeparatorChar = '\r';
        string[] HL7SyntaxStringSplitted = HL7SyntaxString.Split(segSeparatorChar);

        return HL7SyntaxStringSplitted;
    }
    private static Segment GetFieldsFromSegment(string HL7Fields, Segment segment)
    {
        
        Regex Fields = new Regex("\\|([A-Za-z0-9\\-.^/~\\&\\s]*)");
        MatchCollection fieldMatches = Fields.Matches(HL7Fields);
        if (fieldMatches.Count > 0)
        {
            foreach (Match mtchField in fieldMatches)
            {
                Field field = new Field();
                field.Name = mtchField.ToString();
                field.Name = field.Name.Replace("|", "");
                if (field.Name.Contains("^"))
                {
                    field.Name = field.Name.Substring(0, field.Name.IndexOf("^"));
                }
                field = GetSubFieldsFromField(mtchField.ToString(),field);
                segment.FieldMembers.Add(field);
            }
        }
        return segment;

        //return fieldMatches;
    }

    private static Field GetSubFieldsFromField(string HL7Field, Field field)
    {
        
        //field.Name = "Example";

        Regex SubField = new Regex("\\^([A-Za-z0-9-\\./~&\\s]*)");

        MatchCollection fieldMatches = SubField.Matches(HL7Field);
        if (fieldMatches.Count > 0)
        {
            foreach (Match mtchField in fieldMatches)
            {
                SubField subField = new SubField();
                subField.Name = mtchField.ToString();
                subField.Name = subField.Name.Replace("^", "");
                if (subField.Name.Contains("&"))
                {
                    subField.Name = field.Name.Substring(0, field.Name.IndexOf("&"));
                }
                subField = GetSubSubFieldsFromSubFields(mtchField.ToString(), subField);
                field.SubFieldMembers.Add(subField);
            }
        }
        return field;      

    }
    
    private static SubField GetSubSubFieldsFromSubFields(string SubFields, SubField subField)
    {

        
        Regex SubSubFields = new Regex("\\&([A-Za-z0-9\\-.^/~\\&\\s]*)");

        MatchCollection SubSubfieldMatches = SubSubFields.Matches(SubFields);
        if (SubSubfieldMatches.Count > 0)
        {
            foreach (Match mtchField in SubSubfieldMatches)
            {
                SubSubField subsubField = new SubSubField();
                subsubField.Name = mtchField.ToString();
                subsubField.Name = subsubField.Name.Replace("&", "");               
                subField.SubSubFieldMembers.Add(subsubField);
            }
        }
        return subField;
    }
    /*
    private static void GetSubSubFieldsFromSubFieldsExtra(string p, SubField subField)
    {
        throw new NotImplementedException();
    }
     */
}
