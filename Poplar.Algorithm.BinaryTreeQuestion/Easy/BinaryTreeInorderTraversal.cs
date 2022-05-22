using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.BinaryTreeQuestion
{
    /// <summary>
    /// 二叉树中序遍历
    /// https://leetcode.cn/problems/binary-tree-inorder-traversal/
    /// </summary>
    internal class BinaryTreeInOrderTraversal
    {
        /// <summary>
        /// 使用栈模拟递归调用
        /// 外层的大的while循环，目的是遍历了当前节点之后，再往当前节点的右子节点方向进行新一轮的中序遍历。
        /// 外层循环的结束条件是count > 0 和 root != null，这里主要是为了代码整洁。
        /// 如果只判断stack > 0，则需要在进入循环前将根节点入栈，并且在外层的一次循环遍历之后，把右节点入栈。
        /// 如果只判断root != null，又存在某个节点的右节点为空，但是此时栈内还有元素，为了下一次迭代，只能从栈中取一个元素出来，但是如果从栈中取元素出来，再下一次循环的时候又会找它的左节点，导致死循环
        /// 内层while循环，目的是为了往当前节点的左边一直往下找，找到叶子节点。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversalTwo(TreeNode root)
        {
            var ans = new List<int>();
            var stack = new Stack<TreeNode>();
            while (root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                ans.Add(root.val);
                root = root.right;
                if (root == null)
                {
                    root = stack.Pop();
                }
            }
            return ans;
        }

        private readonly List<int> _container = new List<int>();

        /// <summary>
        /// 递归  O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return _container;
            InorderTraversal(root.left);
            _container.Add(root.val);
            InorderTraversal(root.right);
            return _container;
        }
    }
}
