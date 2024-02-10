using IC.LeetCode.Practice.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 88. Merge Sorted Array
    /// https://leetcode.com/problems/merge-sorted-array/
    /// 
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// 
    /// Constraints:
    /// 2 <= nums.length <= 104
    /// -109 <= nums[i] <= 109
    /// -109 <= target <= 109
    /// Only one valid answer exists.
    /// 
    /// </summary>
    internal class Problem1 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 9;

            // Case 2
            //int[] nums = new int[] { 3, 2, 4 };
            //int target = 6;

            // Case 3
            //int[] nums = new int[] { 3, 3 };
            //int target = 6;

            // Extra 4 (Expected => [0,3])
            //int[] nums = new int[] { 0, 4, 3, 0 };
            //int target = 0;

            // Extra 5 (Expected => [0, 2])
            int[] nums = new int[] { -3, 4, 3, 90 };
            int target = 0;
            
            Console.WriteLine($"Searching two sum of {nums.Format()} and target {target}");

            //var result = TwoSum(nums, target);
            var result = TwoSumWithHash(nums, target);

            Console.WriteLine($"Result: {result.Format()}");
        }

        /// <summary>
        /// My first attempt
        /// </summary>
        private int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return new int[0];

            int[] result = new int[2];
            int i = 0;
            int j = 0;
            while (i < nums.Length)
            {
                int val = nums[i];
                int seekablePair = target - val;

                Console.WriteLine($"The first number is {val} and seekable is {seekablePair}");
                
                // seems redundant to search pairs from the same beggining of
                // array since the previous iteration hasn't found a match
                j = i;

                while (j < nums.Length)
                {
                    // we don't want to compare the same numbers from the same index
                    if (j == i) 
                    { 
                        j++; 
                        continue; 
                    }

                    if (nums[j] == seekablePair)
                    {
                        Console.WriteLine($"The pair is found at {i} => {nums[i]} and {j} => {nums[j]}");

                        result[0] = i;
                        result[1] = j;

                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"The {nums[i]} + {nums[j]} != {target}. Keep searching..");

                        j++;
                    }
                }

                Console.WriteLine($"Update the first number...");
                i++;
            }

            return new int[0];
        }

        private int[] TwoSumWithHash(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int value = nums[i];
                int seekablePair = target - value;

                if (dictionary.ContainsKey(seekablePair))
                {
                    return new int[] { dictionary[seekablePair], i };
                }
                else
                {
                    dictionary[value] = i;
                }
            }

            return new int[0];
        }

        public override string ToString()
        {
            return "1. Two Sum";
        }
    }
}
