using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ShoppingSpree
{
    public class Person
    {
		private string name;
        private decimal money;
		private List<Product> products;

		public Person(string name, decimal money)
		{
			Name = name;
			Money = money;
			products = new List<Product>();
		}
        public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
				name = value;
			}
		}
		public decimal Money
		{
			get { return money; }
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				money = value;
			}
		}

		public IReadOnlyCollection<Product> Products
		{
			get { return products.AsReadOnly(); }
		}

		private bool CanAfford(Product product)
		{
			if(Money >= product.Cost)
			{
				return true;
			}
			return false;
		}

		public void PurchaseProduct(Product product)
		{
			if(!CanAfford(product))
			{
				Console.WriteLine($"{Name} can't afford {product.Name}");
				return;
			}
			products.Add(product);
			Money -= product.Cost;
			Console.WriteLine($"{Name} bought {product.Name}");
		}
	}
}
