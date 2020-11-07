namespace logger.Logs
{
    using System;
    using logger.Enumerations;

    public interface ILog
    {
        DateTime DateTime { get; }

        ReportLevel ReportLevel { get; }

        string Message { get; }
    }
}