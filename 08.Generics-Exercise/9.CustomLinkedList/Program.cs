namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {

            DoublyLinkedList<string> list = new();

            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddLast("4");
            list.AddFirst("5");

            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());

            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            foreach(var x in list)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine(string.Join(" ", list.ToArray()));
        }
    }
}
