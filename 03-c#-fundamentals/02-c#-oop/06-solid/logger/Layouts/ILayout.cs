namespace logger.Layouts
{
    using logger.Logs;

    public interface ILayout
    {
        string Format(ILog log);
    }
}