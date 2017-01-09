using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public interface IPageable
    {
        PageData MyData { get; set; }
        IPageable Input();
        void Output();
    }

    public struct PageData
    {
        public string title;
        public string author;
    }
}
