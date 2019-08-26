using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp
{

    class PriorityQueue<t_Item> where t_Item : Priority
    {
        private SortedList<float, List<t_Item>> list;
        private int count;

        public PriorityQueue()
        {
            list = new SortedList<float, List<t_Item>>();
            count = 0;

        }

        public void Enqueue(t_Item item)
        {
            List<t_Item> bucket = null;
            if (list.TryGetValue(item.Priority(), out bucket))
            {
                bucket.Add(item);
            }
            else
            {
                bucket = new List<t_Item> { item };
                list.Add(item.Priority(), bucket);

            }

            ++count;

        }

        public t_Item Dequeue()
        {
            var bucket = list.First();
            var item = bucket.Value.First();
            bucket.Value.RemoveAt(0);

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

    }

}
