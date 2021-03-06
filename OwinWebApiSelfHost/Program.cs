﻿using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinWebApiSelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:9667/";

            using (WebApp.Start(uri, Startup.Configuration))
            {
                Console.WriteLine("Started listening on " + uri);
                Console.ReadLine();
                Console.WriteLine("Shutting down...");
            }
        }
    }
}
