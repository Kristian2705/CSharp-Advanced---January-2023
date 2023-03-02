using _5.BirthdayCelebs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BorderControl
{
    public class Person : INameable, IIdentifiable, IBirthable
    {
        public Person(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
