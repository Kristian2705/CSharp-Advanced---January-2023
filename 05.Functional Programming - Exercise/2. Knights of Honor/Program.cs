string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> printer = x => Console.WriteLine($"Sir {x}");

foreach (var name in names)
{
    printer(name);
}
