
namespace QueueLogic
{
    /// <summary>
    /// Class for storing Data value,
    /// and a pointer to the next element;
    /// </summary>
    /// <typeparam name="T"> type of Data</typeparam>
    public class Node<T>
    {
        public T Data { get; set; }
        internal Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="data">The data for Data field.</param>
        public Node(T data)
        {
            Data = data;
        }
    }
}
