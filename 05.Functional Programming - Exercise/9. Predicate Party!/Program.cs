List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string input = string.Empty;

Predicate<string> GetType(string command, string type)
{
    switch (command)
    {
        case "StartsWith":
            return x => x.Substring(0, type.Length) == type;
        case "EndsWith":
            return x => x.Substring(x.Length - type.Length, type.Length) == type;
        case "Length":
            return x => x.Length == int.Parse(type);
        default:
            return null;
    }
}

while ((input = Console.ReadLine()) != "Party!")
{
    string[] cmdTokens = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (cmdTokens[0] == "Double")
    {
        Predicate<string> filter = GetType(cmdTokens[1], cmdTokens[2]);
        for (int i = 0; i < people.Count; i++)
        {
            if (filter(people[i]))
            {
                int occurences = people.Count(x => x == people[i]);
                for (int j = 0; j < occurences; j++)
                {
                    people.Insert(i, people[i]);
                    i += 2;
                }
            }
        }
    }
    else
    {
        Predicate<string> filter = GetType(cmdTokens[1], cmdTokens[2]);
        people.RemoveAll(filter);
    }
}

if (people.Count > 0)
{
    Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}
