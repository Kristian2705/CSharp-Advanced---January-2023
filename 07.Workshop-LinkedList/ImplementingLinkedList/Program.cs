using ImplementingLinkedList;

LinkedList linkedList = new LinkedList();

linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);
linkedList.AddLast(4);
linkedList.AddFirst(5);

linkedList.RemoveFirst();
linkedList.RemoveLast();

linkedList.ForEach(x => Console.WriteLine(x));
linkedList.ForEachReverse(x => Console.WriteLine(x));

Console.WriteLine(string.Join(" ", linkedList.ToArray()));