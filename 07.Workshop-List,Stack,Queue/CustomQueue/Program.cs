using CustomQueue;

Queue queue = new Queue();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
queue.Enqueue(5);
queue.Dequeue();
queue.Dequeue();
Console.WriteLine(queue.Peek());
queue.Clear();
queue.Enqueue(10);
queue.Enqueue(11);
queue.Enqueue(12);
queue.Dequeue();
Console.WriteLine(queue.Peek());
queue.ForEach(x => Console.WriteLine(x));
