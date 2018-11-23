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
        Queue<string> queue = new Queue<string>();

        void Foo()
        {
            queue.Enqueue("added1");
            queue.Enqueue("added2");
            queue.Enqueue("added3");
            queue.Enqueue("added4");
            queue.Enqueue("added5");
        }

        [TestMethod]
        public void EnqueueTest()
        {
            Foo();

            queue.Enqueue("added6");

            int actual = queue.Count;

            int expected = 6;
            
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DequeueTest()
        {
            Foo();

            string actual = queue.Dequeue();

            string expected = "added1";
            
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PeekTest_AfterDequeue()
        {
            Foo();

            queue.Dequeue();

            string actual = queue.Peek();

            string expected = "added2";
            
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ClearTest_ClearsQueue()
        {
            Foo();

            queue.Clear();

            bool actual = queue.IsEmpty;

            bool expected = true;
            
            Assert.AreEqual(actual, expected);
        }
    }
}
