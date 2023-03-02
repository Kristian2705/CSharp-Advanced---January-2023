using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BirthdayCelebs
{
    public class Pet : INameable, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
