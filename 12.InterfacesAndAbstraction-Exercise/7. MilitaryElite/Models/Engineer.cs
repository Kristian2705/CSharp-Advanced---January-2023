using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine();
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair}");
            }
            return sb.ToString().Trim();
        }
    }
}
