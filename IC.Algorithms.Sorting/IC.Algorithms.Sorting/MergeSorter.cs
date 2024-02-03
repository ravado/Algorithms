using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC.Algorithms.Sorting
{
    /// <summary>
    /// Divide and Conquer algorithm paradigm.
    /// </summary>
    internal class MergeSorter
    {
        public int[] Sort(int[] unsortedArray)
        {
            if (unsortedArray == null)
                throw new ArgumentNullException(nameof(unsortedArray));

            // there is nothing to divide
            if (unsortedArray.Length == 1)
            {
                Console.WriteLine($"Array of {unsortedArray.Format()} is only one item long and is 'sorted'");
                return unsortedArray;
            }

            int[] sortedArray = unsortedArray;

            // Divide
            //

            // this would be with rounding like 5/2 = 2 and that fine for us
            int midpoint = unsortedArray.Length / 2;
            Console.WriteLine($"Found middle for input array of {unsortedArray.Length} and is {midpoint}");

            int[] leftPart = unsortedArray.Slice(0, midpoint - 1);
            int[] rightPart = unsortedArray.Slice(midpoint, unsortedArray.Length - 1);
            Console.WriteLine($"Divided array to left: {leftPart.Format()} and right: {rightPart.Format()}");

            // Conquer
            //

            int[] leftPartSorted = Sort(leftPart);
            int[] rightPartSorted = Sort(rightPart);
            Console.WriteLine($"Sorted left: {leftPartSorted.Format()} and right: {rightPartSorted.Format()}");

            // Combine
            //

            sortedArray = Merge(leftPartSorted, rightPartSorted);
            Console.WriteLine($"Sorted left & right: {sortedArray.Format()}");

            Console.WriteLine($"==========================\n");

            return sortedArray;
        }

        private int[] Merge(int[] left, int[] right)
        {
            Console.WriteLine($"- Merge {left.Format()} and {right.Format()}");
            int[] output = new int[left.Length + right.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length)
            {
                Console.WriteLine("- Iteration: " + (k + 1));
                if (left[i] < right[j])
                {
                    Console.WriteLine($"- {left[i]} < {right[j]}");
                    output[k] = left[i];
                    i++;
                }
                else
                {
                    Console.WriteLine($"- {left[i]} >= {right[j]}");
                    output[k] = right[j];
                    j++;
                }

                Console.WriteLine($"- Output is: {output.Format()} ...");

                k++;
            }

            while (output.Length > k)
            {
                if (i < left.Length)
                {
                    output[k] = left[i];
                    i++;
                }

                if (j < right.Length)
                {
                    output[k] = right[j];
                    j++;
                }

                k++;
            }

            Console.WriteLine($"- Merging is done, merged output is {output.Format()}");

            return output;
        }
    }
}
