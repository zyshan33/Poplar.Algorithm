using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    /// <summary>
    /// 环形链表2，需要返回入环点
    /// </summary>
    internal class LinkedListCycleII
    {
        /// <summary>
        /// 1、假设从头部到入环点的距离为a，环的长度为b。
        /// 2、快慢指针相遇的时候，假设快指针走了f，慢指针走了s，则有f = 2s。
        /// 3、快慢指针相遇的时候，快指针比慢指针多走了nb，其中n是快指针围绕环走了多少圈。
        /// 4、根据上面的条件：
        ///     f = s + s
        ///     f = s + nb
        ///     可得s = nb
        /// 5、从头部走到入环点的距离是a + nb，这里nb的n可以是任意值，也就是说a走到入环点之后，再绕着环b走任意整数圈都能回到入环点。
        /// 6、上面两个结果：
        ///     s = nb
        ///     a + nb = 入环点
        ///     因为慢指针s已经走了nb，所以慢指针s再走a就能到入环点
        /// 7、可用一个新指针，从头开始，和慢指针一起，一步一步往前走，它们相遇的地方就是入环点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycleTwo(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (true)
            {
                if (fast == null || fast.next == null) return null;
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) break;
            }
            fast = head;
            while (slow != fast)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return fast;
        }

        /// <summary>
        /// 第一种方法，用hashSet
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycleOne(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();
            while (head != null)
            {
                if (!hashSet.Add(head))
                {
                    return head;
                }
                head = head.next;
            }
            return null;
        }
    }
}
