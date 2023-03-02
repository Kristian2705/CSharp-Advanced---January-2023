using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FoodShortage.Interfaces
{
    public interface IBuyer : INameable
    {
        int Food { get => 0; }
        void BuyFood();
    }
}
