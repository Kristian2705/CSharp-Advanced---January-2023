using _1.Logger.Models.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        private string format;

        public XmlLayout()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("<log>");
            stringBuilder.AppendLine("   <date>{0}<date/>");
            stringBuilder.AppendLine("   <level>{1}</level>");
            stringBuilder.AppendLine("   <message>{2}</message>");
            stringBuilder.AppendLine("</log>");
            format = stringBuilder.ToString();
        }
        public string DisplayingFormat => format;
    }
}
