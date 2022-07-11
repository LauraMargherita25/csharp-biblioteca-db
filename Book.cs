using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Book : Item
    {
        public string Isbn
        {
            get
            {
                return base.Code;
            }
            set
            {
                base.Code = value;
            }
        }

        public int NPage { get; private set; }


        public Book (string isbn, string title, int releaseYear, string section, bool available, int rack, string author, int nPage) : base(isbn, title, releaseYear, section, available, rack, author)
        {
            this.Isbn = isbn;
            this.NPage = nPage;
        }

        public void PrintBooK()
        {
            Console.WriteLine("Titlo {0}", this.Isbn);
            Console.WriteLine("Titlo {0}", base.Title);
            Console.WriteLine("Titlo {0}", base.Available);
        }
    }
}
