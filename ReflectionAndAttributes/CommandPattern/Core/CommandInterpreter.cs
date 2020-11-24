using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CommandPattern.Core.Commands;
using System.Reflection;

namespace CommandPattern.Core
{
   public class CommandInterpreter:ICommandInterpreter
    {
        public string Read (string input) 
        {
            string[] commandtokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = commandtokens[0].ToLower();
            string [] commandArgs = commandtokens.Skip(1)
                                                 .ToArray();

            string result = string.Empty;
           

           Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x=>x.Name.ToLower() == $"{commandType}Command".ToLower());

            ICommand instance = (ICommand)Activator.CreateInstance(type);
           
            result = instance.Execute(commandArgs);
            return result;
        
        }

        
    }
}
