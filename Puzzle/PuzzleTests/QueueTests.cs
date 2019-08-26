using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{

    class DummyNode : Priority
    {
        public int value;

        public DummyNode(int value)
        {
            this.value = value;

        }

        public float Priority()
        {
            return value;

        }


    }

    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void IsSortedByPriority()
        {
            var queue = new PriorityQueue<DummyNode>();

            queue.Enqueue(new DummyNode(2));
            queue.Enqueue(new DummyNode(3));
            queue.Enqueue(new DummyNode(1));

            Assert.IsTrue(queue.Dequeue().value == 1);
            Assert.IsTrue(queue.Dequeue().value == 2);
            Assert.IsTrue(queue.Dequeue().value == 3);

        }

        [TestMethod]
        public void DuplicatePrioritiesPossible()
        {
            var queue = new PriorityQueue<DummyNode>();

            queue.Enqueue(new DummyNode(2));
            queue.Enqueue(new DummyNode(2));

            Assert.IsTrue(queue.Dequeue().value == 2);
            Assert.IsTrue(queue.Dequeue().value == 2);
            
        }

        [TestMethod]
        public void ThrowsWhenEmpty()
        {
            var queue = new PriorityQueue<DummyNode>();

            queue.Enqueue(new DummyNode(2));
            queue.Dequeue();

            try
            {
                queue.Dequeue();
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail();

        }

        [TestMethod]
        public void TracksCount()
        {
            var queue = new PriorityQueue<DummyNode>();

            queue.Enqueue(new DummyNode(1));
            queue.Enqueue(new DummyNode(1));

            Assert.IsTrue(queue.Count() == 2);

            queue.Dequeue();
            queue.Dequeue();

            Assert.IsTrue(queue.IsEmpty());

        }



    }


}
