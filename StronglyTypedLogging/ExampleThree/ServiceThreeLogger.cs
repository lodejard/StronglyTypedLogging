using Microsoft.Extensions.Logging;
using System;

namespace StronglyTypedLogging.ExampleThree
{

    public class ServiceThreeLogger : IServiceThreeLogger
    {
        private static readonly Action<ILogger, string, Exception> rotatePartMessage = LoggerMessage.Define<string>(
            LogLevel.Information, new EventId(1, "RotatePart"), "Rotating part {PartName}");

        private readonly ILogger logger;

        public ServiceThreeLogger(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("StronglyTypedLogging.ExampleThree.ServiceThree");
        }

        IDisposable ILogger.BeginScope<TState>(TState state) => logger.BeginScope(state);
        bool ILogger.IsEnabled(LogLevel logLevel) => logger.IsEnabled(logLevel);
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) => logger.Log(logLevel, eventId, state, exception, formatter);

        public void RotatePart(string partName) => rotatePartMessage(logger, partName, null);
    }
}
