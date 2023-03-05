using Vehicles;

string[] carInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

string[] truckInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

string[] busInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3])); ;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] cmdTokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = cmdTokens[0];
    string vehicle = cmdTokens[1];
    if (action == "Drive")
    {
        if (vehicle == "Car")
        {
            car.Drive(double.Parse(cmdTokens[2]));
        }
        else if(vehicle == "Truck")
        {
            truck.Drive(double.Parse(cmdTokens[2]));
        }
        else
        {
            bus.Drive(double.Parse(cmdTokens[2]));
        }
    }
    else if(action == "Refuel")
    {
        if (vehicle == "Car")
        {
            car.Refuel(double.Parse(cmdTokens[2]));
        }
        else if(vehicle == "Truck")
        {
            truck.Refuel(double.Parse(cmdTokens[2]));
        }
        else
        {
            bus.Refuel(double.Parse(cmdTokens[2]));
        }
    }
    else
    {
        Bus currentBus = bus as Bus;
        if (currentBus != null)
        {
            currentBus.ChangeConsumption();
            currentBus.Drive(double.Parse(cmdTokens[2]));
            currentBus.ChangeConsumption();
        }
    }
}

Console.WriteLine($"Car: {car.FuelQuantity:F2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

static bool CheckFuel(double amount, double tankCapacity)
    => amount > tankCapacity;

/*
Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
2
DriveEmpty Bus 10
Drive Bus 1
 */ 