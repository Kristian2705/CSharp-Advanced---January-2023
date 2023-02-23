using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new("The Ageless", 100);
            Console.WriteLine(bladeKnight);
        }
    }
}