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
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
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
            FuelQuantity += amount * 0.95;
        }
    }
}
