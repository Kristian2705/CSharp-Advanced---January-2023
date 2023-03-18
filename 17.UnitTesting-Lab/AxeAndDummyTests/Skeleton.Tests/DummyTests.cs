using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private const int InitialHealth = 10;
        private const int DeadHealth = 0;
        private const int InitialXP = 3;
        private const int DamageToTake = 5;
        private const int ResultAfterTakenDamage = 5;
        [SetUp]
        public void SetUp()
        {
            dummy = new(DeadHealth, InitialXP);
        }
        [Test]
        public void DummyLoosesHealthUponAttack()
        {
            dummy = new(InitialHealth, InitialHealth);

            dummy.TakeAttack(DamageToTake);

            Assert.That(dummy.Health, Is.EqualTo(ResultAfterTakenDamage), "Dummy didn't take damage correctly!");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionUponAttack()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(DamageToTake), "Dead dummy is not supposed to take damage!");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Assert.That(dummy.GiveExperience(), Is.EqualTo(InitialXP), "Dead dummy didn't get XP correctly!");
        }

        [Test]
        public void AliveDummyDoesNotGiveXP()
        {
            dummy = new(InitialHealth, InitialXP);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy is not supposed to get XP!");
        }
    }
}