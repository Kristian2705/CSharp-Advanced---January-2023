namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private const int InitialArenaCount = 0;
        [SetUp] 
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorCreatesListOfWarriorsCorrectly()
        {
            Assert.That(arena.Count, Is.EqualTo(InitialArenaCount), "Arena was not created correctly.");
        }

        [Test]
        public void EnrollsCorrectly()
        {
            Warrior warrior = new("Diamante", 80, 150);
            arena.Enroll(warrior);
            Assert.IsTrue(arena.Warriors.Contains(warrior) && arena.Count == InitialArenaCount + 1, "Warrior was not enrolled correctly.");
        }

        [Test]
        public void ThrowsWhenTryingToAddEnrolledWarrior()
        {
            Warrior warrior = new("Diamante", 80, 150);
            arena.Enroll(warrior);
            TestDelegate action = () => arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(action, "Tried to enroll an already enrolled warrior.");
        }

        [Test]
        public void FightCorrectly()
        {
            Warrior first = new("Kyros", 100, 200);
            Warrior second = new("Diamante", 80, 150);
            arena.Enroll(first);
            arena.Enroll(second);
            int expectedFirstHP = first.HP - second.Damage;
            int expectedSecondHP = second.HP - first.Damage;
            arena.Fight(first.Name, second.Name);
            Assert.IsTrue(first.HP == expectedFirstHP && second.HP == expectedSecondHP);
            
        }

        [TestCase("Sabo", "Burgess")]
        [TestCase("Kyros", "Burgess")]
        [TestCase("Sabo", "Diamante")]
        public void ThrowsWhenMissingWarriorsFight(string firstName, string secondName)
        {
            Warrior first = new("Kyros", 100, 200);
            Warrior second = new("Diamante", 80, 150);
            arena.Enroll(first);
            arena.Enroll(second);
            TestDelegate action = () => arena.Fight(firstName, secondName);
            Assert.Throws<InvalidOperationException>(action, "Missing warriors tried to fight.");
        }
    }
}
