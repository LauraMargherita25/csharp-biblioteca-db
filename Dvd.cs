using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Dvd : Item
    {
        public string Sn
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
        public int RunningTime { get; private set; }

        public Dvd(string sn, string title, int releaseYear, string section, bool available, int rack, string author, int runningTime) : base(sn, title, releaseYear, section, available, rack, author)
        {
            this.Sn = sn;
            this.RunningTime = runningTime;
        }

        public void PrintDvd()
        {
            Console.WriteLine("Titlo {0}", this.Sn);
            Console.WriteLine("Titlo {0}", base.Title);
            Console.WriteLine("Titlo {0}", base.Available);
        }
    }
}
