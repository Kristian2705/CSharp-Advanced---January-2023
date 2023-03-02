using _3.Telephony;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] urls = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICallable smartphone = new Smartphone();
ICallable stationaryPhone = new StationaryPhone();
foreach(string phoneNumber in phoneNumbers)
{
    if (phoneNumber.Length == 10)
    {
        smartphone.Call(phoneNumber);
    }
    else
    {
        stationaryPhone.Call(phoneNumber);
    }
}

IBrowsable browsablePhone = new Smartphone();
foreach(string url in urls)
{
    browsablePhone.Browse(url);
}

