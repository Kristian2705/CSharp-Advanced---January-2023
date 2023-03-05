using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AdditionalConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += AdditionalConsumption;
        }

        public override void Drive(double distance)
        {
            if(FuelConsumption * distance > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
                return;
            }
            FuelQuantity -= distance * FuelConsumption;
            Console.WriteLine($"Truck travelled {distance} km");
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + amount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                return;
            }
            FuelQuantity += amount * 0.95;
        }
    }
}
