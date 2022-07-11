using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Lendal
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TaxCode { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        public Lendal(string name, string surname, string taxCode, DateTime startingDate, DateTime endingDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.TaxCode = taxCode;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
        }
    }
}
