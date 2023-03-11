using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> document = new()
            {
                "Playing LoL",
                "Motive homework",
                "Materials for lectures"
            };
            List<Employee> employees = new List<Employee>
            {
                new Employee("Doge"),
                new Manager("Stambio", document)
            };
            DetailsPrinter detailPrinter = new DetailsPrinter(employees);
            detailPrinter.PrintDetails();
        }
    }
}
