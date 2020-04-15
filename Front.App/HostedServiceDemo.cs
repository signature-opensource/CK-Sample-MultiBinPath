using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CK.Core;

namespace Front.App
{
    /// <summary>
    /// This is a demo hosted service: this is automatically registered as a hosted service and
    /// start/stop methods are called by the host.
    /// Since this is a Singleton service, other participants can perfectly depends on this class (or
    /// a ISingletonAutoService interface may be implemented by this class).
    /// </summary>
    public class HostedServiceDemo : IHostedService, IAutoService
                                     //, ISingletonAutoService
                                     // --> This is useless: Microsoft.Extensions.Hosting.IHostedService is automatically
                                     //     registered as a [IsMultiple] Singleton service.
    {
        public Task StartAsync( CancellationToken cancellationToken )
        {
            HasBeenStarted = true;
            return Task.CompletedTask;
        }

        public Task StopAsync( CancellationToken cancellationToken )
        {
            HasBeenStopped = true;
            return Task.CompletedTask;
        }

        public bool HasBeenStarted { get; private set; }

        public bool HasBeenStopped { get; private set; }

        public bool IsRunning => HasBeenStarted && !HasBeenStopped;

    }
}
