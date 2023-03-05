using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
		private string name;

        private string favouriteFood;

		public Animal(string name, string favouriteFood)
		{
			Name = name;
			FavouriteFood = favouriteFood;
		}
        public string Name
		{
			get { return name; }
			private set { name = value; }
		}

		public string FavouriteFood
		{
			get { return favouriteFood; }
			private set { favouriteFood = value; }
		}

		public virtual string ExplainSelf()
			=> $"I am {Name} and my favourite food is {FavouriteFood}";
    }
}
