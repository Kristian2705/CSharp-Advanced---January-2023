
using _1.Singleton.Models;

var db = SingletonDataContainer.Instance;

Console.WriteLine(db.GetPopulation("Washington, D.C."));

var db2 = SingletonDataContainer.Instance;

Console.WriteLine(db2.GetPopulation("London"));