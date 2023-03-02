using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6.FoodShortage.Interfaces;

namespace _6.FoodShortage.Models
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
