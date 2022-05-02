using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    /// <summary>
    /// 链表环
    /// </summary>
    internal class LinkedListCycle
    {
        /// <summary>
        /// 快慢，O(n)时间复杂度和O(1)空间复杂度
        /// 在循环里，快指针和慢指针同时往前跑，一个一次跑一步，一个一次跑两步，如果有环，它们最终会相遇。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycleTwo(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (false != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycleOne(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();
            while (head != null)
            {
                if (hashSet.Contains(head))
                {
                    return true;
                }
                hashSet.Add(head);
                head = head.next;
            }
            return false;
        }
    }
}
