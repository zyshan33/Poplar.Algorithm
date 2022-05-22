using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.BinaryTreeQuestion.Easy
{
    /// <summary>
    /// N叉树前序遍历
    /// https://leetcode.cn/problems/n-ary-tree-preorder-traversal/
    /// </summary>
    internal class NAryTreePreOrderTraversal
    {
        /// <summary>
        /// 循环。
        /// 先将根节点入栈。
        /// 循环的退出条件是栈为空。
        /// 每次循环的时候，先从栈里拿一个元素出来。先把结果加入到结果集中。
        /// 再倒序遍历当前节点的所有子节点，并且把它们都加入到栈中。
        /// 继续下一个循环
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTwo(Node root)
        {
            var container = new List<int>();
            var stack = new Stack<Node>();
            if (root != null) stack.Push(root);
            while (stack.Count > 0)
            {
                root = stack.Pop();
                container.Add(root.val);
                for (var i = root.children.Count - 1; i > -1; i--) stack.Push(root.children[i]);
            }
            return container;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            var container = new List<int>();
            Rec(root, container);
            return container;
        }

        private void Rec(Node root, List<int> container)
        {
            if (root == null) return;
            container.Add(root.val);
            if (root.children == null) return;
            foreach (var item in root.children)
            {
                Rec(item, container);
            }
        }
    }
}
