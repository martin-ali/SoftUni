namespace logger
{
    using System;
    using System.Linq;
    using System.Reflection;
    using logger.Appenders;
    using logger.Common;
    using logger.Enumerations;
    using logger.Layouts;
    using logger.Loggers;

    public class CommandInterpreter
    {
        private Logger logger;

        public CommandInterpreter() : this(new Logger()) { }

        public CommandInterpreter(Logger logger)
        {
            this.logger = logger;
        }

        // FIXME: Depends on Console. Not SOLID
        public void ExecuteConsoleCommands()
        {
            var appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                this.CreateAppender(Console.ReadLine());
            }

            var input = Console.ReadLine();
            while (input != "END")
            {
                this.AppendLog(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(this.GetLoggerInfo());
        }

        public void CreateAppender(string input)
        {
            var parameters = input.Split(' ');
            var appenderName = parameters[0];
            var layoutName = parameters[1];
            var reportLevel = ReportLevel.Info;

            if (parameters.Length == 3)
            {
                reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), parameters[2]);
            }

            var assembly = Assembly.GetExecutingAssembly();
            var layoutType = assembly.GetTypes().First(t => t.Name == layoutName);
            var layout = (ILayout)Activator.CreateInstance(layoutType, new object[] { Constants.DateTimeFormat });

            var appenderType = assembly.GetTypes().First(t => t.Name == appenderName);
            var appender = (IAppender)Activator.CreateInstance(appenderType, new object[] { layout });
            appender.ReportLevel = reportLevel;

            this.logger.AddAppender(appender);
        }

        public void AppendLog(string input)
        {
            var parameters = input.Split('|');
            var reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), parameters[0]);
            var dateTime = parameters[1];
            var message = parameters[2];

            logger
                .GetType()
                .GetMethod(reportLevel.ToString())
                .Invoke(logger, new object[] { dateTime, message });
        }

        public string GetLoggerInfo()
        {
            return this.logger.ToString();
        }
    }
}