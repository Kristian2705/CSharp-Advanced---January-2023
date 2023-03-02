using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public List<Private> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine();
            sb.AppendLine("Privates:");
            foreach(var privateUnit in Privates)
            {
                sb.AppendLine($"  {privateUnit}");
            }
            return sb.ToString().Trim();
        }
    }
}
