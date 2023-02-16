using System.Dynamic;

int[] arr = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int element = int.Parse(Console.ReadLine());

Console.WriteLine(GetIndex(element, arr, 0, arr.Length - 1));

int GetIndex(int element, int[] array, int start, int end)
{
    int mid = (start + end) / 2;
    if (start > end)
        return -1;
    if (array[mid] == element) 
        return mid;
    else if (element < array[mid])
    {
        return GetIndex(element, array, start, mid);
    }
    else
    {
        return GetIndex(element, array, mid + 1, end);
    }
}