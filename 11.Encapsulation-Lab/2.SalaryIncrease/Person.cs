using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
        private string lastName;
		private int age;
        private decimal salary;

		public Person(string firstName, string lastName, int age, decimal salary)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Salary = salary;
		}
		public string FirstName
		{
			get { return firstName; }
			private set { firstName = value; }
		}
		public string LastName
		{
			get { return lastName; }
			private set { lastName = value; }
		}
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            private set { salary = value; }
        }

        public void IncreaseSalary(decimal percentage)
		{
			if(Age < 30)
			{
				percentage /= 2;
			}
			Salary += Salary * (percentage / 100);
		}
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
