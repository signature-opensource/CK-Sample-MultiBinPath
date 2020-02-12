using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Front.App;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Front.Web
{
    public class Program
    {
        public static void Main( string[] args )
        {
            // This doesn't use the CreateDefaultBuilder helper.
            // Instead, the configuration here is detailed and explicit.
            // (See the Back.Web program for a default configuration.)
            var host = new HostBuilder()
                .UseContentRoot( Directory.GetCurrentDirectory() )
                .ConfigureHostConfiguration( config =>
                {
                    config.AddEnvironmentVariables( prefix: "DOTNET_" );
                    config.AddCommandLine( args );
                } )
                .ConfigureAppConfiguration( ( hostingContext, config ) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    // First configuration layer is the appsettings.json, followed by the one with the
                    // environment name "" (see the static class Microsoft.Extensions.Hosting.Environments).
                    config.AddJsonFile( "appsettings.json", optional: true, reloadOnChange: true )
                          .AddJsonFile( $"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true );

                    // Configuration coming from the environment variables are considered safer than appsettings configuration.
                    // We add them after the appsettings.
                    config.AddEnvironmentVariables();

                    // Then, in development mode, can come the User Secrets.
                    // To activate it, adds a new UserSecretsId GUID Property to this csproj.
                    //
                    //     <PropertyGroup>
                    //          <UserSecretsId>{generates a new guid or use a shared one between different projects}</ UserSecretsId >
                    //     </PropertyGroup>
                    // 
                    //  if( env.IsDevelopment() )
                    //  {
                    //    config.AddUserSecrets<Program>( optional: true );
                    //  }
                    //

                    // Finally comes the configuration values from the command line: these configurations override
                    // any previous ones.
                    config.AddCommandLine( args );
                } )
                .ConfigureLogging( ( hostingContext, logging ) =>
                {
                    // This is added *before* configuration is loaded: configuration can override this default.
                    // By default, we log everything in Development mode and only Information level otherwise.
                    if( hostingContext.HostingEnvironment.IsDevelopment() )
                    {
                        logging.AddFilter( level => true );
                    }
                    else
                    {
                        logging.AddFilter( level => level >= LogLevel.Information );
                    }
                    // Logging is the default section name to use for .Net logging.
                    logging.AddConfiguration( hostingContext.Configuration.GetSection( "Logging" ) );
                } )
                // This configures the GrandOutput.Default and provides a scoped IActivityMonitor to the DI.
                .UseMonitoring( "Monitoring" )
                // Here comes the Web host configuration.
                .ConfigureWebHostDefaults( webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        // Automatically provides a CK.AspNet.ScopedHttpContext service that enables scoped
                        // services to use the HttpContext.
                        .UseScopedHttpContext();
                } )
                .Build();

            host.Run();
        }

    }
}
