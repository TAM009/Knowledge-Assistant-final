using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Configuration;

namespace BACKEND
{

    public class Program
    {
        
        public static void Main(string[] args)
        {
            AppConfig appconfigs=new AppConfig();
            string useurl;
            useurl=appconfigs.useurl;
            BuildWebHost(args,useurl).Run();
        }

        public static IWebHost BuildWebHost(string[] args,string url) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(url)
                .Build();
    }



// public class Program
//    {
//        public static void Main(string[] args)
//        {

//            BuildWebHost(args).Run();

//        }

//        public static IWebHost BuildWebHost(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                 .UseUrls("http://localhost:5007")
//                .Build();

//    }
}