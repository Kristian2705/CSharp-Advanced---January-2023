using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestsForCollections
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var collection = new Collection<int>(1);
            Assert.That(collection.ToString() == "[1]");
            Assert.That(collection.Count == 1);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6]");
            Assert.That(collection.Count == 6);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var collection = new Collection<int>();
            Assert.That(collection.ToString() == "[]");
            Assert.That(collection.Count == 0);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var collection = new Collection<int>(1, 2, 3);
            Assert.That(collection.ToString() == "[1, 2, 3]");
            Assert.That(collection.Count == 3);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_Add()
        {
            var collection = new Collection<int>(1, 2, 3);
            collection.Add(4);
            collection.Add(5);
            collection.Add(6);
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6]");
            Assert.That(collection.Count == 6);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var collection = new Collection<int>(1, 2, 3);
            collection.AddRange(4, 5, 6);
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6]");
            Assert.That(collection.Count == 6);
            Assert.That(collection.Capacity > 0);
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            collection.AddRange(7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]");
            Assert.That(collection.Count == 17);
            Assert.That(collection.Capacity == 32);
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            for(int i = 7; i <= 17; i++)
            {
                collection.Add(i);
            }
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]");
            Assert.That(collection.Count == 17);
            Assert.That(collection.Capacity == 32);
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var collection = new Collection<int>(1, 2, 3);
            Assert.That(collection.Count == 3);
            collection.Clear();
            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            collection.Exchange(0, collection.Count - 1);
            Assert.That(collection[0] == 6 && collection[5] == 1);
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            TestDelegate action = () => collection.Exchange(0, collection.Count);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            collection.Exchange(collection.Count / 2 - 1, collection.Count / 2);
            Assert.That(collection[collection.Count / 2 - 1] == 4 && collection[collection.Count / 2] == 3);
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            Assert.That(collection[4] == 5);
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6);
            Assert.Throws<ArgumentOutOfRangeException>(() => collection[6] = 10);
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var collection = new Collection<int>(1, 2, 3);
            collection.InsertAt(collection.Count, 4);
            Assert.That(collection[3] == 4);
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var collection = new Collection<int>(1, 2, 3);
            TestDelegate action = () => collection.InsertAt(4, 4);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var collection = new Collection<int>(1, 2, 3);
            int initialCollectionCount = collection.Count;
            collection.InsertAt(initialCollectionCount / 2, 10);
            Assert.That(collection[initialCollectionCount / 2] == 10);
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var collection = new Collection<int>(1, 2, 3);
            collection.InsertAt(0, 10);
            Assert.That(collection[0] == 10);
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var collection = new Collection<int>(1, 2, 3);
            for(int i = 4; i <= 16; i++)
            {
                collection.Add(i);
            }
            collection.InsertAt(16, 17);
            Assert.That(collection[16] == 17);
            Assert.That(collection.Capacity == 32);
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            var collection = new Collection<int>(1, 2, 3);
            for(int i = 0; i < 3; i++)
            {
                collection.RemoveAt(0);
            }
            Assert.That(collection.ToString() == "[]");
            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var collection = new Collection<int>(1, 2, 3);
            int initialCollectionCount = collection.Count;
            collection.RemoveAt(initialCollectionCount - 1);
            Assert.That(collection.ToString() == "[1, 2]");
            Assert.That(collection.Count == initialCollectionCount - 1);
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var collection = new Collection<int>(1, 2, 3);
            TestDelegate action = () => collection.RemoveAt(-1);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5);
            int initialCollectionCount = collection.Count;
            collection.RemoveAt(initialCollectionCount / 2);
            Assert.That(collection.ToString() == "[1, 2, 4, 5]");
            Assert.That(collection.Count == initialCollectionCount - 1);
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var collection = new Collection<int>(1, 2, 3);
            int initialCollectionCount = collection.Count;
            collection.RemoveAt(0);
            Assert.That(collection.ToString() == "[2, 3]");
            Assert.That(collection.Count == initialCollectionCount - 1);
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var collection = new Collection<int>(1, 2, 3);
            collection[1] = 10;
            Assert.That(collection.ToString() == "[1, 10, 3]");
            Assert.That(collection[1] == 10);
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var collection = new Collection<int>(1, 2, 3);
            Assert.Throws<ArgumentOutOfRangeException>(() => collection[-1] = 10);
        }
        [Test]
        public void Test_Collection_ToStringCollectionOfCollections()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5);
            collection.AddRange(new[] { 6, 7, 8, 9, 10 });
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]");
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var collection = new Collection<int>();
            Assert.That(collection.ToString() == "[]");
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5);
            Assert.That(collection.ToString() == "[1, 2, 3, 4, 5]");
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var collection = new Collection<int>(1000);
            Assert.That(collection.ToString() == "[1000]");
        }

        [Test]
        [Timeout(500)]
        public void Test_Collection_1MillionItems()
        {
            const int IterationsCounter = 1000000;
            var collection = new Collection<int>();
            int itemsAdded = 0;
            for(int i = 0; i < IterationsCounter; i++)
            {
                collection.Add(++itemsAdded);
            }
            Assert.That(collection.Count == itemsAdded);
        }
    }
}
