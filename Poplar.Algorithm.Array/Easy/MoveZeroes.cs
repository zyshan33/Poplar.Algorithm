using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.Array
{
    /// <summary>
    /// 移动零
    /// </summary>
    public class MoveZeroes
    {
        public void MoveZeroesOne(int[] nums)
        {
            var j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    if (i != j)
                    {
                        nums[i] = 0;
                    }
                    j++;
                }
            }
        }

        public void MoveZeroesTwo(int[] nums)
        {
            var j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            for (; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }
    }
}
