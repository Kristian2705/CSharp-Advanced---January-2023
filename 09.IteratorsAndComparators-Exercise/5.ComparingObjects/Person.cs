using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; private set; }
        public int Age { get; private set;}

        public string Town { get; private set;}

        public int CompareTo(Person other)
        {
            if(this.Name.CompareTo(other.Name) < 0)
                return -1;
            if(this.Name.CompareTo(other.Name) > 0)
                return 1;
            if(this.Age < other.Age) 
                return -1;
            if (this.Age > other.Age)
                return -1;
            return this.Town.CompareTo(other.Town);
        }
    }
}
