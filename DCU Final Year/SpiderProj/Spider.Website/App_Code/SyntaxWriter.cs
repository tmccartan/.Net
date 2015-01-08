using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;
using System.Configuration;
using System.IO;
using Spider.Business;

/// <summary>
/// Summary description for SyntaxWriter
/// </summary>
public class SyntaxWriter
{
    private XmlTextWriter XMLWriter;
    private string XMLFilePath;

    public SyntaxWriter()
    {
        
    }
    public static bool ProcessSyntaxFile(string HL7SyntaxString, string MessageTitle)
    {
        try
        {
            bool success = false;
            string[] HL7Splited = SplitSegments(HL7SyntaxString);
            HL7Message Message = new HL7Message();

            foreach (string segment in HL7Splited)
            {
                Segment seg = new Segment();
                if (!segment.Equals(string.Empty))
                {
                    seg.Name = segment.Substring(0, segment.IndexOf('|'));
                    seg = GetFieldsFromSegment(segment, seg);
                    Message.SegmentMembers.Add(seg);
                }
                else
                {
                    //User in advanced mode may of add extra return
                }
            }

            success = WriteXML(Message, MessageTitle);

            return success;
        }
        catch (Exception ex)
        {
            throw;
        }
        


        
    }

    private static bool WriteXML(HL7Message Message, string MessageTitle)
    {
        try
        {

            int counter = 1;
            string path = ConfigurationManager.AppSettings["SpiderBasePath"].ToString()+@"\temp\" ;
            Random rdn = new Random(Directory.GetFiles(path).Length);
            //string filename = rdn.Next() + "_" +
            //                     Directory.GetFiles(path).Length + ".xml";
            string filename = MessageTitle+".xml";
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
            return true;
        }
        catch (Exception ex)
        {
            return false;
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
        try
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
                    field = GetSubFieldsFromField(mtchField.ToString(), field);
                    segment.FieldMembers.Add(field);
                }
            }
            return segment;
        }
        catch (Exception ex)
        {
            throw ex;
        }


        //return fieldMatches;
    }

    private static Field GetSubFieldsFromField(string HL7Field, Field field)
    {
        try
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
        catch (Exception ex)
        {
            throw ex;
        }


    }
    
    private static SubField GetSubSubFieldsFromSubFields(string SubFields, SubField subField)
    {

        try
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
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /*
    private static void GetSubSubFieldsFromSubFieldsExtra(string p, SubField subField)
    {
        throw new NotImplementedException();
    }
     */
}
