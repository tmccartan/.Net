using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HL7Message
/// </summary>
public class HL7Message
{
    public List<Segment> _SegmentMembers = new List<Segment>();
    public HL7Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<Segment> SegmentMembers 
    {
        get { return _SegmentMembers; }
    }
    public string Name { get; set; }
}
