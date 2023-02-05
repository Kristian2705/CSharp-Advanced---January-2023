using _8.Threeuple;

string[] nameAddressTown = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string personName = nameAddressTown[0] + " " + nameAddressTown[1];
string address = nameAddressTown[2];
string town = string.Join(" ", nameAddressTown.Skip(3));

Threeuple threeuple = new(personName, address, town);

Console.WriteLine($"{threeuple.Item1} -> {threeuple.Item2} -> {threeuple.Item3}");

string[] nameBeerDrunk = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

personName = nameBeerDrunk[0];
int beerAmount = int.Parse(nameBeerDrunk[1]);
bool drunk = false;
if (nameBeerDrunk[2] == "drunk")
{
    drunk = true;
}

Threeuple threeuple2 = new(personName, beerAmount, drunk);

Console.WriteLine($"{threeuple2.Item1} -> {threeuple2.Item2} -> {threeuple2.Item3}");

string[] nameBalanceBank = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string name = nameBalanceBank[0];
double balance = double.Parse(nameBalanceBank[1]);
string bank = nameBalanceBank[2];

Threeuple threeuple3 = new(name, balance, bank);

Console.WriteLine($"{threeuple3.Item1} -> {threeuple3.Item2} -> {threeuple3.Item3}");

