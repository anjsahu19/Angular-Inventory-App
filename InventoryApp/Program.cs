using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Topshelf;

namespace InventoryApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //string baseAddress = "http://localhost:3000/";

            // Start OWIN host 
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    // Create HttpCient and make a request to api/values 
            //    HttpClient client = new HttpClient();

            //    var response = client.GetAsync(baseAddress + "api/Customers").Result;

            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //    Console.ReadLine();
            //}

            var exitCode = HostFactory.Run(x =>
                {
                    x.Service<HostConfig>();
                    x.RunAsLocalSystem();
                    x.SetDescription("Owin + Webapi as Windows service");
                    x.SetDisplayName("Inventory App Service");
                    x.SetServiceName("owin.WebApi.InventoryApp");
                });
            return (int)exitCode;
        }
    }
}