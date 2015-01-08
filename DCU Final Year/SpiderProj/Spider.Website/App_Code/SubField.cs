using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubField
/// </summary>
public class SubField
{
    List<SubSubField> _SubSubFieldMembers = new List<SubSubField>();
    public SubField()
    {
        
    }
    public List<SubSubField> SubSubFieldMembers 
    {
        get { return _SubSubFieldMembers;}
       
    }
    public string Name{get;set;}
}
