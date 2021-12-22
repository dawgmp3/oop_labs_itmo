using BackupsExtra.Services;
using log4net;
using log4net.Config;
using Serilog;

namespace TestLog
{
    public class LoggingFile : ILogging
    {
        public void Logging(string information)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Information.json")
                .CreateLogger();
            Log.Logger.Information(information);
        }
    }
}