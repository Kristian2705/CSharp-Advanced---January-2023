using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] info = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = $"{info[0]}Command";
            Type type = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == command);
            ICommand commandToExecute = Activator.CreateInstance(type) as ICommand;
            string result = commandToExecute.Execute(info.Skip(1).ToArray());
            return result;
        }
    }
}
