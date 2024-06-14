using System.Xml.Linq;
using IC.LeetCode.Practice.Utils;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 100. Same Tree
    /// https://leetcode.com/problems/same-tree/description/
    /// 
    /// Given the roots of two binary trees p and q, write a function to check if they are the same or not.
    /// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
    ///
    /// Constraints:
    /// The number of nodes in both trees is in the range[0, 100].
    /// -104 <= Node.val <= 104
    ///
    /// Example 1:
    /// Input: p = [1,2,3], q = [1,2,3]
    /// Output: true
    ///
    /// Example 2:
    /// Input: p = [1,2], q = [1,null,2]
    /// Output: false
    ///
    /// Example 3:
    /// Input: p = [1,2,1], q = [1,1,2]
    /// Output: false
    /// </summary>
    internal class Problem100 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            //TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            //TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            // Case 2
            //TreeNode p = new TreeNode(1, new TreeNode(2), null);
            //TreeNode q = new TreeNode(1, null, new TreeNode(3));

            // Case 3
            TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(1));
            TreeNode q = new TreeNode(1, new TreeNode(1), new TreeNode(2));

            Console.WriteLine($"Are trees {ConvertToArray(p).Format()} and {ConvertToArray(q).Format()} the same?");

            bool result = IsSameTree(p, q);
            string resultText = result ? "YES" : "NO";

            Console.WriteLine($"\n==> {resultText}");
        }

        public int?[] ConvertToArray(TreeNode list)
        {
            var result = new List<int?>();
            if (list == null)
                return result.ToArray();

            result.Add(list.val);

            if (list.left != null)
            {
                //result.Add(list.left.val);
                result.AddRange(ConvertToArray(list.left));
            }
            else if (list.right != null)
            {
                result.Add(null);
            }

            if (list.right != null)
            {
                result.AddRange(ConvertToArray(list.right));
                //result.Add(list.right.val);
            }

            return result.ToArray();
        }

        /// <summary>
        /// My first attempt
        /// </summary>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if (p == null || q == null)
            {
                return false;
            }

            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "100. Same Tree";
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
