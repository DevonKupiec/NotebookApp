using System;

namespace NotebookApp
{
    internal class TextualMessage : IPageable
    {
        protected string message;
        protected PageData myData;

        public virtual IPageable Input()
        {
            Console.WriteLine("Please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title");
            myData.title = Console.ReadLine();
            Console.WriteLine("Please input the message");
            message = Console.ReadLine();

            return this;
        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("/-------------------- Message --------------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: " + myData.author);
            Console.WriteLine(" Message: \n\t" + message);
            Console.WriteLine("\\------------------------------------------------/");
        }

        public PageData MyData
        {
            get { return myData; }
            set { myData = value; }
        }
    }
}