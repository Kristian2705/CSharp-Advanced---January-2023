using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PizzaCalories
{
    public class Topping
    {
		private string type; 
		private double grams;
        private const double defaultCaloriesPerGram = 2;

		public Topping(string type, double grams)
		{
			Type = type;
			Grams = grams;
		}
        private string Type
		{
			set
			{
				if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}
				type = value;
			}
		}

		private double Grams
		{
			set
			{
				if(value < 1 || value > 50)
				{
					throw new ArgumentException($"{type} weight should be in the range [1..50].");
				}
				grams = value;
			}
		}

		public double CaloriesPerGram { get { return GetCaloriesPerGram(); } }

		private double GetCaloriesPerGram()
		{
			double typeModifier = 0.0;
			switch(type.ToLower())
			{
				case "meat":
					typeModifier = 1.2;
					break;
				case "veggies":
					typeModifier = 0.8;
					break;
				case "cheese":
					typeModifier = 1.1;
                    break;
				case "sauce":
					typeModifier = 0.9;
					break;
			}
			return defaultCaloriesPerGram * grams * typeModifier;
		}
	}
}
