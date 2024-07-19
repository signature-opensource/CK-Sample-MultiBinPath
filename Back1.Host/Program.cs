using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Back.App;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Back.Web
{
    public class Program
    {
        public static void Main( string[] args )
        {
            //// Using the default "black box"...
            //// (See the Front.Web Program.cs for a detailed and explicit configuration.)
            //Host.CreateDefaultBuilder( args )
            //     .UseCKMonitoring()
            //     .ConfigureWebHostDefaults( webBuilder =>
            //     {
            //         webBuilder
            //             .UseKestrel()
            //             .UseScopedHttpContext()
            //             .UseIISIntegration()
            //             .UseStartup<Startup>();
            //     } )
            //    .Build()
            //    .Run();
        }
    }
}
