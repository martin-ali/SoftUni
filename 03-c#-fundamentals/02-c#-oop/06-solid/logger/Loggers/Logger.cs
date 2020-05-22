namespace logger.Loggers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using logger.Appenders;
    using logger.Logs;
    using logger.Common;
    using logger.Enumerations;

    public class Logger : ILogger
    {
        private List<IAppender> appenders = new List<IAppender>();

        private string dateTimeFormat;

        public Logger(params IAppender[] appenders) : this(appenders, Constants.DateTimeFormat) { }

        public Logger(IAppender[] appenders, string dateTimeFormat)
        {
            this.appenders.AddRange(appenders);
            this.dateTimeFormat = dateTimeFormat;
        }

        private void Log(string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                var log = new Log(DateTime.ParseExact(dateTime, this.dateTimeFormat, CultureInfo.InvariantCulture),
                                    reportLevel,
                                    message);
                appender.Append(log);
            }
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.Fatal, message);
        }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Logger info");
            foreach (var appender in this.appenders)
            {
                builder.AppendLine(appender.ToString());
            }

            return builder.ToString();
        }
    }
}