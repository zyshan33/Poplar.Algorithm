using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.BinaryTreeQuestion
{
    /// <summary>
    /// 二叉树前序遍历
    /// https://leetcode.cn/problems/binary-tree-preorder-traversal/
    /// </summary>
    internal class BinaryTreePreOrderTraversal
    {
        /// <summary>
        /// 第三种方式和中序遍历的类似。
        /// 区别是对当前节点的遍历放在循环的开始
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversalThree(TreeNode root)
        {
            var container = new List<int>();
            while (root != null)
            {
                container.Add(root.val);
                if (root.left != null)
                {
                    var rightPredecessor = root.left;
                    while (rightPredecessor.right != null && rightPredecessor.right != root.right)
                    {
                        rightPredecessor = rightPredecessor.right;
                    }
                    if (rightPredecessor.right != null)
                    {
                        root = rightPredecessor.right;
                        rightPredecessor.right = null;
                    }
                    else
                    {
                        rightPredecessor.right = root.right;
                        root = root.left;
                    }
                }
                else
                {
                    root = root.right;
                }
            }
            return container;
        }

        /// <summary>
        /// 迭代
        /// 先把当前值加入到数组中。
        /// 再将把右节点加入站中。
        /// 将当前节点指向当前节点的左节点，以便进行下一层。
        /// 如果到循环内，发现当前节点为空了，则证明左边已经到底，此时就要从栈中取出右节点来遍历。
        /// 因为栈里加的始终是当前节点的右节点，所以不会造成死循环。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversalTwo(TreeNode root)
        {
            var container = new List<int>();
            var stack = new Stack<TreeNode>();
            while (root != null || stack.Count != 0)
            {
                if (root != null)
                {
                    container.Add(root.val);
                    if (root.right != null) stack.Push(root.right);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                }
            }
            return container;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var container = new List<int>();
            Rec(root, container);
            return container;
        }

        private void Rec(TreeNode root, List<int> container)
        {
            if (root == null) return;
            container.Add(root.val);
            Rec(root.left, container);
            Rec(root.right, container);
        }
    }
}
