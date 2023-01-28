namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;

    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currTires = new Tire[4]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]))
                };
                tires.Add(currTires);
            }
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currEngine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(currEngine);
            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int tireIndex = int.Parse(carInfo[5]);
                int engineIndex = int.Parse(carInfo[6]);
                Car currCar = new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), double.Parse(carInfo[3]), double.Parse(carInfo[4]), engines[engineIndex], tires[tireIndex]);
                cars.Add(currCar);
            }
            foreach (var car in cars)
            {
                if (car.Year < 2017)
                {
                    continue;
                }
                if (car.Engine.HorsePower <= 330)
                {
                    continue;
                }
                double currTirePressureSum = 0.0;
                foreach (var tire in car.Tires)
                {
                    currTirePressureSum += tire.Pressure;
                }
                if (currTirePressureSum < 9 || currTirePressureSum > 10)
                {
                    continue;
                }
                car.Drive(0.2);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}


