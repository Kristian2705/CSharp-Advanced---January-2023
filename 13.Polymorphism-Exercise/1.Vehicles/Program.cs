using System.Net.Http.Headers;
using Vehicles;

string[] carInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

string[] truckInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    string[] cmdTokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = cmdTokens[0];
    string vehicle = cmdTokens[1];
    if(action == "Drive")
    {
        if(vehicle == "Car")
        {
            car.Drive(double.Parse(cmdTokens[2]));
        }
        else
        {
            truck.Drive(double.Parse(cmdTokens[2]));
        }
    }
    else
    {
        if(vehicle == "Car")
        {
            car.Refuel(double.Parse(cmdTokens[2]));
        }
        else
        {
            truck.Refuel(double.Parse(cmdTokens[2]));
        }
    }
}

Console.WriteLine($"Car: {car.FuelQuantity:F2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
