using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.StackQuestion
{
    /// <summary>
    /// 柱状图中最大的矩形
    /// https://leetcode-cn.com/problems/largest-rectangle-in-histogram/
    /// </summary>
    internal class LargestRectangleInHistogram
    {
        /// <summary>
        /// 第二种方法，用单调递增的栈。
        /// 执行完一次遍历了所有元素之后，还需要再对剩下的几个元素再进行一次遍历，比n多一点，时间复杂度可以看成O(n)。
        /// 因为使用了额外的栈，所以空间复杂度也是O(n)。
        ///
        /// 1、对数组中的任意棒子，它的左右边界永远都是左右第一个高度小于它的棒子。
        /// 2、当我们从数组左边开始遍历的时候，第一根棒子的左边界是确定的，这个时候右边界不确定，此时继续往右边遍历。
        /// 3、继续往右边遍历，如果右边的棒子还比左边高的话，根据任意棒子的左右边界永远都是左右第一个高度小于它的棒子，得到此时还没有找到右边界。继续遍历。
        /// 4、遍历到第i根棒子的时候，发现它的高度比它的上一根棒子的高度低，那么i - 1棒子的右边界确定了，此时对于i - 1棒子来说，它的左边界也是确定的，因为前面遍历过的高度都比它低，此时就可以得出i - 1棒子的矩形面积。
        /// 5、当前已经遍历到第i根棒子，因为它比i - 1棒子矮，所以也不确定它是否比i - 2棒子矮，所以还要继续往回退，直到退到i - n，此时i - n棒子的高度比i棒子高度低。
        /// 6、按照上面的逻辑，遍历完所有元素。
        /// 7、遍历完所有元素之后，可能会发现最后的棒子的高度可能会比之前遍历过的某一些棒子要高，但是此时没有下一个棒子可以用了，所以对于那些剩下的棒子来说，它们的右边界就是最后一个棒子。
        /// 8、把剩下的计算一遍，得到最大的矩形面积。
        ///
        /// 对于这种需要递增，递增完之后还需要按照递减顺序出来的，可以使用栈来处理。
        /// 0、初始化一个栈，压入-1，压入-1是为了处理边界值，避免额外的判断。
        /// 1、从左到右遍历所有棒子。
        /// 2、如果当前遍历到的棒子的高度比它上一个的高度要大，证明对于之前入栈的棒子来说，它的右边界还没有找到，继续入栈。
        /// 3、遍历到第i个的时候，发现它的高度比i - 1的棒子高度小，证明此时i - 1的棒子右边界找到了，它的右边界就是i，将i - 1出栈，计算i - 1棒子的矩形面积，这个面积和最大面积之间取一个最大的。
        /// 4、处理完i - 1之后，再看i的高度是不是比i - 2的高度小，如果是的话，证明i - 2棒子的高度也找到了，同样执行出栈并且计算面积，和最大面积之间取一个最大的。
        /// 5、继续对比，直到i棒子的高度不再小于栈顶棒子高度，执行入栈。
        /// 6、遍历完所有棒子之后，可能会发现栈里还有棒子，就还需要额外处理。此时对于栈里的这些棒子来说，它们的右边界就是栈顶棒子。
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleAreaTwo(int[] heights)
        {
            var maxArea = 0;
            var stack = new Stack<int>();
            stack.Push(-1);
            for (var i = 0; i < heights.Length; i++)
            {
                while (stack.Peek() != -1 && heights[i] < heights[stack.Peek()])
                    maxArea = Math.Max(maxArea, heights[stack.Pop()] * (i - 1 - stack.Peek()));
                stack.Push(i);
            }
            var right = stack.Peek();
            while (stack.Peek() != -1)
                maxArea = Math.Max(maxArea, heights[stack.Pop()] * (right - stack.Peek()));
            return maxArea;
        }

        /// <summary>
        /// 第一种解法，循环嵌套。
        /// 最外层循环要执行n次，内层循环需要从i开始，往左右两边找到比i小的棒子，也可以理解成n次，最终的时间复杂度是O(n²)，空间复杂度是O(1)
        /// 遍历heights的元素，针对index为i的每个棒子，往左边和右边找小于它的棒子，那就是它的左右边界。
        /// 再拿它的左边界减去右边界再减一，得到的就是宽度，再乘以棒子的高度，就是矩形面积。
        /// 这里有一个小技巧，当往i的左边找的时候，可能会找到数组的最左边，此时就有两种情况，
        /// heights[i]比heights[0]大，这个时候heights[0]就不被使用，但是还有另外一种情况heights[i]比heights[0]小，此时heights[0]就需要被使用，
        /// 所以往i的左边界查找的时候，为了让heights[0]被用上，左边界的结束条件是下标探到小于-1，也就是0也要被用上。
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleAreaOne(int[] heights)
        {
            var maxArea = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                int j = i - 1, k = i + 1;
                for (; j > -1; j--)
                {
                    if (heights[j] < heights[i]) break;
                }
                for (; k < heights.Length; k++)
                {
                    if (heights[k] < heights[i]) break;
                }

                maxArea = Math.Max(maxArea, heights[i] * (k - j - 1));
            }
            return maxArea;
        }
    }
}
