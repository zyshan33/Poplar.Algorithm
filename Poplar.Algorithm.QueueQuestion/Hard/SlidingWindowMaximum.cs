using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.QueueQuestion
{
    internal class SlidingWindowMaximum
    {
        /// <summary>
        /// 用双端队列处理。
        ///
        /// 在从左到右遍历的时候，当前遍历到的值的生存周期永远比之前遍历过的数的生命周期更长。
        /// 所以在从队尾入队的时候，判断当前遍历到值是否比队尾的值更大，如果更大，又因为当前值比队尾值生命周期长，所以把队尾的值删除，删除完成之后，再和新队尾比较，直到队列为空或者队列里的值都比当前值大。
        /// 根据上面的操作，可以保证队列最前端存放的永远会是当前窗口的最大值。
        /// 每次遍历的时候需要判断队头的值是否有效。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindowTwo(int[] nums, int k)
        {
            var container = new int[nums.Length - k + 1];
            var deque = new SlidingWindowDeque<int>(k);
            for (var i = 0; i < k - 1; i++)
            {
                while (!deque.IsEmpty() && nums[deque.GetLast()] < nums[i])
                    deque.DeleteLast();
                deque.InsertLast(i);
            }
            for (var i = k - 1; i < nums.Length; i++)
            {
                if (deque.GetFront() < i - k + 1)
                    deque.DeleteFront();
                while (!deque.IsEmpty() && nums[deque.GetLast()] < nums[i])
                    deque.DeleteLast();
                deque.InsertLast(i);
                container[i - k + 1] = nums[deque.GetFront()];
            }
            return container;
        }

        /// <summary>
        /// 暴力解法。
        /// 让窗口向右滑动，每滑动一次都遍历窗口中所有的元素，得到一个最大值。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindowOne(int[] nums, int k)
        {
            var container = new int[nums.Length - k + 1];
            for (var i = 0; i < nums.Length - k + 1; i++)
            {
                var max = nums[i];
                for (var j = i + 1; j < i + k; j++)
                {
                    max = Math.Max(max, nums[j]);
                }
                container[i] = max;
            }
            return container;
        }

        public class SlidingWindowDeque<T>
        {
            private readonly T[] _dataSet;
            public int MaxSize { get; }
            private int pFront;
            private int pRear;
            public int Length { get; private set; }

            public SlidingWindowDeque(int k = 0)
            {
                MaxSize = k;
                _dataSet = new T[k];
                pFront = 0;
                pRear = 0;
                Length = 0;
            }

            public bool InsertFront(T value)
            {
                if (Length == MaxSize)
                    return false;
                pFront--;
                pFront = (pFront + MaxSize) % MaxSize;
                _dataSet[pFront] = value;
                Length++;
                return true;
            }

            public bool InsertLast(T value)
            {
                if (Length == MaxSize)
                    return false;
                _dataSet[pRear] = value;
                pRear = (pRear + 1) % MaxSize;
                Length++;
                return true;
            }

            public bool DeleteFront()
            {
                if (Length == 0)
                    return false;
                pFront = (pFront + 1) % MaxSize;
                Length--;
                return true;
            }

            public bool DeleteLast()
            {
                if (Length == 0)
                    return false;
                pRear--;
                pRear = (pRear + MaxSize) % MaxSize;
                Length--;
                return true;
            }

            public T GetFront()
            {
                if (Length == 0)
                    return default(T);
                return _dataSet[pFront];
            }

            public T GetLast()
            {
                if (Length == 0)
                    return default(T);
                return _dataSet[(pRear - 1 + MaxSize) % MaxSize];
            }

            public bool IsEmpty()
            {
                return Length == 0 ? true : false;
            }

            public bool IsFull()
            {
                return Length == MaxSize ? true : false;
            }
        }
    }
}
