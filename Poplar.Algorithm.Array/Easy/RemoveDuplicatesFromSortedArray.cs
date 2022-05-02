using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.Array
{
    internal class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            var slow = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1]) nums[slow++] = nums[i];
            }
            return slow;
        }
    }
}
