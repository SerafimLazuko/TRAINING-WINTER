using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLogic
{
    /// <summary>
    /// Custom class Queue;
    /// Provides API for working with queue;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields & Prop

        private Node<T> head;

        private Node<T> tail;
                
        public int Count { get; private set; }

        public Node<T> Head { get => new Node<T>(head.Data); }

        public Node<T> Tail { get => new Node<T>(tail.Data); }

        #endregion

        #region Operations with Queue

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty { get { return Count == 0; } }

        /// <summary>
        /// Enqueues the specified data in thr end of queue.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data) ?? throw new ArgumentNullException(nameof(data));

            if (Count == 0)
            {
                head = node;
                tail = node;
                Count++;
                return;
            }

            if (Count == 1)
            {
                head.Next = node;
                tail = node;
                Count++;
                return;
            }

            tail.Next = node;
            tail = node;
            Count++;
        }

        /// <summary>
        /// Dequeues first element from queue.
        /// </summary>
        /// <returns> returns this Data value</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T output = head.Data;

            if (Count == 1)
            {
                Count--;
                head = null;
                tail = null;
                return output;
            }

            head = head.Next;
            Count--;

            return output;
        }

        /// <summary>
        /// Peeks first element.
        /// </summary>
        /// <returns>First element Data value</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Peek()
        {
            if (Count == 0)
                return default(T);

            return head.Data;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            if (IsEmpty) return;

            while (Count > 0)
            {
                Node<T> temp = head.Next;
                head = null;
                head = temp;
                Count--;
            }

            tail = null;
        }

        #endregion

        #region Ctors

        public Queue() { }

        public Queue(int numberElements)
        {
            while(numberElements > 0)
            {
                Enqueue(default(T));
                Count++;
            }
        }

        public Queue(int numberElements, T data)
        {
            while (numberElements > 0)
            {
                Enqueue(data);
                Count++;
            }
        }

        public Queue(Queue<T> queue)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));

            foreach(var node in queue)
            {
                Enqueue(node);
            }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}