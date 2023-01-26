int number = int.Parse(Console.ReadLine());

string[] people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> firstFunc = (x, y) =>
{
    int sum = 0;
    foreach (var ch in x)
    {
        sum += ch;
    }
    if (sum >= y)
        return true;
    return false;
};

Func<string[], Func<string, int, bool>, int, string> secondFunc = (people1, filter, num) =>
{
    foreach (var person in people1)
    {
        if (filter(person, num))
        {
            return person;
        }
    }
    return null;
};

Func<string> printer = () => secondFunc(people, firstFunc, number);

Console.WriteLine(printer());
