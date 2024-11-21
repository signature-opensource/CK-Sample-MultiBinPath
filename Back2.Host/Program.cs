using CK.Core;
using Front.App;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateSlimBuilder();
builder.UseCKMonitoring();
builder.AddWebFrontAuth( options => options.ExpireTimeSpan = TimeSpan.FromDays( 1 ) );
var app = builder.CKBuild( StObjContextRoot.Load( System.Reflection.Assembly.GetExecutingAssembly(), builder.GetBuilderMonitor() ) );

app.Run( async ( context ) =>
{
    bool isRunning = context.RequestServices.GetRequiredService<HostedServiceDemo>().IsRunning;
    await context.Response.WriteAsync( $"Hello World! HostedServiceDemo.IsRunning = {isRunning}." );
} );
