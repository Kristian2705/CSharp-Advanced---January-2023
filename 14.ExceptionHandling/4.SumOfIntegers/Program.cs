using System;

string[] input = Console.ReadLine()
    .Split();

int integerSum = 0;

foreach (var obj in input)
{
    try
    {
        Add(ref integerSum, obj);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (OverflowException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine($"Element '{obj}' processed - current sum: {integerSum}");
    }
}
Console.WriteLine($"The total sum of all integers is: {integerSum}");

static void Add(ref int integerSum, string obj)
{
    int objAsInt = 0;
    try
    {
        objAsInt = int.Parse(obj);
        integerSum += objAsInt;
    }
    catch (FormatException)
    {
        throw new FormatException($"The element '{obj}' is in wrong format!");
    }
    catch (OverflowException)
    {
        throw new OverflowException($"The element '{obj}' is out of range!");
    }
}

