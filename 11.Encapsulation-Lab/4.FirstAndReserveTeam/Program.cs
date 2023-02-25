namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            Team team = new Team("SoftUni");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new(info[0], info[1], int.Parse(info[2]), decimal.Parse(info[3]));
                persons.Add(person);
            }
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);
        }
    }
}
