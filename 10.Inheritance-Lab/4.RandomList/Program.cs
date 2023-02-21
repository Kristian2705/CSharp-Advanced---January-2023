namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList list = new RandomList();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            Console.WriteLine(list.RandomString());
        }
    }
}
