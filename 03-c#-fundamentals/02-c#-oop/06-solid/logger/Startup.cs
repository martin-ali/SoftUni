namespace logger
{
    using System;
    using System.IO;

    class Startup
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var interpreter = new CommandInterpreter();
            interpreter.ExecuteConsoleCommands();
        }

    }
}