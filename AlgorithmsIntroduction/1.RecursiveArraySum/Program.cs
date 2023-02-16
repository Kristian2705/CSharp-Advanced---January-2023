int[] arr = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(GetArraySum(arr, 0));

int GetArraySum(int[] arr, int index)
{
    if(index == arr.Length - 1)
    {
        return arr[index];
    }
    return arr[index] + GetArraySum(arr, index + 1);
}