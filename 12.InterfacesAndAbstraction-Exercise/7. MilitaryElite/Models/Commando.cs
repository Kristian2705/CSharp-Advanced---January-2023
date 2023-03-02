using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine();
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission}");
            }
            return sb.ToString().Trim();
        }
    }
}
