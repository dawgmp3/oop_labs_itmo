using System;
using Serilog;

namespace BackupsExtra.Services
{
    public class LoggingConsole : ILogging
    {
        public void Logging(string information)
        {
            Console.WriteLine(information);
        }
    }
}