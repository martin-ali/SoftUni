namespace logger.Appenders
{
    using logger.Enumerations;
    using logger.Layouts;
    using logger.Logs;

    public abstract class Appender : IAppender
    {
        private const ReportLevel DefaultReportLevel = ReportLevel.Info;

        // Default value is 0
        protected int messagesAppended;

        protected Appender(ILayout layout) : this(layout, ReportLevel.Info) { }

        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(ILog log);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout}, Report level: {this.ReportLevel}, Messages appended: {this.messagesAppended}";
        }
    }
}