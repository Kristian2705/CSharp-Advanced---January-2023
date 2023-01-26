int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int n = int.Parse(Console.ReadLine());

Func<int[], int[]> reverser = x => x.Reverse().ToArray();

nums = reverser(nums);

Predicate<int> predicate = x => x % n != 0;

Console.WriteLine(string.Join(" ", nums.Where(x => predicate(x))));
