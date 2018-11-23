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

        private T[] queue;
        private int capacity;
        private const int defaultCapacity = 8;
        private int first;
        private int last;
        private int version;
        
        public int Count { get; private set; }
        
        #endregion

        #region Operations with Queue

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if Count == 0; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty { get { return Count == 0; } }

        /// <summary>
        /// Enqueues the specified data in the end of queue.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Enqueue(T data)
        {
            if (Count == 0)
            {
                queue[0] = data;
                ++Count;
                ++version;
                return;
            }

            if (IsFull()) Resize();

            queue[(++last) % capacity] = data;

            ++Count;

            ++version;
        }

        /// <summary>
        /// Dequeues first element from queue.
        /// </summary>
        /// <returns> returns this Data value</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty!");

            T output = queue[(first) ];

            queue[(first) % capacity] = default(T);

            --Count;

            ++first;

            ++version;

            return output; 
        }

        /// <summary>
        /// Peeks first element.
        /// </summary>
        /// <returns>First element Data value</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public T Peek() => queue[(first) % capacity];
        
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            queue = null;
            first = 0;
            last = 0;
            capacity = 0;
            Count = 0;
        }
        
        private bool IsFull() => first == (last + 1) % capacity;

        private void Resize()
        {
            T[] bigger = new T[capacity * 2];

            Count = 0;

            for (int i = 0; i < queue.Length; i++)
            {
                bigger[i] = queue[(first++) % capacity];
                last = i;
                ++Count;
            }

            queue = bigger;
            capacity *= 2;
            first = 0;
        }

        #endregion

        #region Ctors

        public Queue()
        {
            queue = new T[defaultCapacity];
            capacity = defaultCapacity;
            first = 0;
            version = 0;
            Count = 0;
        }

        public Queue(int capacity) : this()
        {
            queue = new T[capacity];
            this.capacity = capacity;
        }

        public Queue(int capacity, T data) : this(capacity)
        {
            if (data.Equals(default(T)))
                return;

            for (int i = 0; i < this.capacity; i++)
            {
                queue[i] = data;
                Count++;
            }

            last = queue.Length - 1;
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

        #region IEnumerator

        struct QueueEnumerator<T> : IEnumerator<T>
        {
            #region Private fields

            private readonly Queue<T> queue;
            
            private int version;
            private int index;
            private int step;

            #endregion

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
                
                version = queue.version;

                index = queue.first;

                step = 0;
            }

            #region Iterator implementation

            public T Current
            {
                get
                {
                    return queue.queue[(index++) % queue.capacity];
                }
            }

            object IEnumerator.Current
            {
                get { return (object)Current; }
            }

            public bool MoveNext()
            {
                if (queue.version != version)
                    throw new InvalidOperationException("collection was changed!");

                return step++ < queue.Count;
            }

            public void Reset()
            {
                index = --queue.first;
            }

            public void Dispose() { }

            #endregion
        }

        #endregion
    }
}