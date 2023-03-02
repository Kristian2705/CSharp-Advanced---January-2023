using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }
}
