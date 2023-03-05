﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
            => $"I am {Name} and my favourite food is {FavouriteFood}{Environment.NewLine}DJAAF";
    }
}
