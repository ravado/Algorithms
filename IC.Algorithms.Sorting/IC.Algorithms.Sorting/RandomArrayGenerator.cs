using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC.Algorithms.Sorting
{
    public static class RandomArrayGenerator
    {
        static Random _rand = new Random();
        public static int[] GetArray(int length, int from = 0, int to = 100)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = _rand.Next(from, to);
            }

            return array;
        }
    }
}
