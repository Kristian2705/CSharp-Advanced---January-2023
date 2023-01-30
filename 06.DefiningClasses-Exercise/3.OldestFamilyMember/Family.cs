using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3.OldestFamilyMember
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person p)
        {
            people.Add(p);
        }

        public Person GetOldestMember()
        {
            int maxAge = people[0].Age;
            Person oldestMember = people[0];
            foreach (Person p in people)
            {
                if(maxAge < p.Age)
                {
                    maxAge = p.Age;
                    oldestMember = p;
                }
            }
            return oldestMember;
        }
    }
}
