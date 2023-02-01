using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(int value)
        {
            Count++;
            Node node = new Node(value);
            if(Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddLast(int value)
        {
            Count++;
            Node node = new Node(value);
            if(Tail == null)
            {
                Tail = node;
                Head = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public void RemoveFirst()
        {
            Count--;
            if(Head.Next == null)
            {
                Head = null;
                Tail = null;
                return;
            }
            Node oldHead = Head;
            Head = oldHead.Next;
            oldHead.Next = null;
            Head.Previous = null;
        }

        public void RemoveLast()
        {
            Count--;
            if(Tail.Previous == null)
            {
                Head = null;
                Tail = null;
                return;
            }
            Node oldTail = Tail;
            Tail = oldTail.Previous;
            oldTail.Previous = null;
            Tail.Next = null;
        }

        public void ForEach(Action<int> callback)
        {
            Node currNode = Head;
            while(currNode != null)
            {
                callback(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public void ForEachReverse(Action<int> callback)
        {
            Node currNode = Tail;
            while(currNode != null)
            {
                callback(currNode.Value);
                currNode = currNode.Previous;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Count];
            int i = 0;
            ForEach(x => arr[i++] = x);
            return arr;
        }
    }
}
