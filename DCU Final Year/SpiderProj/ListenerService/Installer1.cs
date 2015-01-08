using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace ListenerService
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            ServiceInstaller si = new ServiceInstaller();
            ServiceProcessInstaller spi = new ServiceProcessInstaller();

            si.ServiceName = "ListenerService"; // this must match the ServiceName specified in WindowsService1.
            si.DisplayName = "Spider Listener Service"; // this will be displayed in the Services Manager.
            this.Installers.Add(si);
            
            
            spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem; // run under the system account.
            spi.Password = null;
            spi.Username = null;
            this.Installers.Add(spi);

        }
    }
}
