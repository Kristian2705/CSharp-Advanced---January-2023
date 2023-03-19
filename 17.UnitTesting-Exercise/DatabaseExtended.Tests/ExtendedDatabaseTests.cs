namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people = new Person[] { new Person(12345, "John Doe"), new Person(67890, "Doge") };
        private Person userToFind = new Person(67890, "Doge");
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database(people);
        }

        [Test]
        public void ConstructorCreatesArrayCorrectly()
        {
            Assert.That(database.Count, Is.EqualTo(people.Length), "People weren't added correctly.");
        }

        [Test]
        public void ThrowsWhenThereAreMoreThanSixteenPeople()
        {
            TestDelegate action = () => new Database(new Person(1, "Random1"), new Person(2, "Random2"), new Person(3, "Random3"), new Person(4, "Random4"), new Person(5, "Random5"),
                new Person(6, "Random6"), new Person(7, "Random7"), new Person(8, "Random8"), new Person(9, "Random9"), new Person(10, "Random10"),
                new Person(11, "Random11"), new Person(12, "Random12"), new Person(13, "Random13"), new Person(14, "Random14"),
                new Person(15, "Random15"), new Person(16, "Random16"), new Person(17, "Random17"));
            Assert.Throws<ArgumentException>(action, "Exception was not thrown when trying to add more than 16 people"); 
        }

        [Test]
        public void AddedPerson()
        {
            database.Add(new Person(324, "Krisko"));

            Assert.That(database.Count, Is.EqualTo(people.Length + 1), "New person was not added.");
        }

        [Test]
        public void ThrowsWhenTryingToAddAPersonWhenTheArrayIsFull()
        {
            database = new Database(new Person(1, "Random1"), new Person(2, "Random2"), new Person(3, "Random3"), new Person(4, "Random4"), new Person(5, "Random5"),
                new Person(6, "Random6"), new Person(7, "Random7"), new Person(8, "Random8"), new Person(9, "Random9"), new Person(10, "Random10"),
                new Person(11, "Random11"), new Person(12, "Random12"), new Person(13, "Random13"), new Person(14, "Random14"), 
                new Person(15, "Random15"), new Person(16, "Random16"));

            TestDelegate action = () => database.Add(new Person(324, "Krisko"));

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to add more items than the capacity.");
        }

        [Test]
        public void ThrowsWhenThereIsAPersonWithIdenticalName()
        {
            TestDelegate action = () => database.Add(new Person(100, "John Doe"));

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to add a person with identical name.");
        }

        [Test]
        public void ThrowsWhenThereIsAPersonWithIdenticalID()
        {
            TestDelegate action = () => database.Add(new Person(67890, "Krisko"));

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to add a person with identical ID.");
        }

        [Test]
        public void RemovesPerson()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1), "Person was not removed correctly.");
        }

        [Test]
        public void ThrowsWhenTryingToRemoveAPersonWhenTheArrayIsEmpty()
        {
            database = new Database();

            TestDelegate action = () => database.Remove();

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to remove a person when there are none in the array.");
        }

        [Test]
        public void FindsPersonByUsername()
        {
            Person personFound = database.FindByUsername("Doge");

            Assert.IsTrue(personFound.UserName == userToFind.UserName && personFound.Id == userToFind.Id, "Person with this name was not found.");
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowsWhenNullIsGivenAsAName(string username)
        {
            TestDelegate action = () => database.FindByUsername(username);

            Assert.Throws<ArgumentNullException>(action, "Exception was not thrown when trying to find a person with an empty or null name.");
        }
        [Test]
        public void ThrowsWhenANonExistentNameIsGiven()
        {
            TestDelegate action = () => database.FindByUsername("Stambio");

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when trying to find a person with a non-existent name.");
        }

        [Test]
        public void FindsPersonByID()
        {
            Person personFound = database.FindById(67890);

            Assert.IsTrue(personFound.UserName == userToFind.UserName && personFound.Id == userToFind.Id, "Person with this ID was not found.");
        }

        [Test]
        public void ThrowsWhenNegativeIDIsGiven()
        {
            TestDelegate action = () => database.FindById(-67890);

            Assert.Throws<ArgumentOutOfRangeException>(action, "Exception was not thrown when a negative ID was given.");
        }

        [Test]
        public void ThrowsWhenANonExistentIDIsGiven()
        {
            TestDelegate action = () => database.FindById(21);

            Assert.Throws<InvalidOperationException>(action, "Exception was not thrown when a non-existent ID was given.");
        }
    }
}