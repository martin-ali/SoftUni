namespace logger.Layouts
{
    using logger.Logs;

    public class SimpleLayout : Layout, ILayout
    {
        public SimpleLayout(string dateTimeFormat) : base(dateTimeFormat) { }

        public override string Format(ILog log)
        {
            var dateTime = log.DateTime.ToString(this.dateTimeFormat);

            return $"{dateTime} - {log.ReportLevel} - {log.Message}";
        }
    }
}