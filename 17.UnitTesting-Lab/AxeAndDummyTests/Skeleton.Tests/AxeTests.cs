using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;

        private const int InitialAxeAttack = 10;
        private const int InitialAxeDurability = 10;
        private const int InitialDummyHealth = 10;
        private const int InitialDummyXP = 10;
        private const int AxeWithoutDurability = 0;
        private const int AxeDurabilityAfterAnAttack = 9;

        [SetUp]
        public void SetUp()
        {
            axe = new(InitialAxeAttack, InitialAxeDurability);
        }

        [Test]
        public void AxeLoosesDurabilityOnHit()
        {   
            axe.Attack(new Dummy(InitialDummyHealth, InitialDummyXP));

            Assert.AreEqual(AxeDurabilityAfterAnAttack, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]

        public void CannotAttackWithABrokenWeapon()
        {
            axe = new(InitialAxeAttack, AxeWithoutDurability);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(InitialDummyHealth, InitialDummyXP)), "Axe attacked when it had no durability.");
        }
    }
}