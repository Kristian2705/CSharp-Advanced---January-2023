using _3.ShoppingSpree;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();
try
{
    string[] peopleInput = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);
    foreach (var person in peopleInput)
    {
        string[] info = person
            .Split("=", StringSplitOptions.RemoveEmptyEntries);
        string name = info[0];
        decimal money = decimal.Parse(info[1]);
        Person currentPerson = new(name, money);
        people.Add(currentPerson);
    }

    string[] productsInput = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);
    foreach (var product in productsInput)
    {
        string[] info = product
            .Split("=", StringSplitOptions.RemoveEmptyEntries);
        string name = info[0];
        decimal cost = decimal.Parse(info[1]);
        Product currentProduct = new(name, cost);
        products.Add(currentProduct);
    }

    string input = string.Empty;
    while ((input = Console.ReadLine()).ToLower() != "end")
    {
        string[] cmdTokens = input
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string personName = cmdTokens[0];
        string productName = cmdTokens[1];
        var person = people.Find(x => x.Name == personName);
        var product = products.Find(x => x.Name == productName);
        person.PurchaseProduct(product);
    }

    foreach (var person in people)
    {
        if (person.Products.Count > 0)
        {
            List<string> currentPersonProducts = new List<string>();
            foreach(var product in person.Products)
            {
                currentPersonProducts.Add(product.Name);
            }
            Console.WriteLine($"{person.Name} - {string.Join(", ", currentPersonProducts)}");
        }
        else
        {
            Console.WriteLine($"{person.Name} - Nothing bought");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
