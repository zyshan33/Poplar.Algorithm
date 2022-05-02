using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    internal class ReverseNodesInKGroup
    {
        /// <summary>
        /// 递归，每个递归的任务就是将子级需要处理的长度内的链表进行反转
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroupTwo(ListNode head, int k)
        {
            ListNode prev = new ListNode(0, head), newHead = prev;
            Reverse(prev, head, k);
            return newHead.next;
        }

        /// <summary>
        /// 1、先校验是否需要反转
        /// 2、执行反转，反转k个元素
        /// 3、将反转后的尾结点的下一节点指向下次反转的第一个节点。
        ///     previous所存的是上一个节点，那么previous的next就是当前反转的反转前的头节点，也就是反转后的尾结点，所以处理previous.next.next就行
        /// 4、将反转后的尾结点作为下一次的previous节点，加上下次反转的第一个节点，调用反转方法。
        /// 5、将previous的next指向反转后的头结点。
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="current"></param>
        /// <param name="k"></param>
        private void Reverse(ListNode previous, ListNode current, int k)
        {
            if (!CheckCanReverse(current, k)) return;

            ListNode prev = null, curr = current;
            var i = k;
            while (curr != null && i-- > 0)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            previous.next.next = curr;
            Reverse(previous.next, curr, k);
            previous.next = prev;
        }

        /// <summary>
        /// 1、K次反转就是最近的一个可重复的子问题。
        /// 2、一个大循环，大循环内部嵌套了小循环。
        /// 3、小循环执行k次反转，小循环执行完k次反转之后，需要给出小循环反转后的头结点和尾结点，还有下次小循环时使要处理的节点的开头
        /// 4、大循环在小循环结束之后:
        ///     将小循环得到的尾结点的next节点指向下次小循环时要处理的节点的开头。
        ///     将大循环存有的prev节点的next指向小循环给出的反转后的头结点。
        ///     将大循环存有的prev节点指向反转后的尾结点。
        ///     最后将大循环存有的当前节点指向小循环的当前节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroupOne(ListNode head, int k)
        {
            ListNode bigPrev = new ListNode(0, head), bigCurr = head, newHead = bigPrev;
            while (true)
            {
                //bigPrev.next = bigCurr;
                if (!CheckCanReverse(bigCurr, k)) break;
                ListNode prev = null, curr = bigCurr;
                var i = k;
                while (curr != null && i-- > 0)
                {
                    var next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                }
                bigPrev.next.next = curr;
                var temp = bigPrev.next;
                bigPrev.next = prev;
                bigPrev = temp;
                bigCurr = curr;
            }
            return newHead.next;
        }

        /// <summary>
        /// 校验是否能反转
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckCanReverse(ListNode head, int k)
        {
            while (k-- > 0 && head != null)
            {
                head = head.next;
            }
            return k == -1;
        }
    }
}