using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    /// <summary>
    /// 两两交换链表中的节点
    /// </summary>
    internal class SwapPairs
    {
        /// <summary>
        /// 第三种解法，递归，递归中只需要将当前节点和下一节点交换位置，再处理当前节点和下一节点之后的对
        /// 1、先用一个临时值存储当前节点的下一节点。
        /// 2、当前节点的下一节点指向当前节点的下一节点的下一节点
        /// 3、上面存储的当前节点的下一节点的下一节点指向当前节点。
        /// 4、处理完成的当前节点的下一节点继续递归处理
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsThree(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var temp = head.next;
            head.next = head.next.next;
            temp.next = head;
            head.next = SwapPairsThree(head.next);
            return temp;
        }

        /// <summary>
        /// 第二种解法，最开始的时候，新建一个prev节点，让它的nex指向head。同时新建另外一个节点，把这个prev值赋值给他，以便反转之后返回新的头部。
        /// 每次循环的时候，判断prev有没有next节点和next.next节点，有就进入循环体。
        /// 循环体内部，将prev.next和prev.next.next交换。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsTwo(ListNode head)
        {
            var prev = new ListNode(0, head);
            var newHeadPrev = prev;
            while (prev.next != null && prev.next.next != null)
            {
                var n1 = prev.next;
                var n2 = prev.next.next;
                prev.next = n2;
                n1.next = n2.next;
                n2.next = n1;
                prev = n1;
            }
            return newHeadPrev.next;
        }

        /// <summary>
        /// 第一种解法
        /// 每次交换的时候，交换当前节点和下一节点。
        /// 这样就需要有一个额外的字段，也就是上一节点，还有一个新的头部
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairsOne(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode curr = head, next = head.next, prev = null, newHead = head.next;
            while (next != null)
            {
                if (prev != null) prev.next = next;
                var temp = next.next;
                next.next = curr;
                curr.next = temp;
                prev = curr;
                curr = temp;
                next = curr?.next;
            }
            return newHead;
        }
    }
}
