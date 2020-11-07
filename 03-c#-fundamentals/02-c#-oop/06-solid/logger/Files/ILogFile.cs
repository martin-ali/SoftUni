namespace logger.Files
{
    // Could be split into ISized and IWriter
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}