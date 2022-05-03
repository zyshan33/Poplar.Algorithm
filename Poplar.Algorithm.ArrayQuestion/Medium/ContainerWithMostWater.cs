using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.ArrayQuestion
{
    internal class ContainerWithMostWater
    {
        public int MaxAreaOne(int[] height)
        {
            var max = 0;
            for (var i = 0; i < height.Length - 1; i++)
            {
                for (var j = i + 1; j < height.Length; j++)
                {
                    max = Math.Max(Math.Min(height[i], height[j]) * (j - i), max);
                }
            }
            return max;
        }

        public int MaxAreaTwo(int[] height)
        {
            var max = 0;
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                var minHeight = height[i] < height[j] ? height[i++] : height[j--];
                max = Math.Max(max, minHeight * (j - i + 1)); //这里minHeight * (j - i + 1)，加1的原因是上一句已经对下标做了减或者增的操作了。
            }
            return max;
        }
    }
}
