using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StronglyTypedLogging.ExampleOne;
using StronglyTypedLogging.ExampleThree;
using StronglyTypedLogging.ExampleTwo;
using System;

namespace StronglyTypedLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IServiceOne, ServiceOne>()
                .AddTransient<IServiceTwo, ServiceTwo>()
                .AddTransient<IServiceThree, ServiceThree>()
                .AddTransient<IServiceThreeLogger, ServiceThreeLogger>()
                .AddLogging()
                .Configure<LoggerFilterOptions>(options =>
                {
                    options.MinLevel = LogLevel.Debug;
                });

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(minLevel: LogLevel.Debug);

                serviceProvider
                    .GetService<IServiceOne>()
                    .RotatePart("111");

                serviceProvider
                    .GetService<IServiceTwo>()
                    .RotatePart("222");

                serviceProvider
                    .GetService<IServiceThree>()
                    .RotatePart("333");
            }

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}
