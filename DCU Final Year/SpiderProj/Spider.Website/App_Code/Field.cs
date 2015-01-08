using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Field
/// </summary>
public class Field
{
    List<SubField> _SubFieldMembers = new List<SubField>();
    public Field()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<SubField> SubFieldMembers 
    { 
        get { return _SubFieldMembers;} 
    }
    public string Name;
}
