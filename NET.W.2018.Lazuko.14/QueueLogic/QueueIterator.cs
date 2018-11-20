using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLogic
{
    /// <summary>
    /// Represent iterator for queue;
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerator{T}" />
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        #region Private fields

        private readonly Queue<T> queue;
        private int count;
        private int index;

        #endregion

        public QueueEnumerator(Queue<T> queue)
        {
            this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
            count = queue.Count;
            index = -1;
        }

        #region Iterator implementation

        public T Current
        {
            get
            {
                if (count == 0) throw new InvalidOperationException();

                if (count == 1) return queue.Head.Data;
                
                Node<T> temp = queue.Head;
                Node<T> tempNext = queue.Head.Next;

                for(int i = 0; i < index; i++)
                {
                    temp = tempNext;
                    tempNext = tempNext.Next;
                }

                return temp.Data;
            }
        }

        object IEnumerator.Current
        {
            get { return (object)Current; }
        }

        public bool MoveNext()
        {
            return ++index < count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose() { }

        #endregion
    }
}