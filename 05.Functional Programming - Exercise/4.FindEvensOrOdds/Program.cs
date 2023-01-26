int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int start = nums[0];
int end = nums[1];

string input = Console.ReadLine();

Predicate<int> GetEvenOrOdd(string input)
{
    if (input == "even")
    {
        return x => x % 2 == 0;
    }
    else
    {
        return x => x % 2 != 0;
    }
}

Predicate<int> operation = GetEvenOrOdd(input);

List<int> desiredNums = new();

for (int i = start; i <= end; i++)
{
    if (operation(i))
    {
        desiredNums.Add(i);
    }
}

Console.WriteLine(string.Join(" ", desiredNums));
