using CollectionHierarchy.Models;
using System.Text;

AddCollection addCollection= new();
AddRemoveCollection addRemoveCollection = new();
MyList myList = new();

string[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

int removeOperations = int.Parse(Console.ReadLine());

StringBuilder addCollectionSB = new();
StringBuilder addRemoveCollectionSB = new();
StringBuilder myListSB = new();
foreach(string item in input)
{
    addCollectionSB.Append($"{addCollection.Add(item)} ");
    addRemoveCollectionSB.Append($"{addRemoveCollection.Add(item)} ");
    myListSB.Append($"{myList.Add(item)} ");
}
Console.WriteLine(addCollectionSB.ToString().Trim());
Console.WriteLine(addRemoveCollectionSB.ToString().Trim());
Console.WriteLine(myListSB.ToString().Trim());
addRemoveCollectionSB.Clear();
myListSB.Clear();
for(int i = 0; i < removeOperations; i++)
{
    addRemoveCollectionSB.Append($"{addRemoveCollection.Remove()} ");
    myListSB.Append($"{myList.Remove()} ");
}
Console.WriteLine(addRemoveCollectionSB.ToString().Trim());
Console.WriteLine(myListSB.ToString().Trim());