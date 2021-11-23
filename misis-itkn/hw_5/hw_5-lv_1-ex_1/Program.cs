using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 5, test_0 = 8, test_1 = 10, test_2 = 11;
            outputResult(k, test_0);
            outputResult(k, test_1);
            outputResult(k, test_2);
        }
        static int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);

        }
        static void outputResult(int k, int n) {
            Console.WriteLine($"For {n} participants: {calculateDistribution(n, k)}");
        }
        static int calculateDistribution(int n, int k)
        {
            return factorial(n) / ((factorial(k) * factorial(n - k)));
        }
    }
}