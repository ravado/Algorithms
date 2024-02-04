﻿using System;
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
            int[] nums1 = [1, 2, 3, 0, 0, 0];
            int[] nums1Original = (int[])nums1.Clone(); // keep just for logs

            int m = 3;
            int[] nums2 = [2, 5, 6];
            int n = 3;
            Merge(nums1, m, nums2, n);

            Console.WriteLine($"Modified array nums1 from: \n {nums1Original.Format()}\n==>\n{nums1}");
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {

        }

        public override string ToString()
        {
            return "88. Merge Sorted Array";
        }
    }
}
