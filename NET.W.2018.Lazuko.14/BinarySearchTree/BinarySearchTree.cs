using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// class BST, provides API for binary search and
    /// representation data in binary tree form;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        #region Fields & Prop

        private Node TreeRoot;

        private IComparer<T> comparer;

        public IComparer<T> Comparer
        {
            get => comparer;
            private set
            {
                if (TreeRoot != null) throw new InvalidOperationException("Cannot change the comparator while the collection is non-empty");
                comparer = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        #endregion

        #region Traversal

        /// <summary>
        /// PreOrder traversal algorithm for binary tree.
        /// </summary>
        /// <value>
        /// The pre order.
        /// </value>
        public IEnumerable<T> PreOrder
        {
            get
            {
                Node prev = null;
                Node current = TreeRoot;
                Node next = null;

                while(current != null)
                {
                    if(prev == null || prev == current.Parent)
                    {
                        yield return current.data;
                        prev = current;
                        next = current.Left;
                    }

                    if(next == null || prev == current.Left)
                    {
                        prev = current;
                        next = current.Right;
                    }

                    if(next == null || prev == current.Right)
                    {
                        prev = current;
                        next = current.Parent;
                    }

                    current = next;
                }
            }
        }

        /// <summary>
        /// InOrder traversal algorithm for binary tree.
        /// </summary>
        /// <value>
        /// The in order.
        /// </value>
        public IEnumerable<T> InOrder
        {
            get
            {
                Node prev = null;
                Node current = TreeRoot;
                Node next = null;

                while (current != null)
                {
                    if (prev == null || prev == current.Parent)
                    {
                        prev = current;
                        next = current.Left;
                    }

                    if (next == null || prev == current.Left)
                    {
                        yield return current.data;
                        prev = current;
                        next = current.Right;
                    }

                    if (next == null || prev == current.Right)
                    {
                        prev = current;
                        next = current.Parent;
                    }

                    current = next;
                }
            }
        }

        /// <summary>
        /// PostOrder traversal algorithm for binary tree.
        /// </summary>
        /// <value>
        /// The post order.
        /// </value>
        public IEnumerable<T> PostOrder
        {
            get
            {
                Node prev = null;
                Node current = TreeRoot;
                Node next = null;

                while (current != null)
                {
                    if (prev == null || prev == current.Parent)
                    {
                        prev = current;
                        next = current.Right;
                    }

                    if (next == null || prev == current.Right)
                    {
                        yield return current.data;
                        prev = current;
                        next = current.Left;
                    }

                    if(next == null || prev == current.Left)
                    {
                        prev = current;
                        next = current.Parent;
                    }

                    current = next;
                }
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Gets a value indicating whether this tree is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty { get => TreeRoot == null; }

        /// <summary>
        /// Algorithm adds a new node to the tree.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Add(T data)
        {
            if (IsEmpty)
            {
                TreeRoot = new Node(data);
                return;
            }

            Node node = new Node(data);
            
            Node temp = TreeRoot;
            
            while (temp != null)
            {
                int compareResult = Comparer.Compare(data, temp.data);

                if (compareResult < 0)
                {
                    if (temp.Left != null)
                    {
                        temp = temp.Left;
                    }
                    else
                    {
                        temp.Left = node;
                        node.Parent = temp;
                        return;
                    }
                }
                else
                {
                    if(temp.Right != null)
                    {
                        temp = temp.Right;
                    }
                    else
                    {
                        temp.Right = node;
                        node.Parent = temp;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the minimal element of tree
        /// </summary>
        /// <returns></returns>
        public T GetMinimum()
        {
            if(TreeRoot == null)
            {
                return default(T);
            }

            Node node = TreeRoot;

            while(node != null)
            {
                node = node.Left;
            }

            return node.data;
        }

        /// <summary>
        /// Gets the maximal element of tree
        /// </summary>
        /// <returns></returns>
        public T GetMaximum()
        {
            if (TreeRoot == null)
            {
                return default(T);
            }

            Node node = TreeRoot;

            while (node != null)
            {
                node = node.Right;
            }

            return node.data;
        }

        /// <summary>
        /// Clears this tree.
        /// </summary>
        public void Clear() => TreeRoot = null;

        /// <summary>
        /// Checks whether such an element is contained in a tree.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item) => (Find(item) != null);

        #endregion

        #region Private API

        /// <summary>
        /// Binary search alghorithm
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Tree is empty!</exception>
        private Node Find(T data)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Tree is empty!");

            Node node = TreeRoot;

            while (node != null)
            {
                int result = Comparer.Compare(data, node.data);

                if (result == 0)
                    return node;

                else if (result < 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            return null;
        }

        #endregion

        #region IEnumerator

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in InOrder) yield return element;
        }

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            TreeRoot = null;
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="tree">The tree.</param>
        public BinarySearchTree(BinarySearchTree<T> tree)
        {
            foreach (T node in tree.PreOrder) Add(node);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public BinarySearchTree(IEnumerable<T> values) : this()
        {
            foreach (T item in values) Add(item);
        }

        #endregion

        /// <summary>
        /// provides instance for storing data and information about 
        /// Parent, LesserChild, GreaterChild;
        /// </summary>
        private class Node
        {
            public Node Parent
            {
                get => Parent;
                set { Parent = value; }
            }
            public Node Left
            {
                get => Left;
                set{ Left = value;}
            }
            public Node Right
            {
                get => Right;
                set { Right = value; }
            }

            public T data;
            
            public Node(T data)
            {
                this.data = data;
                Parent = Left = Right = null;
            }
        }
    }
}