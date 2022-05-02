using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.LinkedListQuestion
{
    /// <summary>
    /// 翻转链表
    /// </summary>
    internal class ReverseLinkedList
    {
        /// <summary>
        /// 递归。
        /// 1、把原链表最后一个元素拿出来，作为新的链表头。
        /// 2、每次递归的时候，把当前元素的next的next指向当前元素，再把当前元素的next指向null。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListThree(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var newHead = ReverseListThree(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }

        /// <summary>
        /// 每次遍历的时候，都将当前节点的下一个节点指向上一个。
        /// 由于是单向链表，在遍历的时候不知道上一个节点，所以需要一个字段存储下一个节点。
        /// 在翻转的时候，由于当前节点的下一个节点需要指向当前节点的上一个节点，所以需要一个额外的节点指向当前节点的下一个节点。
        /// 完成翻转之后，当前节点就变成上一个节点，而当前节点的下一个节点变成当前节点。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListOne(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        /// <summary>
        /// 第二种比较繁琐的方法。
        /// 每次遍历的时候，将下一个节点的next指向当前节点。
        /// 翻转的时候我们知道当前节点是什么，但是由于当前节点的下一个节点已经被指到上一个节点了，所以需要一个字段存储下一个节点。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListTwo(ListNode head)
        {
            if (head == null) //空值校验
            {
                return null;
            }
            var curr = head;
            var next = curr.next;
            curr.next = null; //需要将头结点的下一个节点设置为null。因为算法是将当前节点的下一个节点的next指向当前节点，也就意味着head没有机会被处理，为了避免head一直指向第二个节点，此处需要额外处理。
            while (next != null)
            {
                var temp = next.next;
                next.next = curr;
                curr = next;
                next = temp;
            }
            return curr;
        }
    }
}
