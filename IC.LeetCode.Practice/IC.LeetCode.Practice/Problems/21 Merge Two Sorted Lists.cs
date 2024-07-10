using IC.LeetCode.Practice.Utils;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// 
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
    /// Return the head of the merged linked list.
    /// 
    /// Constraints:
    /// The number of nodes in both lists is in the range[0, 50].
    /// -100 <= Node.val <= 100
    /// Both list1 and list2 are sorted in non-decreasing order.
    ///
    /// Example 1:
    /// Input: list1 = [1,2,4], list2 = [1,3,4]
    /// Output: [1,1,2,3,4,4]
    ///
    /// Example 2:
    /// Input: list1 = [], list2 = []
    /// Output: []
    ///
    /// Example 3:
    /// Input: list1 = [], list2 = [0]
    /// Output: [0]
    /// </summary>
    internal class Problem21 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            // Case 2
            //ListNode list1 = new ListNode();
            //ListNode list2 = new ListNode();

            // Case 3
            //ListNode list1 = new ListNode();
            //ListNode list2 = new ListNode(0);

            Console.WriteLine($"Merging lists {list1.ConvertToArray().Format()} and {list2.ConvertToArray().Format()}");

            //ListNode result = MergeTwoLists(list1, list2);
            ListNode result = MergeTwoListsRecursively(list1, list2);

            Console.WriteLine($"\n==>\n{result.ConvertToArray().Format()}");
        }

        /// <summary>
        /// My first attempt
        /// </summary>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode mergedList = null;

            if (list1 == null)
                return list2;

            if (list2 == null)
                return list1;

            bool anyNodesLeft = list1 != null || list2 != null;

            //while (anyNodesLeft)
            //{
            //    int? nodeA = list1 == null ? null : list1.val;
            //    int? nodeB = list2 == null ? null : list2.val;

            //    if (mergedList == null)
            //    {
            //        Console.WriteLine("Empty merged list. Add the first lower node to it...");
            //        if (nodeA == null)
            //        {
            //            mergedList = new ListNode(nodeB.Value, list2.next);
            //            Console.WriteLine($"Added from list2 - val: {nodeB.Value}, next:");
            //        }
            //        else
            //        {
            //            mergedList = new ListNode(nodeA.Value, list1.next);
            //        }
            //    }

            //    if (nodeA == null)
            //    {
            //        mergedList.next =
            //    }
            //}

            return null;
        }


        public ListNode MergeTwoListsRecursively(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;

            if (list2 == null)
                return list1;

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoListsRecursively(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoListsRecursively(list1, list2.next);
                return list2;
            }
        }


        public override string ToString()
        {
            return "21. Merge Two Sorted Lists";
        }
    }
}
