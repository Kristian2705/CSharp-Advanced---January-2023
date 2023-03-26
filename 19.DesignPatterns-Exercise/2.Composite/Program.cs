using _2.Composite.Models;

SingleGift gift = new("Vbucks", 20);
gift.CalculateTotalPrice();
Console.WriteLine();

var giftCards = new CompositeGift("Vbucks gift cards", 100);
var thousandVbucks = new SingleGift("1000 Vbuck", 15);
var twoThousandVbucks = new SingleGift("2000 Vbucks", 25);

giftCards.Add(thousandVbucks);
giftCards.Add(twoThousandVbucks);

var moreGiftCards = new CompositeGift("Vbucks additional cards", 50);
var threeThousandVbucks = new SingleGift("3000 Vbucks", 32);

moreGiftCards.Add(threeThousandVbucks);
giftCards.Add(moreGiftCards);

Console.WriteLine($"The total price of this composite present is: {giftCards.CalculateTotalPrice()} lv.");
