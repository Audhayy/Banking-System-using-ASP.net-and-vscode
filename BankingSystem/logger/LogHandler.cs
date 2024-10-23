using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.logger
{
    public class LogHandler
    {
        private readonly string logFilePath;

        public LogHandler()
        {
            logFilePath = @"C:\Audhithiyah\Banking-System-using-ASP.net-and-vscode\BankingSystem\logger\log.txt";

            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
        }

        public void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public void LogError(string message)
        {
            Log("ERROR", message);
        }

        private void Log(string level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

            Console.WriteLine(logMessage);

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
