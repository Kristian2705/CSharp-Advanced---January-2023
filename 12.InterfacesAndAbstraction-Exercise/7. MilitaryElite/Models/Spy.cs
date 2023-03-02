using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}{Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}
