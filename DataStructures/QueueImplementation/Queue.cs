﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueImplementation
{
    public class Queue<T> : IQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this._head;

            while (currentNode != null)
            {
                var currentItem = currentNode.Value;

                if (currentItem.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this._head == null)
            {
                this._head = newNode;
            }
            else
            {
                var currentNode = this._head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.ValidateEmptyQueue();

            var removedItem = this._head.Value;
            this._head = this._head.Next;


            this.Count--;

            return removedItem;
        }

        public T Peek()
        {
            this.ValidateEmptyQueue();

            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateEmptyQueue()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
    }
}
