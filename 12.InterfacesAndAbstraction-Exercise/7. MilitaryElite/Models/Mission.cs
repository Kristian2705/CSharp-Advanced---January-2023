using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codename, string state)
        {
            CodeName = codename;
            State = state;
        }
        public string CodeName { get; set; }

        public string State { get; set; }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
