using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.Array.Medium
{
    internal class ThreeSum
    {
        /// <summary>
        /// 暴力三层循环嵌套 O(n³)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSumOne(int[] nums)
        {
            System.Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                if ((i > 0 && nums[i] == nums[i - 1])) continue; //忽略重复数
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if ((j > i + 1 && nums[j] == nums[j - 1])) continue; //忽略重复数
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (k > j + 1 && nums[k] == nums[k - 1]) continue; //忽略重复数
                        if (nums[i] + nums[j] + nums[k] == 0) result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                    }
                }
            }
            return result;
        }
        
        /// <summary>
        /// 排序后固定左边小的 + 双指针左右包夹
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSumTwo(int[] nums)
        {
            System.Array.Sort(nums);
            var result = new List<IList<int>>();
            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum < 0) while (j < k && nums[j] == nums[++j]) ; //如果sum小于零，则j需要往右边移，往右边移动的时候，需要判断当前值是否等于下一个，如果是，j自增，继续移
                    else if (sum > 0) while (j < k && nums[k] == nums[--k]) ;//如果sum大于零，则k需要往左边移，往左边移动的时候，需要判断当前值是否等于下一个，如果是，k自增，继续移
                    else
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        while (j < k && nums[j] == nums[++j]) ; //使用了当前值之后，需要把重复值过滤掉
                        while (j < k && nums[k] == nums[--k]) ; //使用了当前值之后，需要把重复值过滤掉
                    }

                }
            }
            return result;
        }
    }
}