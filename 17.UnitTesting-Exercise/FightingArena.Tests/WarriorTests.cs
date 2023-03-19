namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const string Name = "Kyros";
        private const int Damage = 100;
        private const int HP = 200;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(Name, Damage, HP);
        }

        [Test]
        public void ConstructorCreatesWarriorCorrectly()
        {
            Assert.IsTrue(warrior.Name == Name && warrior.Damage == Damage && warrior.HP == HP);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ThrowsWhenTryingToCreateAWarriorWithInvalidName(string name)
        {
            TestDelegate action = () => warrior = new Warrior(name, Damage, HP);
            Assert.Throws<ArgumentException>(action, "Tried to create a warrior with invalid name.");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsWhenTryingToCreateAWarriorWithInvalidDamage(int damage)
        {
            TestDelegate action = () => warrior = new Warrior(Name, damage, HP);
            Assert.Throws<ArgumentException>(action, "Tried to create a warrior with invalid damage.");
        }

        [TestCase(-1)]
        public void ThrowsWhenTryingToCreateAWarriorWithInvalidHP(int hp)
        {
            TestDelegate action = () => warrior = new Warrior(Name, Damage, hp);
            Assert.Throws<ArgumentException>(action, "Tried to create a warrior with invalid HP.");
        }

        [TestCase(80, 150)]
        [TestCase(100, 100)]
        [TestCase(100, 90)]
        public void WarriorAttacksCorrectly(int damage, int hp)
        {
            Warrior secondWarrior = new("Diamante", damage, hp);
            warrior.Attack(secondWarrior);
            Assert.IsTrue(warrior.HP == HP - secondWarrior.Damage && (secondWarrior.HP == hp - warrior.Damage || secondWarrior.HP == 0), "Warriors didn't fight correctly.");
        }

        [TestCase(30)]
        [TestCase(25)]
        public void ThrowsWhenTryingToAttackWithInvalidHP(int hp)
        {
            warrior = new Warrior(Name, Damage, hp);
            Warrior secondWarrior = new("Diamante", 80, 150);
            TestDelegate action = () => warrior.Attack(secondWarrior);
            Assert.Throws<InvalidOperationException>(action, "First warrior tried to attack with less HP than required.");
        }

        [TestCase(30)]
        [TestCase(25)]
        public void ThrowsWhenBeingAttackedWithInvalidHP(int hp)
        {
            Warrior secondWarrior = new("Diamante", 80, hp);
            TestDelegate action = () => warrior.Attack(secondWarrior);
            Assert.Throws<InvalidOperationException>(action, "First warrior tried to attack second warrior who has less HP than required.");
        }

        [Test]
        public void ThrowsWhenTryingToAttackAStrongerEnemy()
        {
            Warrior secondWarrior = new("Diamante", 210, 150);
            TestDelegate action = () => warrior.Attack(secondWarrior);
            Assert.Throws<InvalidOperationException>(action, "First warrior tried to attack a stronger enemy.");
        }
    }
}