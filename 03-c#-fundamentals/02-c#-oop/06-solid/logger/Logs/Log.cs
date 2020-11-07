namespace logger.Logs
{
    using System;
    using logger.Enumerations;

    public class Log : ILog
    {
        public Log(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ReportLevel ReportLevel { get; }

        public string Message { get; }
    }
}