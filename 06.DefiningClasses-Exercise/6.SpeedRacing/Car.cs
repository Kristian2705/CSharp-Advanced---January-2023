using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Schema;

namespace _6.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }

        public double FuelConsumptionPerKilometer { get { return fuelConsumptionPerKilometer;}  set { fuelConsumptionPerKilometer = value; } }
        public double TravelledDistance { get { return travelledDistance; } set { travelledDistance = value; } }

        public void Drive(double km)
        {
            double expense = this.FuelConsumptionPerKilometer * km;
            if(this.FuelAmount >= expense)
            {
                this.FuelAmount -= expense;
                this.TravelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
