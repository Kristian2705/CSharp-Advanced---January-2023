using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AdditionalConsumption = 1.4;

        private double baseFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            baseFuelConsumption = fuelConsumption;
            FuelConsumption += AdditionalConsumption;
        }
        public override void Drive(double distance)
        {
            if (FuelConsumption * distance > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
                return;
            }
            FuelQuantity -= distance * FuelConsumption;
            Console.WriteLine($"Bus travelled {distance} km");
        }
        public void ChangeConsumption()
        {
            if (FuelConsumption > baseFuelConsumption)
            {
                FuelConsumption = baseFuelConsumption;
            }
            else
            {
                FuelConsumption += AdditionalConsumption;
            }
        }
    }
}
