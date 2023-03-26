using _1.Prototype.Models;

SandwichRepository sandwichRepository = new();

sandwichRepository["Big Mac"] = new Sandwich("Beef", "Chedar", "White", "Pickles");
sandwichRepository["Doge's Special"] = new Sandwich("Pork", "Chedar", "White", "Tomatoes");

sandwichRepository["Two sausages"] = new Sandwich("Sausage", "Normal cheese", "White", "Tomatoes and lettuce");
sandwichRepository["Chicken sandwich"] = new Sandwich("Chicken", "Normal cheese", "White", "Lettuce");

Sandwich cloned1 = sandwichRepository["Doge's Special"].Clone() as Sandwich;
Sandwich cloned2 = sandwichRepository["Two sausages"].Clone() as Sandwich;
Sandwich cloned3 = sandwichRepository["Chicken sandwich"].Clone() as Sandwich;

