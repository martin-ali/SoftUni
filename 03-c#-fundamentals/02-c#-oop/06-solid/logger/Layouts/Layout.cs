namespace logger.Layouts
{
    using logger.Logs;

    public abstract class Layout : ILayout
    {
        protected string dateTimeFormat;

        public Layout(string dateTimeFormat)
        {
            this.dateTimeFormat = dateTimeFormat;
        }

        public abstract string Format(ILog log);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}