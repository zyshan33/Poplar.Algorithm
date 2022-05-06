using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Poplar.Algorithm.StackQuestion
{
    internal class TrappingRainWater
    {
        /// <summary>
        /// 暴力法，遍历每一根棒子，对于遍历到的棒子，都往左边和右边，找出它左右的最高的棒子，时间复杂度O(n²)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            var total = 0;
            for (var i = 1; i < height.Length - 1; i++)
            {
                int left = 0, right = 0;
                for (var j = i; j >= 0; j--) left = Math.Max(left, height[j]);
                for (var k = i; k < height.Length; k++) right = Math.Max(right, height[k]);
                total += Math.Min(left, right) - height[i];
            }
            return total;
        }

        /// <summary>
        /// 解法二，单调栈。
        /// 时间复杂度是O(n)，空间复杂度是O(1)。
        ///
        /// 从左往右遍历棒子，如果遍历到的棒子的高度比栈顶的棒子的高度小，则入栈。
        /// 1、发现当前棒子的高度比栈顶的棒子的高度高的时候，此时就需要对栈顶的棒子执行出栈并且计算雨水，因为栈顶的棒子的左右边界已经确定，它的左边界是出栈后的新栈顶，右边界是当前棒子。
        /// 2、完成一次出栈之后，判断新的栈顶棒子高度是否小于当前遍历的棒子高度，如果还是小于，还需要再执行出栈、计算雨水的操作，直到最新栈顶的高度大于当前棒子，或者栈里已经没有棒子。这里有一个边界值要注意，就是栈里最后一根棒子可能还是比当前棒子矮，此时最后一根棒子出栈之后，它没有左边界去算雨水，直接丢弃就行。
        /// 3、上面小循环处理完成后，将当前遍历到的棒子入栈，继续遍历和执行上面的操作。
        ///
        /// 每一次计算棒子能存放多少雨水的时候，高度需要用左右边界的较小值减去棒子的高度，左右边界较小值很好理解，木桶效应，减去棒子的高度是因为对这根棒子所在的索引来说，从0到它高度的那一部分显然是不能放雨水的，而它和栈顶元素之间可能会有其他更矮的棒子存在的那个区域，在这根棒子入栈之前，就已经算过那一部分区域的值，因为栈是单调递减的，不可能存在栈顶比更底端的高度大的问题。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TrapTwo(int[] height)
        {
            var total = 0;
            var stack = new Stack<int>();
            for (var i = 0; i < height.Length; i++)
            {
                while (stack.Count > 0 && height[stack.Peek()] < height[i])
                {
                    var top = stack.Pop();
                    if (stack.Count == 0) break;
                    total += (Math.Min(height[stack.Peek()], height[i]) - height[top]) * (i - stack.Peek() - 1);
                }
                stack.Push(i);
            }
            return total;
        }

        /// <summary>
        /// 解法一，使用栈处理。
        /// 
        /// 从左到右遍历数组，对于第一个进栈的棒子，可以确定它的左边界left就是它自己，此时它的右边界不确定。
        /// 继续往右边遍历，如果当前遍历到的棒子的高度比第一个棒子的高度低，证明此时棒子的右边界还不确定，因为此时最左边棒子和当前棒子组成的区域不算一个完整的存放雨水的区域，并且后面的棒子可能会比它高，进栈继续往右边遍历。
        /// 遍历到高度大于等于最左边的棒子时，证明最左边棒子和当前棒子已经组成了一个可存放雨水的区域，此时对栈里的所有棒子执行出栈操作，并且计算出栈的棒子能存放的雨水有多少。计算方式就是left - stack.Pop()，因为对于当前出栈的棒子来说，它的最高水位就是它左右边界的最低点。
        /// 继续上面的操作，直到数组被遍历完。
        /// 数组被遍历完之后，栈中可能还会存在元素，因为可能存在中间的某一个棒子的后面没有比他高的。所以此时就需要将栈中剩下的棒子按照数组的顺序反向遍历一次，又因为栈的后进先出特性，将栈中的棒子弹出并插入新的数组，再执行一次遍历。
        ///
        /// 时间复杂度是O(n)，可能存在极端情况，最左边的棒子的高度是最高的，此时需要反过来再遍历一次所有元素，也就是2n
        /// 空间复杂度是O(n)，可能存在极端情况，最左边的棒子的高度是最高的，此时需要反过来再遍历一次所有元素，需要创建一个新数组，所以空间复杂度也是2n
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TrapOne(int[] height)
        {
            var stack = new Stack<int>();
            var total = TrapOneCore(height, stack);
            if (stack.Count > 0)
            {
                height = new int[stack.Count];
                for (var i = 0; i < height.Length; i++)
                    height[i] = stack.Pop();
                total += TrapOneCore(height, stack);
            }
            return total;
        }

        public int TrapOneCore(int[] height, Stack<int> stack)
        {
            var total = 0;
            var left = 0;
            foreach (var item in height)
            {
                while (stack.Count != 0 && left <= item)
                    total += left - stack.Pop();
                if (stack.Count == 0) //如果栈中没有元素，此时可以确定新的左边界
                    left = item;
                stack.Push(item);
            }
            return total;
        }
    }
}

