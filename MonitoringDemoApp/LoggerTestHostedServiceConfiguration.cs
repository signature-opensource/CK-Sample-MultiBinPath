using System;

namespace MonitoringDemoApp
{
    /// <summary>
    /// Configures the <see cref="LoggerTestHostedService"/>.
    /// </summary>
    public class LoggerTestHostedServiceConfiguration
    {
        /// <summary>
        /// Gets or sets the timer duration.
        /// </summary>
        public TimeSpan TimerDuration { get; set; }


        public override string ToString() => $"Options{{ TimerDuration = {TimerDuration} }}";
    }
}
