List<int> numbers = new();

while(numbers.Count < 10)
{
    try
    {
        if(numbers.Count == 0)
        {
            numbers.Add(ReadNumber(1, 100));
        }
        else
        {
            numbers.Add(ReadNumber(numbers.Max(), 100));
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(", ", numbers.ToArray()));
static int ReadNumber(int start, int end)
{
    int n = 0;
    try
    {
        n = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        throw new FormatException("Invalid Number!");
    }
    if(n <= start || n >= end)
    {
        throw new ArgumentException($"Your number is not in range {start} - 100!");
    }
    return n;
}
