namespace logger.Appenders
{
    using System;
    using logger.Layouts;
    using logger.Logs;

    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout) : base(layout) { }

        public override void Append(ILog log)
        {
            //FIXME: DRY
            if (log.ReportLevel < this.ReportLevel)
            {
                return;
            }

            Console.WriteLine(this.Layout.Format(log));
            this.messagesAppended++;
        }
    }
}