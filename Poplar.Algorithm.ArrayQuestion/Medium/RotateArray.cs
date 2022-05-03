using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.ArrayQuestion
{
    internal class RotateArray
    {
        /// <summary>
        /// 环形替换，将当前值放在目标位置上，
        /// 由于目标位置上的值可能会被覆盖，所以需要一个临时变量来保存他，
        /// 目标位置上的值被覆盖之后，下一个需要处理的就是当前的目标位置所在的索引，
        /// 一直这样循环下去，当nums的长度能被k除尽的时候，k可能会回到起点，此时可能还有一部分数据没有被遍历到，需要从起点加1，再往下走。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void RotateThree(int[] nums, int k)
        {
            var n = nums.Length;
            k %= n;
            if (k == 0) return;
            var count = Gcd(nums.Length, k);
            for (var start = 0; start < count; start++)
            {
                var current = start;
                var prev = nums[start];
                do
                {
                    var nextIndex = (current + k) % n;
                    (nums[nextIndex], prev) = (prev, nums[nextIndex]);
                    current = nextIndex;
                } while (start != current);
            }
        }

        public int Gcd(int x, int y)
        {
            return y > 0 ? Gcd(y, x % y) : x;
        }

        /// <summary>
        /// 数组反转。
        /// 原始数组---->-->，轮转目标-->---->
        /// 一次反转<--<----
        /// 先前K个反转--><----，
        /// 再后num.Length - k个反转-->---->
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void RotateTwo(int[] nums, int k)
        {
            k %= nums.Length;
            System.Array.Reverse(nums, 0, nums.Length);
            System.Array.Reverse(nums, 0, k);
            System.Array.Reverse(nums, k, nums.Length - k);
        }

        /// <summary>
        /// 第一种方法。使用额外的数组ans。
        /// 遍历nums的时候，num的第i个元素会被存放在nums的 (i + k) % nums.Length里。
        /// 遍历完之后，再把ans数组拷贝到nums
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void RotateOne(int[] nums, int k)
        {
            k %= nums.Length;
            var n = nums.Length;
            var ans = new int[n];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[(i + k) % n] = nums[i];
            }
            System.Array.Copy(ans, nums, n);
        }
    }
}
