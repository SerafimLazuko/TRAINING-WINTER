using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueLogic;

namespace QueueLogic.Tests
{
    [TestClass]
    public class QueueLogicTests
    {
        Node<string> node1 = new Node<string>("node1");
        Node<string> node2 = new Node<string>("node2");
        Node<string> node3 = new Node<string>("node3");

        List<Node<string>> list = new List<Node<string>>(3);

        void Foo()
        {
            list.Add(node1);
            list.Add(node2);
            list.Add(node3);
        }

        [TestMethod]
        public void EnqueueTest()
        {
            Foo();

            Queue<string> queue = new Queue<string>(list);
            
            queue.Enqueue("added node 4");

            string actual = queue.Nodes[3].Data;

            string expected = "added node 4";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DequeueTest()
        {
            Foo();

            Queue<string> queue = new Queue<string>(list);
            
            string actual = queue.Dequeue();

            string expected = "node1";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PeekTest_AfterDequeue()
        {
            Foo();

            Queue<string> queue = new Queue<string>(list);

            queue.Dequeue();

            string actual = queue.Peek();

            string expected = "node2";

            Assert.AreEqual(actual, expected);
        }
    }
}
