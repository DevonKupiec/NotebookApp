using System;

namespace NotebookApp
{
    internal class NotebookLogger
    {
        private bool logging = true;

        private readonly Notebook trackedNotebook;

        public NotebookLogger(Notebook trackedNotebook)
        {
            this.trackedNotebook = trackedNotebook;

            Attach();
            trackedNotebook.loggingToggled += ToggleLogging;
        }

        public void PrintAdded(string typeItemAdded)
        {
            Console.WriteLine(typeItemAdded + " was added to the notebook.");
        }

        public void PrintDeleted(string idOfDeleted)
        {
            if (idOfDeleted != "")
                Console.WriteLine("Item " + idOfDeleted + " was deleted.");
            else
                Console.WriteLine("Everything was deleted.");
        }

        private static void IncorrectCommand(string messageToPrint)
        {
            Console.WriteLine("Bad Command: " + messageToPrint);
        }

        public void ToggleLogging(bool turnOn)
        {
            var output = "Logger already " + (turnOn ? "on" : "off") + ".";

            if (logging)
            {
                if (!turnOn)
                {
                    Detatch();
                    logging = false;
                    output = "Logger turned off.";
                }
            }

            else
            {
                if (turnOn)
                {
                    Attach();
                    logging = true;
                    output = "Logger turned on";
                }
            }
            Console.WriteLine(output);
        }

        private void Attach()
        {
            trackedNotebook.ItemAdded += PrintAdded;
            trackedNotebook.ItemRemoved += PrintDeleted;
            trackedNotebook.InputBadCommand += IncorrectCommand;
        }

        private void Detatch()
        {
            trackedNotebook.ItemAdded -= PrintAdded;
            trackedNotebook.ItemRemoved -= PrintDeleted;
            trackedNotebook.InputBadCommand -= IncorrectCommand;
        }
    }
}