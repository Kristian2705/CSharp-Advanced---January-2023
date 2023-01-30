using _8.CarSalesman;

int n = int.Parse(Console.ReadLine());
List<Engine> engines = new List<Engine>();
List<Car> cars = new List<Car>();
for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string model = input[0];
    int power = int.Parse(input[1]);
    if(input.Length == 2)
    {
        engines.Add(new Engine(model, power));
    }
    else if(input.Length == 3)
    {
        int displacement = 0;
        string efficiency = string.Empty;
        bool wasParsed = int.TryParse(input[2], out displacement);
        if (wasParsed)
        {
            engines.Add(new Engine(model, power, displacement));
        }
        else
        {
            efficiency = input[2];
            engines.Add(new Engine(model, power, efficiency));
        }
    }
    else if(input.Length == 4)
    {
        int displacement = int.Parse(input[2]);
        string efficiency = input[3];
        engines.Add(new Engine(model, power, displacement, efficiency));
    }
}

int m = int.Parse(Console.ReadLine());

for(int i = 0; i < m; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string model = input[0];
    Engine engine = engines.First(x => x.Model == input[1]);
    if(input.Length == 2)
    {
        cars.Add(new Car(model, engine));
    }
    else if(input.Length == 3)
    {
        int weight = 0;
        string color = string.Empty;
        bool wasParsed = int.TryParse(input[2], out weight);
        if(wasParsed)
        {
            cars.Add(new Car(model, engine, weight));
        }
        else
        {
            color = input[2];
            cars.Add(new Car(model, engine, color));
        }
    }
    else if(input.Length == 4)
    {
        cars.Add(new Car(model, engine, int.Parse(input[2]), input[3]));
    }
}

foreach(Car car in cars)
{
    Console.WriteLine(car.ToString());
}