using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(650, 1000);
            sportCar.Drive(25);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
