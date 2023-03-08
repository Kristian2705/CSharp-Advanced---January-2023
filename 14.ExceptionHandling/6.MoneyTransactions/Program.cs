Dictionary<int, double> bankAccounts = new();

string[] input = Console.ReadLine()
    .Split(',', StringSplitOptions.RemoveEmptyEntries);

foreach (string inputString in input)
{
    string[] bankAccountData = inputString
        .Split('-', StringSplitOptions.RemoveEmptyEntries);
    int accountNumber = int.Parse(bankAccountData[0]);
    double accountBalance = double.Parse(bankAccountData[1]);
    if (!bankAccounts.ContainsKey(accountNumber))
    {
        bankAccounts[accountNumber] = 0.0;
    }
    bankAccounts[accountNumber] = accountBalance;
}

string command = string.Empty;

while((command = Console.ReadLine()) != "End")
{
    string[] commandInfo = command
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    try
    {
        int currAccountNumber = int.Parse(commandInfo[1]);
        double balance = double.Parse(commandInfo[2]);
        switch (commandInfo[0])
        {
            case "Deposit":
                bankAccounts[currAccountNumber] += balance;
                Console.WriteLine($"Account {currAccountNumber} has new balance: {bankAccounts[currAccountNumber]:F2}");
                break;
            case "Withdraw":
                if(bankAccounts[currAccountNumber] < balance)
                {
                    throw new ArgumentException("Insufficient balance!");
                }
                bankAccounts[currAccountNumber] -= balance;
                Console.WriteLine($"Account {currAccountNumber} has new balance: {bankAccounts[currAccountNumber]:F2}");
                break;
            default:
                throw new ArgumentException("Invalid command!");
        }
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(KeyNotFoundException)
    {
        Console.WriteLine("Invalid account!");
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}


