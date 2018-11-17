using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLogic
{
    public class QueueIterator<T> : IEnumerator<T>
    {
        #region Private fields

        private readonly Queue<T> collection;
        private int index;

        #endregion

        public QueueIterator(Queue<T> collection)
        {
            this.collection = collection ?? throw new ArgumentNullException(nameof(collection));
            this.index = -1;
        }

        #region Iterator implementation

        public T Current
        {
            get
            {
                if (collection.Count == -1) throw new InvalidOperationException();

                return collection.Nodes[index].Data;
            }
        }

        object IEnumerator.Current
        {
            get { return (object)Current; }
        }

        public bool MoveNext()
        {
            return ++index < collection.Nodes.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}