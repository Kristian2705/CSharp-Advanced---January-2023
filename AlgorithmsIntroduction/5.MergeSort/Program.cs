int[] arr = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(string.Join(" ", MergeSort(arr, 0, arr.Length - 1)));

static int[] MergeSort(int[] array, int start, int end)
{
    if (start == end)
    {
        return new int[] { array[start] };
    }
    int middle = (start + end) / 2;
    int[] left = MergeSort(array, start, middle);
    int[] right = MergeSort(array, middle + 1, end);

    int[] sortedArray = new int[left.Length + right.Length];
    int leftIndex = 0;
    int rightIndex = 0;
    for (int i = 0; i < sortedArray.Length; i++)
    {
        if (leftIndex >= left.Length)
        {
            sortedArray[i] = right[rightIndex];
            rightIndex++;
            continue;
        }
        if(rightIndex >= right.Length)
        {
            sortedArray[i] = left[leftIndex];
            leftIndex++;
            continue;
        }
        if (left[leftIndex] < right[rightIndex])
        {
            sortedArray[i] = left[leftIndex];
            leftIndex++;
        }
        else
        {
            sortedArray[i] = right[rightIndex];
            rightIndex++;
        }
    }
    return sortedArray;
}