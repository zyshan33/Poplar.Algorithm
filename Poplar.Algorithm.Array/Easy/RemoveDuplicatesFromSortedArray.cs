using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.Array
{
    internal class RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// 有一个快指针fast和一个慢指针slow。
        /// 对快指针fast，当nums[fast] != nums[fast - 1]时，nums[fast]值和上一个值是不重复的，将num[slow]指向nums[fast]，slow++。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            var slow = 1;
            for (var fast = 1; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[fast - 1]) nums[slow++] = nums[fast];
            }
            return slow;
        }
    }
}
