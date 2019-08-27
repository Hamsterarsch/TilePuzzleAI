using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp
{

    class PriorityQueue<t_Item> where t_Item : Priority
    {
        private SortedList<float, HashSet<t_Item>> list;
        private int count;
        private IEqualityComparer<t_Item> comparer;

        public PriorityQueue()
        {
            list = new SortedList<float, HashSet<t_Item>>();
            count = 0;
            
        }

        public PriorityQueue(IEqualityComparer<t_Item> equalityComparer)
        {
            comparer = equalityComparer;

        }

        public void Enqueue(t_Item item)
        {
            HashSet<t_Item> bucket = null;
            if (list.TryGetValue(item.Priority(), out bucket))
            {
                bucket.Add(item);
            }
            else
            {
                bucket = new HashSet<t_Item>(comparer) { item };
                list.Add(Math.Abs(item.Priority()), bucket);
            }

            ++count;

        }

        public t_Item Dequeue()
        {
            var bucket = list.First();
            var item = bucket.Value.First();
            bucket.Value.Remove(item);

            if (bucket.Value.Count == 0)
            {
                list.RemoveAt(0);
            }

            --count;
            return item;

        }

        public t_Item Peek()
        {
            var bucket = list.First();
            var item = bucket.Value.First();

            return item;

        }

        public int Count()
        {
            return count;

        }

        public bool IsEmpty()
        {
            return count == 0;

        }

        public bool Contains(t_Item item)
        {
            HashSet<t_Item> bucket = null;
            list.TryGetValue(item.Priority(), out bucket);

            if (bucket == null)
            {
                return false;
            }

            return bucket.Contains(item);

        }


    }

}
