using _1.Logger.Models.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string DisplayingFormat => "{0} - {1} - {2}";
    }
}
