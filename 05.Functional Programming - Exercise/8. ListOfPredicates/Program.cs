int n = int.Parse(Console.ReadLine());

int[] dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<int, int, bool> predicate = (x, y) => x % y == 0;


List<int> newNums = new();
for (int i = 1; i <= n; i++)
{
    int divCounter = 0;
    foreach (var div in dividers)
    {
        if (predicate(i, div))
        {
            divCounter++;
        }
    }
    if (divCounter == dividers.Length)
    {
        newNums.Add(i);
    }
}

Console.WriteLine(string.Join(" ", newNums));
