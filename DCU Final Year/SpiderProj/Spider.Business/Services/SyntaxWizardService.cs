using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSpider;
using Spider.Business;


public class BOSyntaxWizard
{
    public static bool AddXMLToDB(string XML, string MessageName)
    {
        return DBSyntaxWizard.AddXMLToDB(XML, MessageName, BOLookup.ConnectionString);
    }
}

