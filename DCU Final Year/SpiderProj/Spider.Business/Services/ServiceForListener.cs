using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Spider.Database;
using Spider.Business;

public class ServiceForListener
{
    public static DataTable GetStreamsForService(string ConnectionString)
    {
        return DBListenerService.GetStreams(ConnectionString);
    }
}

