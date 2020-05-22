namespace logger.Appenders
{
    using logger.Enumerations;
    using logger.Layouts;
    using logger.Logs;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(ILog log);
    }
}