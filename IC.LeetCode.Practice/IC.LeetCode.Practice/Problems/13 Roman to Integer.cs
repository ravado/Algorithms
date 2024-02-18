using IC.LeetCode.Practice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IC.LeetCode.Practice.Problems
{
    /// <summary>
    /// 13. Roman to Integer
    /// https://leetcode.com/problems/roman-to-integer/description/
    /// 
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// Symbol Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, 2 is written as II in Roman numeral, just two ones added together. 
    /// 12 is written as XII, which is simply X + II.The number 27 is written as XXVII, which is XX + V + II.
    /// 
    /// Roman numerals are usually written largest to smallest from left to right. 
    /// However, the numeral for four is not IIII. Instead, the number four is written as IV.
    /// Because the one is before the five we subtract it making four. 
    /// The same principle applies to the number nine, which is written as IX.
    /// There are six instances where subtraction is used:
    /// I can be placed before V (5) and X (10) to make 4 and 9. 
    /// X can be placed before L(50) and C(100) to make 40 and 90. 
    /// C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given a roman numeral, convert it to an integer.
    /// 
    /// Constraints:
    /// 1 <= s.length <= 15
    /// s contains only the characters('I', 'V', 'X', 'L', 'C', 'D', 'M').
    /// It is guaranteed that s is a valid roman numeral in the range[1, 3999].
    /// </summary>
    internal class Problem13 : IProblem
    {
        public void Invoke()
        {
            // Case 1
            //string roman = "III"; // => 3

            // Case 2
            //string roman = "LVIII"; // => 58

            // Case 3
            //string roman = "MCMXCIV"; // => 1994

            // Extra Case 4
            //string roman = "IV"; // => 4

            // Extra Case 5
            string roman = "XIX"; // => 19

            int number = RomanToInt(roman);

            Console.WriteLine($"Converted {roman} to {number}");
        }

        /// <summary>
        /// My first attempt
        /// </summary>
        public int RomanToInt(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var stringArray = s.ToArray();
            var romanDic = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            int length = s.Length;
            int index = length - 1;
            int result = 0;

            Console.WriteLine($"Starting with: {s} => {stringArray.Format()} length: {length}");

            while (index >= 0)
            {
                char currentSymbol = stringArray[index];
                result += romanDic[currentSymbol];
                index--;

                Console.WriteLine($"Took {currentSymbol} == {romanDic[currentSymbol]}");
                
                if (index >= 0)
                {
                    char nextSymbol = stringArray[index];

                    // meaning we need to substruct since roman is written from greater to lover
                    if (romanDic[nextSymbol] < romanDic[currentSymbol])
                    {
                        Console.WriteLine($"- Looks like we have a reverse number, need to substract {result} - {romanDic[nextSymbol]}");
                        Console.WriteLine($"- Correct number in roman is: {nextSymbol}{currentSymbol}");
                        result -= romanDic[nextSymbol];
                        index--;
                    }
                }

                Console.WriteLine($"Current result for index [{index+1}] is {result}");
            }

            return result;
        }


        public override string ToString()
        {
            return "13. Roman to Integer";
        }
    }
}
