using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CK.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Front.App
{
    public class Startup
    {
        readonly IConfiguration _configuration;
        readonly IHostingEnvironment _hostingEnvironment;
        readonly IActivityMonitor _startupMonitor;

        public Startup( IConfiguration configuration, IHostingEnvironment env )
        {
            _startupMonitor = new ActivityMonitor( $"App {env.ApplicationName}/{env.EnvironmentName} on {Environment.MachineName}/{Environment.UserName}." );
            _configuration = configuration;
            _hostingEnvironment = env;
        }

        public void ConfigureServices( IServiceCollection services )
        {
            // The entry point assembly contains the generated code.
            services.AddCKDatabase( _startupMonitor, System.Reflection.Assembly.GetEntryAssembly() );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run( async ( context ) =>
             {
                 await context.Response.WriteAsync( "Hello World!" );
             } );
        }
    }
}
