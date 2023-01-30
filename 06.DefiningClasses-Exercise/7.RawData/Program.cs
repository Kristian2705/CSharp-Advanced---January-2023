using _7.RawData;
using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());

List<Car> cars = new();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string model = input[0];
    int engineSpeed = int.Parse(input[1]);
    int enginePower = int.Parse(input[2]);
    int cargoWeight = int.Parse(input[3]);
    string cargoType = input[4];
    double tire1Pressure = double.Parse(input[5]);
    int tire1Age = int.Parse(input[6]);
    double tire2Pressure = double.Parse(input[7]);
    int tire2Age = int.Parse(input[8]);
    double tire3Pressure = double.Parse(input[9]);
    int tire3Age = int.Parse(input[10]);
    double tire4Pressure = double.Parse(input[11]);
    int tire4Age = int.Parse(input[12]);
    cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
}

string type = Console.ReadLine();

if(type == "fragile")
{
    foreach(var car in cars)
    {
        if(car.Cargo.Type != "fragile")
        {
            continue;
        }
        if(car.Tires.Any(x => x.Pressure < 1))
        {
            Console.WriteLine(car.Model);
        }
    }
}
else
{
    foreach (var car in cars)
    {
        if (car.Cargo.Type != "flammable")
        {
            continue;
        }
        if (car.Engine.Power <= 250)
        {
            continue;
        }
        Console.WriteLine(car.Model);
    }
}
