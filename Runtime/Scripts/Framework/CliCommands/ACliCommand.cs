using System;
using HexCS.Core;

namespace Hex.UN.Runtime.Framework.CliCommands
{
    public abstract class ACliCommand
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract ACliCommand[] Subcommands { get; set; }

        public string Parse(string[] command)
        {
            if (command == null || command.Length == 0)
                return DoCommand(Array.Empty<string>());

            int subIndex = Subcommands.QueryIndexOf(c => c.Name == command[0]);

            if (subIndex != -1)
                return Subcommands[subIndex].Parse(command[1..]);
            else
                return DoCommand(command);
        }

        public virtual string DoCommand(string[] args)
        {
            return string.Empty;
        }

        public void AddCommand(ACliCommand command)
        {
            if (Subcommands != null)
                Subcommands = Subcommands.Add(command);
            else
                Subcommands = new[] {command};
        } 
    }
}
