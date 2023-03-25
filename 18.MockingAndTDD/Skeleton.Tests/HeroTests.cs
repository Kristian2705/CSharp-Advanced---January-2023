using NUnit.Framework;
using Moq;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GainsXPCorrectly()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        fakeWeapon
            .Setup(p => p.DurabilityPoints)
            .Returns(5);
        fakeWeapon
            .Setup(p => p.AttackPoints)
            .Returns(5);
        fakeWeapon
            .Setup(p => p.Attack(It.IsAny<ITarget>()));
        Hero hero = new Hero("Kyros", fakeWeapon.Object);
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(p => p.TakeAttack(It.IsAny<int>()));
        fakeTarget
            .Setup(p => p.Health)
            .Returns(0);
        fakeTarget
            .Setup(p => p.GiveExperience())
            .Returns(1);
        fakeTarget
            .Setup(p => p.IsDead())
            .Returns(true);
        hero.Attack(fakeTarget.Object);
        Assert.That(hero.Experience == 1);
    }
}