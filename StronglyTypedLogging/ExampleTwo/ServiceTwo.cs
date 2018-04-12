using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace StronglyTypedLogging.ExampleTwo
{
    public class ServiceTwo : IServiceTwo
    {
        private ILogger<ServiceTwo> Logger { get; }

        public ServiceTwo(ILogger<ServiceTwo> logger)
        {
            Logger = logger;
        }

        public void RotatePart(string partName)
        {
            Logger.LogDebug("Random log line");

            Logger.RotatePart(partName);
        }
    }
}
