using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Serilog;
using Serilog.Sinks.Slack;
using System.Web;
using WebAppWithLogging.Logging;

namespace WebAppWithLogging
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private static ILogger _logger;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var webhookUrl = "https://hooks.slack.com/services/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";
            //var logFile = HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            //_logger = new LoggerConfiguration()
            //    //.WriteTo.Slack(webhookUrl)
            //    .WriteTo.File(logFile)
            //    .CreateLogger();
            //Serilog.Log.Logger = _logger;

            var logFile = HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            var fileLogger = new LoggerConfiguration()
                .WriteTo.File(logFile)
                .CreateLogger();
            Logger.RegisterLogger(fileLogger);

            var webhookUrl = "https://hooks.slack.com/services/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";
            var slackLogger = new LoggerConfiguration()
                .WriteTo.Slack(webhookUrl)
                .CreateLogger();
            Logger.RegisterCriticalLogger(slackLogger);
        }
    }
}
