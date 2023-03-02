using _9.ExplicitInterface.Interfaces;
using _9.ExplicitInterface.Models;

string input = string.Empty;

while((input = Console.ReadLine()) != "End")
{
    string[] personInfo = input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string name = personInfo[0];
    string country = personInfo[1];
    int age = int.Parse(personInfo[2]);
    IPerson citizenAsPerson = new Citizen(name, country, age);
    Console.WriteLine(citizenAsPerson.GetName());
    IResident citizenAsResident = new Citizen(name, country, age);
    Console.WriteLine(citizenAsResident.GetName());
}
