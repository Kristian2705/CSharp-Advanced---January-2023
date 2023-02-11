using _4.Froggy;
using System.Text;

int[] nums = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

Lake lake = new(nums);

List<int> path = new();
foreach(int num in lake)
{
    path.Add(num);
}

Console.WriteLine(string.Join(", ", path));
