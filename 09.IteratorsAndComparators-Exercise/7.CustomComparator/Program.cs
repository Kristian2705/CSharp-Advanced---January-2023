using _7.CustomComparator;

int[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Array.Sort(array, new Comparator());

Console.WriteLine(string.Join(" ", array));