using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC.LeetCode.Practice.Utils
{
    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int fromIdx, int toIdx)
        {
            T[] ret = new T[toIdx - fromIdx + 1];
            for (int srcIdx = fromIdx, dstIdx = 0; srcIdx <= toIdx; srcIdx++)
            {
                ret[dstIdx++] = source[srcIdx];
            }
            return ret;
        }

        public static string Format<T>(this T[] source)
        {
            return "[" + string.Join(", ", source) + "]";
        }

        public static int[] ConvertToArray(this ListNode list)
        {
            var result = new List<int>();
            if (list == null)
                return result.ToArray();

            result.Add(list.val);
            while (list.next != null)
            {
                list = list.next;
                result.Add(list.val);
            }


            return result.ToArray();
        }
    }
}
