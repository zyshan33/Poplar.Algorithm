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
        /// 这个方法最重要的是标记，从根开始遍历，对于当前遍历到的任意节点，找到它中序遍历的前驱节点，也就是当前节点的左子树中的最右一个节点，找到最右节点之后，让最右节点的right指针指向当前遍历节点，此时就完成了当前节点的前驱的标记。然后再对当前节点的左孩子执行同样的标记，直到遍历到没有左孩子的节点。
        ///
        /// 对于当前遍历到的任意节点来说，假如它没有左孩子，把当前节点的值加入到结果集，把当前节点的右孩子作为下一个要遍历的对象。
        /// 如果有左孩子，就执行内层循环，找到当前节点左孩子中的最右节点，也就是当前节点的前驱，此时前驱存在两种情况，
        ///     一种是前驱的right节点为空，那么需要将前驱的right指针指向当前节点
        ///     另外一种是前驱的right节点不为空，则证明这个节点已经标记过，并且前驱是已经被遍历过了，此时就需要将当前节点加入结果集中，并且让当前节点的右孩子变成当
        ///     前节点，再把前驱的右孩子置空。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversalThree(TreeNode root)
        {
            var ans = new List<int>();
            while (root != null)
            {
                if (root.left != null)
                {
                    var predecessor = root.left;
                    while (predecessor.right != null && predecessor.right != root)
                    {
                        predecessor = predecessor.right;
                    }
                    if (predecessor.right != null)
                    {
                        ans.Add(root.val);
                        root = root.right;
                        predecessor.right = null;
                    }
                    else
                    {
                        predecessor.right = root;
                        root = root.left;
                    }
                }
                else
                {
                    ans.Add(root.val);
                    root = root.right;
                }
            }
            return ans;
        }

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
