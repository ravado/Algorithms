using System;
using System.Xml.Linq;
using IC.LeetCode.Practice.Utils;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 203. Remove Linked List Elements
    /// https://leetcode.com/problems/remove-linked-list-elements/description/
    /// 
    /// Given the head of a linked list and an integer val, remove all the nodes
    /// of the linked list that has Node.val == val, and return the new head.
    ///
    /// Constraints:
    /// The number of nodes in the list is in the range [0, 104].
    /// 1 <= Node.val <= 50
    /// 0 <= val <= 50
    ///
    /// Example 1:
    /// Input: head = [1,2,6,3,4,5,6], val = 6
    /// Output: [1,2,3,4,5]
    ///
    /// Example 2:
    /// Input: head = [], val = 1
    /// Output: []
    ///
    /// Example 3:
    /// Input: head = [7,7,7,7], val = 7
    /// Output: []
    /// </summary>
    internal class Problem203 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            // [1,2,6,3,4,5,6], val=6
            //ListNode node = new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6)))))));
            //int valueToRemove = 6;

            // Case 2
            // [], val=1
            ListNode node = null;
            int valueToRemove = 1;

            // Case 3
            // [7,7,7,7], 7
            //ListNode node = new ListNode(7, new ListNode(7, new ListNode(7, new ListNode(7))));
            //int valueToRemove = 7;

            Console.WriteLine($"Remove linked lists elements [{valueToRemove}] for {node.ConvertToArray().Format()}");

            var result = RemoveElements(node, valueToRemove);

            Console.WriteLine($"Result: {result.ConvertToArray().Format()}");
        }

        /// <summary>
        /// My first attempt
        /// </summary>
        public ListNode RemoveElements(ListNode head, int val)
        {
            Console.WriteLine($": head: {head?.val}");
            if (head == null)
            {
                Console.WriteLine($": head is null, return null");
                return null;
            }

            if (head.val == val && head.next == null)
            {
                Console.WriteLine($": head values {head.val} == {val} and there is no next, return null");
                return null;
            }
            else if (head.val == val)
            {
                Console.WriteLine($": head values {head.val} == {val}, but next is available, try to combine it...");
                var removed = RemoveElements(head.next, val);
                //var n = new ListNode(head.next.val, removed);

                Console.WriteLine($": head values {head.val} == {val}, but next is available, try to combine it... return {removed?.val}");
                return removed;
            }
            else
            {
                Console.WriteLine($": head values {head.val}, all looks good, replace the next values...");
                head.next = RemoveElements(head.next, val);

                Console.WriteLine($": head values {head.val}, all looks good, replace the next values... Returned {head.val}");
                return head;
            }
        }

        /// <summary>
        /// My second attempt
        /// </summary>
        public ListNode RemoveElementsV2(ListNode head, int val)
        {
            if (head == null)
                return null;

            do
            {
                if (head.val == val)
                {
                    if(head.next !=null)
                    {
                       // head == new ListNode(head.next.val, head.next);
                    }
                }
            }
            while (head.next != null);

            if (head.val == val && head.next == null)
            {
                return new ListNode();
            }
            else if (head.val == val)
            {
                var removed = RemoveElements(head.next?.next, val);
                return new ListNode(head.next.val, removed);
            }
            else
            {
                return RemoveElements(head.next, val);
            }
        }

        public override string ToString()
        {
            return "203. Remove Linked List Elements";
        }
    }

}
