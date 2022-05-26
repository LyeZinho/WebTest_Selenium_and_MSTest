using System;
using System.Collections.Generic;
using System.Text;
using WebTest;
using System.Text.Json;
using System.IO;

namespace WebTest
{
    public class Log
    {
        public string Message { get; set; }
        public readonly string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    public class txtLogWriter : ILogMethod
    {
        /*
        Write logs in json format
        For all List<log>
        create one txt file and 
        append all logs inside te file
        creating a new line for each log
        if not exists create new folder with name 
        "logs" and create a new file with name 
        "log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"
        */
        private string _logFilePath = Environment.CurrentDirectory;
        public string _logFileName = "log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

        public void SaveLog(List<Log> logs)
        {
            //Save in txt
            //Create new folder with name logs if not exists
            //Using streams System.IO

            if (!Directory.Exists(_logFilePath + "\\logs"))
            {
                Directory.CreateDirectory(_logFilePath + "\\logs");
            }
            //Create new file with name log_yyyy_MM_dd__hh_mm.txt
            using (StreamWriter file = File.AppendText(_logFilePath + "\\logs\\" + _logFileName))
            {
                foreach (Log log in logs)
                {
                    string msg = $"log: {log.Message} at {log.Time}";
                    file.WriteLine(JsonSerializer.Serialize(msg));
                }
            }
        }
    }
    public class Logger
    {
        //Singleton + Dependency Injection + Builder
        private ILogMethod _logMethod;
        private static Logger _instance;
        private List<Log> _logs = new List<Log>();

        private Logger()
        {
        }

        public void RegisterLog(Log newLog)
        {
            _logs.Add(newLog);
        }

        public void WriteLog()
        {
            _logMethod.SaveLog(_logs);
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public Logger setLogWriter(ILogMethod logMethod)
        {
            _logMethod = logMethod;
            return this;
        }
    }
}
