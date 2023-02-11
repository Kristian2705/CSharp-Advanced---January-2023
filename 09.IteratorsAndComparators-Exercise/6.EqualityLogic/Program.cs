using _6.EqualityLogic;

int n = int.Parse(Console.ReadLine());
HashSet<Person> hashSet = new HashSet<Person>(new Comparer());
SortedSet<Person> sortedSet = new SortedSet<Person>(new Comparer());
for(int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Person p = new Person(tokens[0], int.Parse(tokens[1]));
    hashSet.Add(p);
    sortedSet.Add(p);
}

Console.WriteLine(sortedSet.Count);
Console.WriteLine(hashSet.Count);
