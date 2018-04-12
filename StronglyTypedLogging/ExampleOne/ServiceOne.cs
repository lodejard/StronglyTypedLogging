using Microsoft.Extensions.Logging;

namespace StronglyTypedLogging.ExampleOne
{
    public class ServiceOne : IServiceOne
    {
        private ILogger<ServiceOne> Logger { get; }

        public ServiceOne(ILogger<ServiceOne> logger)
        {
            Logger = logger;
        }

        public void RotatePart(string partName)
        {
            Logger.LogDebug("Random log line");

            Logger.LogInformation(
                new EventId(1, "RotatePart"), 
                "Rotating part {PartName}", partName);
        }
    }
}
