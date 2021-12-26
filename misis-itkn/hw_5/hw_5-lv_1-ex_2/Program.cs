using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            outputResult(new float[] {4.3F, 5, 6.7F}, new float[] {2.443F, 3.80F, 4});
            outputResult(new float[] {1, 2.69F, 3}, new float[] {2, 3, 4.1F});
        }
        static float heronsFormula(float a, float b, float c)
        {
            float s = (a + b + c) / 2;
            return (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        static bool compareTriangles(float[] triangle_0, float[] triangle_1)
        {
            float area_0 = heronsFormula(triangle_0[0], triangle_0[1], triangle_0[2]);
            float area_1 = heronsFormula(triangle_1[0], triangle_1[1], triangle_1[2]);
            return (area_0 >= area_1);
        }
        static void outputResult(float[] triangle_0, float[] triangle_1)
        {
            string triangle_0_sides_string = $"{triangle_0[0]}, {triangle_0[1]}, {triangle_0[2]}";
            string triangle_1_sides_string = $"{triangle_1[0]}, {triangle_1[1]}, {triangle_1[2]}";
            Console.WriteLine($"Comparing triangle 1 with sides {triangle_0_sides_string} and triangle 2 with sides {triangle_1_sides_string}");
            switch (compareTriangles(triangle_0, triangle_1))
            {
                case true:
                    Console.WriteLine("Triangle 1 is bigger\n");
                    break;
                case false:
                    Console.WriteLine("Triangle 2 is bigger\n");
                    break;
            }
        }
    }
}