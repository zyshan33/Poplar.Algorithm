using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.ArrayQuestion
{
    internal class MergeSortedArray
    {
        /// <summary>
        /// 题目是把nums2的值合并到num1里，并且nums1后面是空的，所以在迭代的时候，
        /// 可以从后往前迭代，在迭代的时候，把两个数组里取出的较大的值从后往前放入。
        /// 在判断从num1或者从nums2里取值的时候，需要判断是否已经取完，
        /// 判断的方法很简单，因为对数组取值的时候，将对应的取值索引自减了，所以这里，只要判断取值索引是否大于0就行。
        ///     调用方法时传入的m或者n为零的情况也不用判断，因为在给取值索引赋值的时候，就对m和n做了减1操作。
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void MergeTwo(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = nums1.Length - 1, j = m - 1, k = n - 1; i >= 0; i--)
                nums1[i] = j < 0 ? nums2[k--] : k < 0 ? nums1[j--] : nums1[j] > nums2[k] ? nums1[j--] : nums2[k--];
        }

        /// <summary>
        /// 额外的数组，复杂度m + n
        /// 判断对nums1的取值是否已经超过了m：
        ///     超过了，就是nums2
        ///     没超过，判断对nums2的取值是否已经超过了n
        ///         超过了，就用nums1
        ///         没超过，判断从num1里取出来的值是否大于nums2里取出来的值
        ///             是，使用nums2的值，并把nums2的取值索引增加1
        ///             否，使用nums1的值，并把nums1的组织索引增加1
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void MergeOne(int[] nums1, int m, int[] nums2, int n)
        {
            var total = m + n;
            var ans = new int[total];
            int i = 0, j = 0, k = 0;
            while (i < total)
            {
                var current = (j == m) ? nums2[k++] : (k == n) ? nums1[j++] : nums1[j] > nums2[k] ? nums2[k++] : nums1[j++];
                ans[i++] = current;
            }

            for (i = 0; i < nums1.Length; i++)
            {
                nums1[i] = ans[i];
            }
        }
    }
}
