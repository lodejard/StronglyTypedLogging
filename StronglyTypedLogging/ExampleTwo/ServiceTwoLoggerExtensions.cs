using Microsoft.Extensions.Logging;
using System;

namespace StronglyTypedLogging.ExampleTwo
{
    internal static class ServiceTwoLoggerExtensions
    {
        private static readonly Action<ILogger, string, Exception> rotatePartMessage = LoggerMessage.Define<string>(
            LogLevel.Information, new EventId(1, "RotatePart"), "Rotating part {PartName}");

        /// <summary>
        /// Rotating part {PartName}
        /// </summary>
        /// <param name="logger">The component logger</param>
        /// <param name="partName">Standard part identifier</param>
        public static void RotatePart(this ILogger<ServiceTwo> logger, string partName) => rotatePartMessage(logger, partName, null);
    }
}
