using Microsoft.Extensions.Logging;

namespace StronglyTypedLogging.ExampleThree
{
    public interface IServiceThreeLogger : ILogger<ServiceThree>
    {
        /// <summary>
        /// Rotating part {PartName}
        /// </summary>
        /// <param name="partName">Standard part identifier</param>
        void RotatePart(string partName);
    }
}
