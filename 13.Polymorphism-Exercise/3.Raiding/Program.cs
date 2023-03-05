using _3.Raiding;
using _3.Raiding.Creators;

int n = int.Parse(Console.ReadLine());

Creator creator;
List<BaseHero> heroes = new();

while (heroes.Count < n)
{
    string name = Console.ReadLine();
    string type = Console.ReadLine();
    switch (type)
    {
        case "Druid":
            creator = new DruidCreator();
            break;
        case "Paladin":
            creator = new PaladinCreator();
            break;
        case "Rogue":
            creator = new RogueCreator();
            break;
        case "Warrior":
            creator = new WarriorCreator();
            break;
        default:
            Console.WriteLine("Invalid hero!");
            continue;
    }
    heroes.Add(creator.FactoryMethod(name));
}

int bossPower = int.Parse(Console.ReadLine());


foreach(var hero in heroes)
{
    Console.WriteLine(hero.CastAbility());
}

if(heroes.Sum(x => x.Power) >= bossPower)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}
