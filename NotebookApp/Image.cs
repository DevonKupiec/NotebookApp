using System;

namespace NotebookApp
{
    internal class Image : IPageable
    {
        private string asciiImage;
        private PageData myData;

        public IPageable Input()
        {
            Console.WriteLine("Please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title");
            myData.title = Console.ReadLine();

            Console.WriteLine("Start inputting your image, Press enter to create as many lines as you like");
            Console.WriteLine("Press Ctrl+D then enter on a single line to stop creating your image");
            var finishedImage = false;
            while (!finishedImage)
            {
                var input = Console.ReadLine() ?? "";
                if ((input.Length > 0) && (input[0] == 4))
                    finishedImage = true;
                else
                    asciiImage += "\t" + input + "\n";
            }
            return this;
        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("/-------------------- Message --------------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: " + myData.author);
            Console.WriteLine();
            Console.WriteLine(asciiImage);
            Console.WriteLine("\\------------------------------------------------/");
        }

        public PageData MyData
        {
            get { return myData; }
            set { myData = value; }
        }
    }
}