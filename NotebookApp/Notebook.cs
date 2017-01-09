using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp {
    class Notebook {

        public const string IntroMessage = "Welcome to the Notebook program v1";
        public const string OutroMessage = "Thanks for using Notebook program v1";

        readonly List<IPageable> pages = new List<IPageable>();

        public delegate void SimpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);
        public event SimpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        public event BooleanFunction loggingToggled;

        private readonly Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();
        public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

        public SimpleFunction this[string command] {
            get { return commandLineArgs[command]; }
        }

        public Notebook() {
            commandLineArgs.Add(show, Show);
            commandLineArgs.Add(_new, New);
            commandLineArgs.Add(delete, Delete);
            commandLineArgs.Add(log, Log);
        }

        /// <summary>
        /// Creates a new notebook with input keywords for commands instead of default ones
        /// </summary>
        /// <param name="commandLineKeywords">index 0 = show, 1 = new, 2 = delete</param>
        public Notebook(params string[] commandLineKeywords) : this () {
            for (var i = 0; i < commandLineKeywords.Length; ++i) {
                if (commandLineKeywords[i] == "") {
                    continue;
                }

                switch (i) {
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeywords[i], Show);
                        break;
                    case 1:
                        commandLineArgs.Remove(_new);
                        commandLineArgs.Add(_new = commandLineKeywords[i], New);
                        break;
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                        break;
                }
            }
        }

        private void Show(string command) {
            switch (command) {
                case "":
                    Console.WriteLine("\nShow commands:");
                    Console.WriteLine("pages        show all pages");
                    Console.WriteLine("id of page   show that page\n");
                    break;

                case "pages":
                    Console.WriteLine("/--------------------- Pages ---------------------\\");
                    for (var i = 0; i < pages.Count; i++)
                        Console.WriteLine("ID: " + i + " " + pages[i].MyData.title);
                    break;

                default:
                    int number;

                    if (int.TryParse(command, out number)) {

                        if (number < pages.Count)
                            pages[number].Output();
                        else InputBadCommand?.Invoke
                                ("Your number was outside of the available range");
                    }
                    else InputBadCommand?.Invoke
                            ("You didn't enter pages or a valid number");
                    break;
            }
        }

        private void New(string command) {

            switch (command) {
                case "":
                    Console.WriteLine("\nNew commands:");
                    Console.WriteLine("message      create new message page");
                    Console.WriteLine("list         create new list page");
                    Console.WriteLine("image        create new image page\n");
                    break;

                case "message":
                    pages.Add(new TextualMessage().Input());
                    ItemAdded?.Invoke("Textual Message");
                    break;

                case "list":
                    pages.Add(new MessageList().Input());
                    ItemAdded?.Invoke("List");
                    break;

                case "image":
                    pages.Add(new Image().Input());
                    ItemAdded?.Invoke("Image");
                    break;

                default:
                    InputBadCommand?.Invoke("You didn't enter message, list or image");
                    break;
            }
        }

        private void Delete(string command) {
            switch (command) {
                case "":
                    Console.WriteLine("\nDelete commands:");
                    Console.WriteLine("all              delete all created pages");
                    Console.WriteLine("id of page       delete that page\n");
                    break;

                case "all":
                    pages.Clear();
                    ItemRemoved?.Invoke("");
                    break;

                default:
                    int number;

                    if (int.TryParse(command, out number)) {
                        if (number < pages.Count) {
                            pages.RemoveAt(number);
                            ItemRemoved?.Invoke(number + "Number");
                        }
                        else InputBadCommand?.Invoke("Your number was outside of the range of pages");
                    }
                    else InputBadCommand?.Invoke("You didn't input all, or your number was outside the range of pages");
                    break;
            }
        }

        private void Log(string command) {
            switch (command) {
                case "":
                    Console.WriteLine("Logger commands:");
                    Console.WriteLine("on           turn logger on");
                    Console.WriteLine("off          turn logger off");
                    break;

                case "on":
                    loggingToggled?.Invoke(true);
                    break;

                case "off":
                    loggingToggled?.Invoke(false);
                    break;

                default:
                    InputBadCommand?.Invoke("Please enter on or off after inputting the log command");
                    break;
            }
        }
    }
}
