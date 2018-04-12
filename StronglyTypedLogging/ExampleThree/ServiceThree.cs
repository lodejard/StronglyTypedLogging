using Microsoft.Extensions.Logging;

namespace StronglyTypedLogging.ExampleThree
{
    public class ServiceThree : IServiceThree
    {
        private IServiceThreeLogger Logger { get; }

        public ServiceThree(IServiceThreeLogger logger)
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
