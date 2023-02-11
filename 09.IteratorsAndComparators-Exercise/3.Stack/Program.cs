using _3.Stack;

string input = string.Empty;
_3.Stack.Stack<string> stack = new();
while((input = Console.ReadLine()) != "END")
{
    string[] cmdTokens = input
        .Split(new char[]{ ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
    if (cmdTokens[0] == "Push")
    {
        stack.Push(cmdTokens[1..]);
    }
    else
    {
        if(stack.Count == 0)
        {
            Console.WriteLine("No elements");
            continue;
        }
        stack.Pop();
    }
}

foreach (string s in stack)
{
    Console.WriteLine(s);
}

foreach (string s in stack)
{
    Console.WriteLine(s);
}
