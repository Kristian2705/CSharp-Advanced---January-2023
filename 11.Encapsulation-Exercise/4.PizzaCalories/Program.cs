using _4.PizzaCalories;

public class StartUp
{
    static void Main()
    {
        try
        {
            string[] pizzaInput = Console.ReadLine()
                .Split();
            string[] doughInput = Console.ReadLine()
                .Split();
            Dough dough = new(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
            Pizza pizza = new(pizzaInput[1], dough);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdTokens = input
                    .Split();
                Topping topping = new(cmdTokens[1], double.Parse(cmdTokens[2]));
                pizza.AddTopping(topping);
            }
            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
