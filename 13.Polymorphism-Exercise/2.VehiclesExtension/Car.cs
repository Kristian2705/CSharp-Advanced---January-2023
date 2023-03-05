﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AdditionalConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += AdditionalConsumption;
        }

        public override void Drive(double distance)
        {
            if (FuelConsumption * distance > FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
                return;
            }
            FuelQuantity -= distance * FuelConsumption;
            Console.WriteLine($"Car travelled {distance} km");
        }
    }
}
