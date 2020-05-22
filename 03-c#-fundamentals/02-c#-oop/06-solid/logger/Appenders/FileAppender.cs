namespace logger.Appenders
{
    using logger.Files;
    using logger.Layouts;
    using logger.Logs;

    public class FileAppender : Appender, IAppender
    {
        public FileAppender(ILayout layout) : this(layout, new LogFile()) { }

        public FileAppender(ILayout layout, ILogFile file) : base(layout)
        {
            this.File = file;
        }

        public ILogFile File { get; set; }

        public override void Append(ILog log)
        {
            //FIXME: DRY
            if (log.ReportLevel < this.ReportLevel)
            {
                return;
            }

            this.File.Write(this.Layout.Format(log));
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.File.Size}";
        }
    }
}