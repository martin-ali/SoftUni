namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Postfix = "Command";

        public string Read(string args)
        {
            var data = args.Split(' ');
            var commandName = $"{data[0]}{Postfix}";

            var commandType = Assembly.GetCallingAssembly().GetTypes()
                                .FirstOrDefault(t => t.Name == commandName);
            var command = (ICommand)Activator.CreateInstance(commandType);
            var result = command.Execute(data.Skip(1).ToArray());

            return result;
        }
    }
}