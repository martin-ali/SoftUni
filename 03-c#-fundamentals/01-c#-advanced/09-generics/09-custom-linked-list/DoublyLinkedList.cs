using System;
using System.Collections;
using System.Collections.Generic;

namespace _09_custom_linked_list
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<G>
        {
            public ListNode(G value)
            {
                this.Value = value;
            }

            public G Value { get; private set; }

            public ListNode<G> NextNode { get; set; }

            public ListNode<G> PreviousNode { get; set; }
        }

        private ListNode<T> head;

        private ListNode<T> tail;

        public int Count { get; private set; } = 0;

        private void ThrowIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                var oldHead = this.head;

                newHead.NextNode = oldHead;
                oldHead.PreviousNode = newHead;

                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                var oldTail = this.tail;

                newTail.PreviousNode = oldTail;
                oldTail.NextNode = newTail;

                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            this.ThrowIfEmpty();

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            this.ThrowIfEmpty();

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var element in this)
            {
                action(element);
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            var index = 0;
            foreach (var element in this)
            {
                array[index++] = element;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var element = this.head;
            while (element != null)
            {
                yield return element.Value;

                element = element.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}