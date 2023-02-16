using System.ComponentModel.DataAnnotations.Schema;

int n = int.Parse(Console.ReadLine());

Console.WriteLine(GetFactorial(n));

long GetFactorial(int n)
{
    if(n == 1)
    {
        return 1;
    }
    return n * GetFactorial(n - 1);
}