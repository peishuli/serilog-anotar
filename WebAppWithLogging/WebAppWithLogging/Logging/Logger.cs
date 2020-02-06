

using System.Collections.Generic;
using System.Web.Security;
using Serilog;

namespace WebAppWithLogging.Logging
{
    public static class Logger
    {
        private static IList<ILogger> _loggers;
        private static IList<ILogger> _criticalLoggers;
        
        static Logger()
        {
            _loggers = new List<ILogger>();
            _criticalLoggers = new List<ILogger>();
        }

        public static void RegisterLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }

        public static void RegisterCriticalLogger(ILogger logger)
        {
            _criticalLoggers.Add(logger);
        }

        public static void Info(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Information(message);
            }
        }

        public static void Fatal(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Fatal(message);
            }

            foreach (var logger in _criticalLoggers)
            {
                logger.Fatal(message);
            }
        }


    }

}