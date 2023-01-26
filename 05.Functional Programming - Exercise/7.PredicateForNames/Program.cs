int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Predicate<string> predicate = x => x.Length <= n;

Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => predicate(x))));
