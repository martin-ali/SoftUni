namespace logger.Layouts
{
    using System.Text;
    using logger.Logs;

    public class XmlLayout : Layout, ILayout
    {
        // It says 1 tabulation in the instructions, yet is 3 spaces in the examples. TODO: Decide which option to use
        private const int DefaultIndentationLevel = 3;

        public XmlLayout(string dateTimeFormat) : base(dateTimeFormat) { }

        public override string Format(ILog log)
        {
            return this.Format(log, DefaultIndentationLevel);
        }

        public string Format(ILog log, int indentLevel)
        {
            string indentation = new string(' ', indentLevel);
            var dateTime = log.DateTime.ToString(this.dateTimeFormat);

            var builder = new StringBuilder();
            builder.AppendLine("<log>");
            builder.AppendLine($"{indentation}<date>{dateTime}</date> ");
            builder.AppendLine($"{indentation}<level>{log.ReportLevel}</level> ");
            builder.AppendLine($"{indentation}<message>{log.Message}</message> ");
            builder.Append("</log>");

            return builder.ToString();
        }
    }
}