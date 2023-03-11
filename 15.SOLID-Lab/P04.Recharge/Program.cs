using System;

namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            Robot robot = new("123", 300, 120);
            robot.Work(2);
            robot.Recharge();
            Console.WriteLine(robot.CurrentPower);

            Employee employee = new("321");
            employee.Work(2);
            employee.Sleep();
        }
    }
}
