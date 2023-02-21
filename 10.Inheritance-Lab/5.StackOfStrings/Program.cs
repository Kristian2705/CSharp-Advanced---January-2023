namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings s = new StackOfStrings();
            Console.WriteLine(s.IsEmpty());
            Console.WriteLine(s.AddRange(new string[] { "a", "b", "c" }));
            foreach(var item in s)
            {
                Console.WriteLine(item);
            }
        }
    }
}
