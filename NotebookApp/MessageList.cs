using System;

namespace NotebookApp
{
    internal class MessageList : TextualMessage
    {
        private BulletType bulletType;

        public override IPageable Input()
        {
            Console.WriteLine("Please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title");
            myData.title = Console.ReadLine();
            Console.WriteLine("What type of bullet point would you like to use?");
            Console.WriteLine("Please enter dash, numbered or star");

            var goodInput = false;
            while (!goodInput)
            {
                goodInput = true;
                switch (Console.ReadLine())
                {
                    case "dashed":
                        bulletType = BulletType.Dashed;
                        break;
                    case "numbered":
                        bulletType = BulletType.Numbered;
                        break;
                    case "star":
                        bulletType = BulletType.Star;
                        break;
                    default:
                        Console.WriteLine("Please enter dashed, numbered or star");
                        goodInput = false;
                        break;
                }
            }

            Console.WriteLine("Start typing your list. Every time you press enter a new item will be created");
            Console.WriteLine("Press enter with a blank list item to end your list");

            var finishedList = false;
            var i = 1;
            while (!finishedList)
            {
                var input = Console.ReadLine();

                if (input == "")
                    finishedList = true;
                else
                    switch (bulletType)
                    {
                        case BulletType.Dashed:
                            message += "- " + input + " \n";
                            break;

                        case BulletType.Numbered:
                            message += i + ". " + input + " \n";
                            i++;
                            break;

                        case BulletType.Star:
                            message += "* " + input + " \n";
                            break;

                        default:
                            break;
                    }
            }

            return this;
        }

        private enum BulletType
        {
            Dashed,
            Numbered,
            Star
        }
    }
}