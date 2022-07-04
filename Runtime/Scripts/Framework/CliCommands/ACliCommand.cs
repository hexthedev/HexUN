using System;
using HexCS.Core;

public abstract class ACliCommand
{
    public abstract string Name { get; set; }
    public abstract string Description { get; set; }
    public abstract ACliCommand[] Subcommands { get; set; }

    public void Parse(string[] command)
    {
        if (command == null || command.Length == 0)
        {
            DoCommand(Array.Empty<string>());
            return;
        }

        int subIndex = Subcommands.QueryIndexOf(c => c.Name == command[0]);

        if (subIndex != -1)
            Subcommands[subIndex].Parse(command[1..]);
        else
            DoCommand(command);
    }

    public abstract void DoCommand(string[] args);
}