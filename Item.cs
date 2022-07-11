using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{

    public class Item
    {
        public string Code { get; protected set; }
        public string Title { get; protected set; }
        public int ReleaseYear { get; protected set; }
        public string Section { get; protected set; } 
        public bool Available { get; set; }  
        public int Rack { get; protected set; }   
        public string Author { get; protected set; }

        public Item (string code, string title, int releaseYear, string section, bool available, int rack, string author)
        {
            this.Code = code;
            this.Title = title;
            this.ReleaseYear = releaseYear;
            this.Section = section;
            this.Available = available;
            this.Rack = rack;
            this.Author = author;
        }

        public void PrintItem()
        {
            Console.WriteLine("Codice: {0}", this.Code);
            Console.WriteLine("Titolo:{0}", this.Title);
        }

       
    }
}
