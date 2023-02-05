string[] nameCity = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string personName = nameCity[0] + " " + nameCity[1];
string city = nameCity[2];

_7.Tuple.Tuple tuple = new(personName, city);

Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");

string[] nameBeer = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

personName = nameBeer[0];
int beerAmount = int.Parse(nameBeer[1]);

_7.Tuple.Tuple tuple2 = new(personName, beerAmount);
Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

string[] intDouble = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

int integer = int.Parse(intDouble[0]);
double doub = double.Parse(intDouble[1]);

_7.Tuple.Tuple tuple3 = new(integer, doub);

Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");
