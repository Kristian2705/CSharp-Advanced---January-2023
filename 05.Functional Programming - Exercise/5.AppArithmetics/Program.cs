int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

string input = string.Empty;

Func<int, int> GetOperation(string input)
{
    switch (input)
    {
        case "add":
            return x => x + 1;
        case "multiply":
            return x => x * 2;
        case "subtract":
            return x => x - 1;
        default:
            return x => x;
    }
}

Action<int[]> printer = x => Console.WriteLine(string.Join(" ", x));

while ((input = Console.ReadLine()) != "end")
{
    if (input == "print")
    {
        printer(nums);
    }
    else
    {
        Func<int, int> calc = GetOperation(input);

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = calc(nums[i]);
        }
    }
}
