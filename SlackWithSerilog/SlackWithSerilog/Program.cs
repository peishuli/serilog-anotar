using System;
using System.Linq;
using Serilog;
using Serilog.Events;

namespace SlackWithSerilog
{
    class Program
    {

        static void Main(string[] args)
        {
            var webhookUrl = "https://hooks.slack.com/services/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";
            var splunkUrl = "http://localhost:8088/services/collector";
            var splunkEventCollectorToken = "A2E40E9B-74B2-49F3-989D-3573F9438F2C";
            using (var logger = new LoggerConfiguration()
                //.WriteTo.Slack(webhookUrl)Install-Package Serilog.Sinks.Splunk -Version 1.7.61
                //.WriteTo.File("Log.txt")
                .WriteTo.EventCollector(splunkUrl, splunkEventCollectorToken)
                .CreateLogger())
            {
                logger.Information("this is an information level message");
                logger.Fatal("This is an fatal message!");
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
