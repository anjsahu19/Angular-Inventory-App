using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Topshelf;

namespace InventoryApp
{
    public class HostConfig : ServiceControl
    {
        private IDisposable _webApplication;

        public bool Start(HostControl hostControl)
        {
            Trace.WriteLine("Starting the service");
            _webApplication = WebApp.Start<Startup>("http://localhost:8089");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _webApplication.Dispose();
            return true;
        }
    }
}