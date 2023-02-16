using System.Collections.Concurrent;
using System.Diagnostics;

int[] arr = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

QuickSort<int>.Sort(arr);

Console.WriteLine(string.Join(" ", arr));
public static class QuickSort<T> where T : IComparable<T>
{
    public static void Sort(T[] a)
    {
        Sort(a, 0, a.Length - 1);
    }

    private static void Sort(T[] a, int lo, int hi)
    {
        if(lo >= hi)
        {
            return;
        }
        int p = Partition(a, lo, hi);
        Sort(a, lo, p - 1);
        Sort(a, p + 1, hi);

    }

    private static int Partition(T[] a, int lo, int hi)
    {
        if(lo >= hi)
        {
            return lo;
        }
        int i = lo;
        int j = hi + 1;
        while(true)
        {
            while (Less(a[++i], a[lo]))
            {
                if (i == hi)
                    break;
            }
            while (Less(a[lo], a[--j]))
            {
                if(j == lo)
                    break;
            }
            if(i >= j)
                break;
            Swap(a, i, j);
        }
        Swap(a, lo, j);
        return j;
    }

    private static bool Less(T t1, T t2)
    {
        if(t1.CompareTo(t2) < 0)
        {
            return true;
        }
        return false;
    }

    private static void Swap(T[] a, int i, int j)
    {
        var temp = a[i]; 
        a[i] = a[j]; 
        a[j] = temp;
    }
}