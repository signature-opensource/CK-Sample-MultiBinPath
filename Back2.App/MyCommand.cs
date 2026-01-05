using CK.Auth;
using CK.Core;
using CK.Cris;
using System.ComponentModel;

namespace Back2.App;

public interface IMyCommand : ICommandAuthDeviceId, ICommandAuthNormal
{
    [DefaultValue("Hello World!")]
    string Message { get; set; }
}

public sealed class MyCommandHandler : ISingletonAutoService 
{
    [CommandHandler]
    public void Handle( IActivityMonitor monitor, IMyCommand command )
    {
        monitor.Info( $"MyCommand.Message = '{command.Message}'" );
    }
}
