﻿using System.Text;

public abstract class ARootCommand : ACliCommand
{
    public override string Name { get; set; } = "Root Command";
    public override string Description { get; set; } = "lists of available commands";

    public override string DoCommand(string[] args)
    {
        if(args == null || args.Length == 0)
            return string.Empty;

        if (args[0] == "help")
        {
            StringBuilder sb = new StringBuilder();

            PrintHelp(this, 0, sb);
            
            void PrintHelp(ACliCommand command, int depth, StringBuilder sb)
            {
                for (int i = 0; i < depth; i++)
                    sb.Append('-');
                sb.Append($" {command.Name}: {command.Description}\n");

                if (command.Subcommands != null)
                {
                    foreach (ACliCommand subcommand in command.Subcommands)
                        PrintHelp(subcommand, depth+1, sb);
                }
            }

            return sb.ToString();
        }

        return string.Empty;
    }
}