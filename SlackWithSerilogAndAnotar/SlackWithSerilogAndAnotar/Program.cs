using System;
using Anotar.Serilog;
using Serilog;

namespace SlackWithSerilogAndAnotar
{
    class Program
    {
        private static ILogger _logger;
        //REF: https://github.com/Fody/Anotar/issues/10
        
        static void Main(string[] args)
        {
            var webhookUrl = "https://hooks.slack.com/services/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";
            var logFile = "Log.txt";
            var rollingFile = "rollinglog.txt";
            var splunkUrl = "https://localhost:8088/services/collector";
            var splunkEventCollectorToken = "A2E40E9B-74B2-49F3-989D-3573F9438F2C";
            _logger = new LoggerConfiguration()
                //.WriteTo.Slack(webhookUrl) // log to slack
                //.WriteTo.File(logFile) // log to a file
                .WriteTo.RollingFile(rollingFile) // log to a rolling file
                //.WriteTo.EventCollector(splunkUrl, splunkEventCollectorToken) // log to splunk
                .CreateLogger();
            Serilog.Log.Logger = _logger;

            LogTo.Information("testing message...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
