using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PizzaCalories
{
    public class Dough
    {
		private string flourType;
        private string bakingTechnique;
		private double grams;
		private const double defaultCaloriesPerGram = 2;

		public Dough(string flourType, string bakingTechnique, double grams)
		{
			FlourType = flourType;
			BakingTechnique = bakingTechnique;
			Grams = grams;
		}
        private string FlourType
		{
			set
			{
				if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				flourType = value;
			}
		}

		private string BakingTechnique
		{
			set
			{
				if(value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				bakingTechnique = value;
			}
		}

		private double Grams
		{
			set
			{
				if(value < 1 || value > 200)
				{
					throw new ArgumentException("Dough weight should be in the range [1..200].");
				}
				grams = value;
			}
		}

		public double CaloriesPerGram { get { return GetCaloriesPerGram(); } }

		private double GetCaloriesPerGram()
		{
			double flourTypeModifier = 0.0;
			double bakingTechniqueModifier = 0.0;
			switch(flourType.ToLower())
			{
				case "white":
					flourTypeModifier = 1.5; 
					break;
				case "wholegrain":
					flourTypeModifier = 1.0;
					break;
			}
			switch(bakingTechnique.ToLower())
			{
				case "crispy":
					bakingTechniqueModifier = 0.9;
					break;
				case "chewy":
					bakingTechniqueModifier = 1.1;
					break;
				case "homemade":
					bakingTechniqueModifier = 1.0;
                    break;
			}
			return defaultCaloriesPerGram * grams * flourTypeModifier * bakingTechniqueModifier; 
		}
	}
}
