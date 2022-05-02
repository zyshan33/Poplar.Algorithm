using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    internal class MergeTwoSortedLists
    {
        public ListNode MergeTwoListsTwo(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            if (list2 == null)
            {
                return list1;
            }
            if (list1.val < list2.val)
            {
                list1.next = MergeTwoListsTwo(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoListsTwo(list1, list2.next);
                return list2;
            }
        }

        /// <summary>
        /// 第一种解法。
        /// 1、创建prev结点，避免在循环体内部做额外的边界值判断，创建完prev节点之后，由于prev节点需要在循环中改变值，
        /// 所以这里为了能找到头结点，使用了额外的preHead变量去保存。
        /// 2、while循环，循环的终止条件是list1和list2有一个为null。
        /// 3、循环内部，如果list1的val小于list2，则prev的next是list，否则是list2。再将prev的节点指向它的下一个节点，以便下一次迭代使用
        /// 4、while循环的退出条件是list1或者list2有一个是null，所以在循环退出时可能会有一段值没有合并，在让prev.next指向其中一个不为空的。
        /// 5、返回头。
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoListsOne(ListNode list1, ListNode list2)
        {
            ListNode preHead = new ListNode(0, null), prev = preHead;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    prev.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    prev.next = list2;
                    list2 = list2.next;
                }
                prev = prev.next;
            }
            prev.next = list1 ?? list2;
            return preHead.next;
        }
    }
}
