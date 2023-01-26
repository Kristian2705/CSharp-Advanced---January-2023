int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Func<int[], int> GetMin = x => x.Min();

Console.WriteLine(GetMin(nums));
