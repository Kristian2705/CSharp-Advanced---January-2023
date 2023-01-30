using _6.SpeedRacing;

int n = int.Parse(Console.ReadLine());

List<Car> cars = new();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string model = input[0];
    double fuelAmount = double.Parse(input[1]);
    double fuelConsumption = double.Parse(input[2]);
    cars.Add(new Car(model, fuelAmount, fuelConsumption));
}

string input2 = string.Empty;
while((input2 = Console.ReadLine()) != "End")
{
    string[] cmdTokens = input2
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Skip(1)
        .ToArray();
    string model = cmdTokens[0];
    double distance = double.Parse(cmdTokens[1]);
    var currentCar = cars.First(x => x.Model == model);
    currentCar.Drive(distance);
}

foreach(var car in cars)
{
    Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
}
