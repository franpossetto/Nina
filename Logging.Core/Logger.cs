using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Core
{
    public static class Logger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Logger()
        {
            _perfLogger = new LoggerConfiguration()
                .WriteTo.File(path: @"C:\Logs\Logs\perf.txt")
                .CreateLogger();
            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: @"C:\Logs\Logs\usage.txt")
                .CreateLogger();
            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(path: @"C:\Logs\Logs\error.txt")
                .CreateLogger();
            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: @"C:\Logs\Logs\diagnostic.txt")
                .CreateLogger();
        }

        public static void WritePerf(LogDetail infoToLog)
        {
            _perfLogger.Write(Serilog.Events.LogEventLevel.Information, "{@LogDetail}", infoToLog);
        }
        public static void WriteUsage(LogDetail infoToLog)
        {
            _usageLogger.Write(Serilog.Events.LogEventLevel.Information, "{@LogDetail}", infoToLog);
        }
        public static void WriteError(LogDetail infoToLog)
        {
            _errorLogger.Write(Serilog.Events.LogEventLevel.Information, "{@LogDetail}", infoToLog);
        }
        public static void WriteDiagnostic(LogDetail infoToLog)
        {
            var writeDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
            if (!writeDiagnostics)
                return;

            _diagnosticLogger.Write(Serilog.Events.LogEventLevel.Information, "{@LogDetail}", infoToLog);
        }
    }
}
