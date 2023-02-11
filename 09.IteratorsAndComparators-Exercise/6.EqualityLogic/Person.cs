using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.EqualityLogic
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public override bool Equals(object? obj)
        {
            var item = obj as Person;
            if (item == null)
                return false;
            if (Name.CompareTo(item.Name) != 0 || Age.CompareTo(item.Age) != 0)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
