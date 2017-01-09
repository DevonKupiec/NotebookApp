using System;
using System.Collections.Generic;

namespace NotebookApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Notebook notebook = new Notebook("see", "create", "remove");
            var notebook = new Notebook();
            var notebookLogger = new NotebookLogger(notebook);

            const string ExitProgramKeyword = "exit";
            var commandPrompt = "\nPlease enter " + notebook.show + ", "
                                + notebook.delete + ", " + notebook._new
                                + " or " + notebook.log + "\n";

            Console.WriteLine(Notebook.IntroMessage);
            Console.WriteLine(commandPrompt);

            var input = "";
            do
            {
                input = Console.ReadLine() ?? "";
                var commands = input.Split();

                try
                {
                    notebook[commands[0]](commands.Length > 1 ? commands[1] : "");
                }
                catch (KeyNotFoundException)
                {
                    if (input != ExitProgramKeyword)
                        Console.WriteLine(commandPrompt);
                }
                Console.WriteLine();
            } while (input != ExitProgramKeyword);

            Console.WriteLine(Notebook.OutroMessage);
        }
    }
}