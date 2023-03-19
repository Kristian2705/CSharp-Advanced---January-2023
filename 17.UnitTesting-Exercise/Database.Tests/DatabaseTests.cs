namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Serialization;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }
        [Test]
        public void ConstructorCreatesArrayCorrectly()
        {
            TestDelegate action = () => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            Assert.Throws<InvalidOperationException>(action, "The array cannot have more than 16 items in it.");
        }

        [Test]
        public void AddsANewElement()
        {
            database.Add(16);
            Assert.AreEqual(16, database.Count, "Element was not added.");
        }

        [Test]
        public void ThrowsWhenTryingToAddMoreItemsThanTheCapacity()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            TestDelegate action = () => database.Add(17);
            Assert.Throws<InvalidOperationException>(action, "An item was added despite that the array was already full.");
        }

        [Test]
        public void RemovesANewElement()
        {
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(14));
        }

        [Test]
        public void ThrowsWhenTryingToRemoveAnItemWhenThereAreNone()
        {
            database = new();
            TestDelegate action = () => database.Remove();
            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to remove from an empty array.");
        }

        [Test]
        public void ReceivedArray()
        {
            Assert.That(database.Fetch(), Is.EqualTo(expectedArray), "The received array was not the same.");
        }
    }
}
