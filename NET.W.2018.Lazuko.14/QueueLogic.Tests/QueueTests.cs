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

        Queue<string> queue = new Queue<string>();

        void Foo()
        {
            queue.Enqueue(node1.Data);
            queue.Enqueue(node2.Data);
            queue.Enqueue(node3.Data);
        }

        [TestMethod]
        public void EnqueueTest()
        {
            Foo();

            queue.Enqueue("added node 4");

            int actual = queue.Count;

            int expected = 4;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DequeueTest()
        {
            Foo();
                        
            string actual = queue.Dequeue();

            string expected = "node1";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PeekTest_AfterDequeue()
        {
            Foo();

            queue.Dequeue();

            string actual = queue.Peek();

            string expected = "node2";

            Assert.AreEqual(actual, expected);
        }
    }
}
