using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PizzaCalories
{
    public class Pizza
    {
		private string name;
		private Dough dough;
		private List<Topping> toppings;

		public Pizza(string name, Dough dough)
		{
			Name = name;
			Dough = dough;
			toppings = new List<Topping>();
		}
		public string Name
		{   
			get { return name; }
			set
			{
				if(string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value;
			}
		}

		public Dough Dough { get { return dough; } set { dough = value; } }

		public int NumberOfToppings 
		{
			get
			{
				return toppings.Count;
            } 
		}

		public double TotalCalories
		{
			get { return GetTotalCalories(); }
		}

		public void AddTopping(Topping topping)
		{
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

		private double GetTotalCalories()
		{
			double totalCaloriesFromToppings = 0.0;
			foreach (var topping in toppings)
			{
				totalCaloriesFromToppings += topping.CaloriesPerGram;
			}
			return totalCaloriesFromToppings + Dough.CaloriesPerGram;
		}

        public override string ToString()
        {
			return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}
