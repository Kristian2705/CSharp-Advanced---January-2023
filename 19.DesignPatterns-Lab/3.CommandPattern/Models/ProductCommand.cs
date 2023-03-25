using _3.CommandPattern.Enums;
using _3.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CommandPattern.Models
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }


        public void ExecuteAction()
        {
            switch(priceAction)
            {
                case PriceAction.Increase:
                    product.IncreasePrice(amount); 
                    break;
                default:
                    product.DecreasePrice(amount); 
                    break;
            }
        }
    }
}
