using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using IC.LeetCode.Practice.Utils;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 88. Merge Sorted Array
    /// https://leetcode.com/problems/merge-sorted-array/
    /// 
    /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, 
    /// and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
    /// 
    /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    /// The final sorted array should not be returned by the function, 
    /// but instead be stored inside the array nums1. 
    /// 
    /// To accommodate this, nums1 has a length of m + n, where the first m elements denote the 
    /// elements that should be merged, and the last n elements are set to 0 and should be ignored. 
    /// nums2 has a length of n.
    /// 
    /// Constraints:
    /// nums1.length == m + n
    /// nums2.length == n
    /// 0 <= m, n <= 200
    /// 1 <= m + n <= 200
    /// -10^9 <= nums1[i], nums2[j] <= 10^9
    /// 
    /// </summary>
    internal class Problem88 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            //int[] nums1 = [1, 2, 3, 0, 0, 0];
            //int m = 3;
            //int[] nums2 = [2, 5, 6];
            //int n = 3;

            // Case 2
            //int[] nums1 = [1];
            //int m = 1;
            //int[] nums2 = [];
            //int n = 0;

            // Case 3
            int[] nums1 = [0];
            int m = 0;
            int[] nums2 = [1];
            int n = 1;

            int[] nums1Original = (int[])nums1.Clone(); // keep just for logs
            Merge(nums1, m, nums2, n);

            Console.WriteLine($"Modified array nums1 from:\n{nums1Original.Format()}\n==>\n{nums1.Format()}");
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int leftCount = m;
            int rightCount = n;
            int totalCount = nums1.Length;

            // place all numbers from nums2 into right portion of nums1
            // so we have all numbers inside of one array
            int i = leftCount;
            int j = 0;
            while (i < totalCount && j < rightCount)
            {
                nums1[i] = nums2[j];
                i++;
                j++;
            }

            Console.WriteLine($"Combined both arrays:\n{nums1.Format()}");

            Sort(nums1);

            Console.WriteLine($"Sorted:\n{nums1.Format()}");
        }

        private void Sort(int[] nums1)
        {
            // simple bubble sort
            if (nums1 == null || nums1.Length <= 1)
                return;

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = i + 1; j < nums1.Length; j++)
                {
                    if (nums1[i] > nums1[j])
                    {
                        int toSwap = nums1[i];
                        nums1[i] = nums1[j];
                        nums1[j] = toSwap;
                    }
                }
            }
        }


        public override string ToString()
        {
            return "88. Merge Sorted Array";
        }
    }
}
