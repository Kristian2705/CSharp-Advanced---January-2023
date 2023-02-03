using CustomStack;

Stack stack = new();

stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);
stack.Push(6);
stack.Pop();
stack.Pop();
stack.ForEach(x => Console.WriteLine(x));
Console.WriteLine(stack.Peek());