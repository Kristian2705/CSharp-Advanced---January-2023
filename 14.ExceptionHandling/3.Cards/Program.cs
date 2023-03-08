List<Card> cards = new();

string[] input = Console.ReadLine()
	.Split(", ", StringSplitOptions.RemoveEmptyEntries);

foreach (string card in input)
{
	try
	{
		string[] cardInfo = card
			.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		string face = cardInfo[0];
		string suit = cardInfo[1];
		Card currentCard = new(face, suit);
		cards.Add(currentCard);
	}
	catch(ArgumentException ex)
	{
		Console.WriteLine(ex.Message);
	}
}

Console.WriteLine(string.Join(" ", cards));




public class Card
{
	private string face;
	private string suit;
	private string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
	private string[] validSuits = { "S", "H", "D", "C" };
	public Card(string face, string suit)
	{
		Face = face;
		Suit = suit;
	}

	public string Face
	{
		get => face;
		private set
		{
			if (!validFaces.Contains(value))
			{
				throw new ArgumentException("Invalid card!");
			}
			face = value;
		}
	}

	public string Suit
	{
		get => suit;
		private set
		{
			if (!validSuits.Contains(value))
			{
				throw new ArgumentException("Invalid card!");
			}
			suit = value;
		}
	}

    public override string ToString()
	{
		switch (suit)
		{
			case "S":
                return $"[{face}\u2660]";
            case "H":
                return $"[{face}\u2665]";
			case "D":
                return $"[{face}\u2666]";
			case "C":
                return $"[{face}\u2663]";
			default:
				return null;

        }
	}
}
