using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public ListNode<T> Head { get; set; }

        public ListNode<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T value)
        {
            Count++;
            ListNode<T> node = new ListNode<T>(value);
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddLast(T value)
        {
            Count++;
            ListNode<T> node = new ListNode<T>(value);
            if (Tail == null)
            {
                Tail = node;
                Head = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
                //Head = null;
                //Tail = null;
                //return;
            }
            ListNode<T> oldHead = Head;
            Head = oldHead.Next;
            if(Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return oldHead.Value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
                //Head = null;
                //Tail = null;
                //return;
            }
            ListNode<T> oldTail = Tail;
            Tail = oldTail.Previous;
            if(Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return oldTail.Value;
        }

        public void ForEach(Action<T> callback)
        {
            ListNode<T> currNode = Head;
            while (currNode != null)
            {
                callback(currNode.Value);
                currNode = currNode.Next;
            }
        }

        //public void ForEachReverse(Action<T> callback)
        //{
        //    Node<T> currNode = Tail;
        //    while (currNode != null)
        //    {
        //        callback(currNode.Value);
        //        currNode = currNode.Previous;
        //    }
        //}

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            int i = 0;
            ForEach(x => arr[i++] = x);
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currNode = Head;
            while (currNode != null)
            {
                var currValue = currNode.Value;
                currNode = currNode.Next;
                yield return currValue;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
