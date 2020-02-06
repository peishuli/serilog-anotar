using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SlackWithSerilogAndAnotar
{
    public static class LoggerConfig
    {
        static LoggerConfig()
        {
            var webhookUrl = "https://hooks.slack.com/services/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";
            var logger = new LoggerConfiguration()
                //.WriteTo.Slack(webhookUrl)
                .WriteTo.File("Log.txt")
                .CreateLogger();
            Serilog.Log.Logger = logger;

        }
    }
}
