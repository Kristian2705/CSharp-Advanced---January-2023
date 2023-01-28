namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            Car car = new Car();
            Car secondCar = new Car("BMW", "X3", 2019);
            Car thirdCar = new Car("Audi", "R8", 2022, 2000, 100);
        }
    }
}


