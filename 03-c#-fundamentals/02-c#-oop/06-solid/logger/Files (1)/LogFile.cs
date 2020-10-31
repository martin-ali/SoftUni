namespace logger.Files
{
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogFile : ILogFile
    {
        private string path;

        private string name;

        private string pathWithName;

        private StringBuilder text;

        public LogFile(string name = "log.txt", string path = "")
        {
            this.name = name;
            this.path = path;
            this.pathWithName = Path.Combine(path, name);
            this.text = new StringBuilder();
        }

        public int Size
        {
            get
            {
                return this.text.ToString().Sum(c => char.IsLetter(c) ? c : 0);
            }
        }

        public void Write(string message)
        {
            this.text.AppendLine(message);
            // FIXME: Overwrite the whole file every time?
            File.WriteAllText(this.pathWithName, this.text.ToString());
        }
    }
}