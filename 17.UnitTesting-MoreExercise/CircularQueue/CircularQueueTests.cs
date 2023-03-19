using Collections;

namespace CircularQueue
{
    public class Tests
    {

        [Test]
        public void Test_CircularQueue_ConstructorDefault()
        {
            var queue = new CircularQueue<int>();
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity > 0);
            Assert.That(queue.StartIndex == 0);
            Assert.That(queue.EndIndex == 0);
        }

        [Test]
        public void Test_CircularQueue_ConstructorWithCapacity()
        {
            var queue = new CircularQueue<int>(9);
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity == 9);
            Assert.That(queue.StartIndex == 0);
            Assert.That(queue.EndIndex == 0);
        }

        [Test]
        public void Test_CircularQueue_Enqueue()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Assert.That(queue.ToString() == "[10, 20, 30]");
            Assert.That(queue.Count == 3);
            Assert.That(queue.Capacity >= queue.Count);
        }
        [Test]
        public void Test_CircularQueue_EnqueueWithGrow()
        {
            var queue = new CircularQueue<int>();
            for(int i = 1; i <= 9; i++)
            {
                queue.Enqueue(i);
            }
            Assert.That(queue.ToString() == "[1, 2, 3, 4, 5, 6, 7, 8, 9]");
            Assert.That(queue.Count == 9);
            Assert.That(queue.Capacity == 16);
        }

        [Test]
        public void Test_CircularQueue_Dequeue()
        {
            var queue = new CircularQueue<int>();
            for (int i = 1; i <= 3; i++)
            {
                queue.Enqueue(i);
            }
            queue.Dequeue();
            queue.Dequeue();
            Assert.That(queue.ToString() == "[3]");
            Assert.That(queue.Count == 1);
            Assert.That(queue.Capacity >= queue.Count);
        }

        [Test]
        public void Test_CircularQueue_DequeueEmpty()
        {
            var queue = new CircularQueue<int>();
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity >= queue.Count);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Test_CircularQueue_EnqueueDequeueWithRangeCross()
        {
            var queue = new CircularQueue<int>(5);
            for (int i = 1; i <= 3; i++)
            {
                queue.Enqueue(i);
            }
            var firstElement = queue.Dequeue();
            Assert.That(firstElement, Is.EqualTo(1));
            var secondElement = queue.Dequeue();
            Assert.That(secondElement, Is.EqualTo(2));
            for(int i = 4; i <= 6; i++)
            {
                queue.Enqueue(i);
            }
            Assert.That(queue.ToString() == "[3, 4, 5, 6]");
            Assert.That(queue.Count == 4);
            Assert.That(queue.Capacity == 5);
            Assert.That(queue.StartIndex > queue.EndIndex);
        }

        [Test]
        public void Test_CircularQueue_Peek()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.That(queue.Peek() == 1);
            Assert.That(queue.ToString() == "[1, 2, 3]");
            Assert.That(queue.Count == 3);
            Assert.That(queue.Capacity >= queue.Count);
        }

        [Test]
        public void Test_CircularQueue_PeekEmpty()
        {
            var queue = new CircularQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity >= queue.Count);
        }

        [Test]
        public void Test_CircularQueue_ToArray()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            var array = queue.ToArray();
            CollectionAssert.AreEqual(new int[] { 10, 20, 30 }, array);
        }

        [Test]
        public void Test_CircularQueue_ToArrayWithRangeCross()
        {
            var queue = new CircularQueue<int>(5);
            for (int i = 1; i <= 3; i++)
            {
                queue.Enqueue(i);
            }
            var firstElement = queue.Dequeue();
            Assert.That(firstElement, Is.EqualTo(1));
            var secondElement = queue.Dequeue();
            Assert.That(secondElement, Is.EqualTo(2));
            for (int i = 4; i <= 6; i++)
            {
                queue.Enqueue(i);
            }
            Assert.That(queue.ToString() == "[3, 4, 5, 6]");
            Assert.That(queue.Count == 4);
            Assert.That(queue.Capacity == 5);
            Assert.That(queue.StartIndex > queue.EndIndex);
            var array = queue.ToArray();
            CollectionAssert.AreEqual(new int[] { 3, 4, 5, 6 }, array);
        }
        [Test]
        public void Test_CircularQueue_ToString()
        {
            var queue = new CircularQueue<int>();
            for (int i = 1; i <= 3; i++)
            {
                queue.Enqueue(i);
            }
            Assert.That(queue.ToString() == "[1, 2, 3]");
        }

        [Test]
        public void Test_CircularQueue_MultipleOperations()
        {
            const int initialCapacity = 2;
            const int iterationsCount = 300;
            var queue = new CircularQueue<int>(initialCapacity);
            int addedCount = 0;
            int removedCount = 0;
            int counter = 0;
            for(int i = 0; i < iterationsCount; i++)
            {
                Assert.That(queue.Count == addedCount - removedCount);
                for(int j = 0; j < 2; j++)
                {
                    queue.Enqueue(++counter);
                    addedCount++;
                    Assert.That(queue.Count == addedCount - removedCount);
                }
                var firstElement = queue.Peek();
                Assert.That(firstElement == removedCount + 1);
                var removedElement = queue.Dequeue();
                removedCount++;
                Assert.That(removedElement == removedCount);
                Assert.That(queue.Count == addedCount - removedCount);
                var expectedElements = Enumerable.Range(removedCount + 1, addedCount - removedCount).ToArray();
                var expectedStr = "[" + string.Join(", ", expectedElements) + "]";
                var queueAsArray = queue.ToArray();
                var queueAsString = queue.ToString();
                CollectionAssert.AreEqual(expectedElements, queueAsArray);
                Assert.AreEqual(expectedStr, queueAsString);
                Assert.That(queue.Capacity >= queue.Count);
            }
            Assert.That(queue.Capacity > initialCapacity);
        }
        [Test]
        [Timeout(500)]
        public void Test_CircularQueue_1MillionItems()
        {
            const int iterationsCount = 1000000;
            var queue = new CircularQueue<int>();
            int addedCount = 0;
            int removedCount = 0;
            int counter = 0;
            for(int i = 0; i < iterationsCount / 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    queue.Enqueue(++counter);
                    addedCount++;
                }
                queue.Dequeue();
                removedCount++;
            }
            Assert.That(queue.Count == addedCount - removedCount);
        }
    }
}