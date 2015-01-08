using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Segment
/// </summary>
public class Segment
{
    List<Field> _FieldMembers = new List<Field>();
    public Segment()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Segment(string value)
    {
        this.Value = value;
    }
    public List<Field> FieldMembers 
    {
        get { return _FieldMembers;}
         
    }
    public string Name { get; set; }
    public string Value { get; set; }
}
