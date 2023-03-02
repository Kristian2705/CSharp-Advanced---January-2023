using _6.FoodShortage.Interfaces;
using _6.FoodShortage.Models;

List<IBuyer> buyers = new List<IBuyer>();

int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if(info.Length == 3)
    {
        IBuyer rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
        buyers.Add(rebel);
    }
    else if(info.Length == 4)
    {
        IBuyer person = new Person(info[0], int.Parse(info[1]), info[2], info[3]);
        buyers.Add(person);
    }
}

string input = string.Empty;

while((input = Console.ReadLine()) != "End")
{
    var currentBuyer = buyers.FirstOrDefault(b => b.Name == input);
    if(currentBuyer == null)
    {
        continue;
    }
    currentBuyer.BuyFood();
}

Console.WriteLine(buyers.Sum(b => b.Food));
