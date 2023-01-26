List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input = string.Empty;

Predicate<string> GetFilter(string filter, string argument)
{
    switch (filter)
    {
        case "Starts with":
            return x => x.Substring(0, argument.Length) == argument;
        case "Ends with":
            return x => x.Substring(x.Length - argument.Length, argument.Length) == argument;
        case "Length":
            return x => x.Length == int.Parse(argument);
        case "Contains":
            return x => x.Contains(argument);
        default:
            return null;
    }
}
List<Predicate<string>> predicates = new();

List<string> filters = new();

while ((input = Console.ReadLine()) != "Print")
{
    string[] cmdTokens = input
        .Split(";", StringSplitOptions.RemoveEmptyEntries);
    string command = cmdTokens[0];
    string filter = cmdTokens[1];
    if (command == "Add filter")
    {
        filters.Add($"{filter}:{cmdTokens[2]}");
    }
    else
    {
        filters.Remove($"{filter}:{cmdTokens[2]}");
    }
}

foreach (var filter in filters)
{
    Predicate<string> currFilter = GetFilter(filter.Split(":")[0], filter.Split(":")[1]);
    predicates.Add(currFilter);
}

foreach (var filter in predicates)
{
    for (int i = 0; i < people.Count; i++)
    {
        if (filter(people[i]))
        {
            people.RemoveAt(i);
            i--;
        }
    }
}

Console.WriteLine(string.Join(" ", people));
