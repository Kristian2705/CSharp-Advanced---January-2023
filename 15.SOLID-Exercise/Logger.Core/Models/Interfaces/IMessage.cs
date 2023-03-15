using Logger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Models.Interfaces
{
    public interface IMessage
    {
        string CreatedTime { get; }
        string Text { get; }
        ReportLevel reportLevel { get; }
    }
}
