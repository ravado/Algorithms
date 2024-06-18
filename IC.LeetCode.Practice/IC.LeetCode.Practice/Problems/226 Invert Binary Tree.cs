using System;
using System.Xml.Linq;
using IC.LeetCode.Practice.Utils;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 226. Invert Binary Tree
    /// https://leetcode.com/problems/invert-binary-tree/description/
    /// 
    /// Given the root of a binary tree, invert the tree, and return its root.
    ///
    /// Constraints:
    /// The number of nodes in the tree is in the range [0, 100].
    /// -100 <= Node.val <= 100
    ///
    /// Example 1:
    /// Input: root = [4,2,7,1,3,6,9]
    /// Output: [4,7,2,9,6,3,1]
    ///
    /// Example 2:
    /// Input: root = [2,1,3]
    /// Output: [2,3,1]
    ///
    /// Example 3:
    /// Input: root = []
    /// Output: []
    /// </summary>
    internal class Problem226 : IProblem
    {
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

            public override string ToString()
            {
                return $"{val}, {left?.ToString()}, {right?.ToString()}";
            }
        }

        public void Invoke()
        {
            // Case 1
            TreeNode root = new TreeNode(4,
                left: new TreeNode(2,
                    new TreeNode(1), new TreeNode(3)),
                right: new TreeNode(7,
                    new TreeNode(6), new TreeNode(9)));

            // Case 2
            //TreeNode root = new TreeNode(2,
            //   left: new TreeNode(1),
            //   right: new TreeNode(3));

            // Case 3
            //TreeNode root = new TreeNode();

            Console.WriteLine($"Invert tree {ConvertToArray(root).Format()}");

            var result = InvertTree(root);

            Console.WriteLine($"Invert tree {ConvertToArray(root).Format()} ==> {ConvertToArray(result).Format()}");
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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            if (root.left == null && root.right == null)
            {
                return new TreeNode(root.val);
            }

            var result = new TreeNode(
                val: root.val,
                left: InvertTree(root.right),
                right: InvertTree(root.left));

            return result;
        }

        public override string ToString()
        {
            return "226. Invert Binary Tree";
        }
    }

}
