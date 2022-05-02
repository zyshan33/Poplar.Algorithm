using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.Array
{
    internal class PlusOne
    {
        /// <summary>
        /// 从数组的右边往左边遍历。
        /// 1、执行循环的时候，计算的是最右边的值，为它加1。
        ///     加的结果小于10，不用再继续往下走，方法直接返回即可，因为再左边的数都不用加。
        ///     加的结果等于10，证明再左边的数还需要加1，继续循环。
        /// 2、循环结束还没返回，说明循环最左边数字得到的也是0，需要数组扩容，再把1放在第一位。
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOneOne(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                var sum = digits[i] + 1;
                digits[i] = sum == 10 ? 0 : sum;
                if (digits[i] != 0)
                {
                    return digits;
                }
            }
            var ans = new int[digits.Length + 1];
            ans[0] = 1;
            digits.CopyTo(ans, 1);
            return ans;
        }
    }
}
