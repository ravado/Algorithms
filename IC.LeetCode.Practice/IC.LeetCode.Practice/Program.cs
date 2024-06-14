using IC.LeetCode.Practice.Problems;

namespace IC.LeetCode.Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new Problem100();


            Console.WriteLine($"Invoking Problem {problem.ToString()}");
            problem.Invoke();

            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }
}
