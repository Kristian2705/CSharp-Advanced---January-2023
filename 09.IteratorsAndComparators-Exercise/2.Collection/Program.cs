using _2.Collection;
using System.Text;

ListyIterator<string> iterator;
string input = Console.ReadLine();
string[] cmdTokens = input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

if (cmdTokens.Length >= 2)
{
    iterator = new(cmdTokens[1..]);
}
else
{
    iterator = new();
}


while ((input = Console.ReadLine()) != "END")
{
    if (input == "Move")
    {
        Console.WriteLine(iterator.Move());
    }
    else if (input == "HasNext")
    {
        Console.WriteLine(iterator.HasNext());
    }
    else if(input == "PrintAll")
    {
        StringBuilder sb = new StringBuilder();
        foreach(var item in iterator)
        {
            sb.Append($"{item} ");
        }
        Console.WriteLine(sb.ToString().Trim());
    }
    else if(input == "Print")
    {
        iterator.Print();
    }
}

