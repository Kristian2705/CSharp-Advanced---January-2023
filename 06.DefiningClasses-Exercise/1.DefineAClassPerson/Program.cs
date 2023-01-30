namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person p = new Person();
            Person p1 = new Person
            {
                Name = "Peter",
                Age = 20
            };
            Person p2 = new Person
            {
                Name = "George",
                Age = 18
            };
            Person p3 = new Person
            {
                Name = "Jose",
                Age = 43
            };
        }
    }
}