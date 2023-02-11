using _5.ComparingObjects;

string input = string.Empty;
List<Person> people = new();

while((input = Console.ReadLine()) != "END")
{
    string[] cmdTokens = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Person person = new(cmdTokens[0], int.Parse(cmdTokens[1]), cmdTokens[2]);
    people.Add(person);
}

int n = int.Parse(Console.ReadLine());

int countOfMatches = 0;
int countOfDifferentPeople = 0;

Person personToCompare = people[n - 1];
foreach(Person person in people)
{
    if (personToCompare.CompareTo(person) == 0)
    {
        countOfMatches++;
    }
    else
    {
        countOfDifferentPeople++;
    }
}

if(countOfMatches > 1)
{
    Console.WriteLine($"{countOfMatches} {countOfDifferentPeople} {people.Count}");
    return;
}
Console.WriteLine("No matches");
