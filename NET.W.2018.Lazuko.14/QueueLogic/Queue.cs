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

        private List<Node<T>> nodes;

        internal Node<T> head;

        internal Node<T> tail;

        public List<Node<T>> Nodes
        {
            get { return nodes; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                for (int i = 0; i < value.Count; i++)
                {
                    nodes.Add(value[i]);

                    if (i == 0 && Count == 1)
                    {
                        head = value[i];
                        head.Next = value[i + 1];
                    }

                    if (i > 0 && i < value.Count - 1)
                        nodes[i].Next = value[i + 1];

                    if (i == value.Count - 1)
                        tail = value[i];
                }
            }
        }

        public int Count { get { return nodes.Count; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="array">The array of Nodes.</param>
        public Queue(List<Node<T>> array)
        {
            nodes = new List<Node<T>>();
            Nodes = array;
        }

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
            if (data == null)
                throw new ArgumentNullException();

            Node<T> node = new Node<T>(data);

            Node<T> temp = tail;

            tail = node;

            nodes.Add(node);

            if (Count == 0)
                head = tail;
            else
                temp.Next = tail;
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

            Node<T> temp = head.Next;

            nodes.Remove(head);

            head = temp;

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
                throw new InvalidOperationException();

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
                int i = Count;
                nodes.RemoveAt(--i);
            }

            head = null;
            tail = null;
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}