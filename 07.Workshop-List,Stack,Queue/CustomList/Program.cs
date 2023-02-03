using CustomList;

List items = new();

items.Add(1);
items.Add(2);
items.Add(3);

items[1] = 555;

items.Add(4);
items.Add(5);
items.Add(6);
items.Add(7);
items.Add(8);

items.Insert(8, 100);

Console.WriteLine(items.Contains(3));
Console.WriteLine(items.Contains(345));
items.Swap(1, 2);
items.AddRange(new int[]{ 1, 2, 3 });
