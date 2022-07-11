using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace csharp_biblioteca
{
    public class User
    {
        public string Surname { get;  set; }
        public string Name { get; set; }
        
        
        public User(string surname, string name)
        {
            this.Surname = surname; 
            this.Name = name;
            
        }

    }
}
