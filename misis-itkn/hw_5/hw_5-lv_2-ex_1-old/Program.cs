using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array_0 = new int[5, 6] {
                                        {1,3,2,3,4,5},
                                        {2,3,4,2,3,1},
                                        {3,1,54,5,4,2},
                                        {4,3,2,2,8,5},
                                        {5,1,2,1,4,33}
                                        };
            int[,] array_1 = new int[3, 4] {
                                        {1,3,22,6},
                                        {2,69,4,2},
                                        {3,1,3,5}
                                        };
            Console.WriteLine("Input:");
            outputArrays(array_0, array_1);
            SwapMaxNumsInArrays(ref array_0, ref array_1);
            Console.WriteLine("Output:");
            outputArrays(array_0, array_1);
        }
        static void SwapMaxNumsInArrays(ref int[,] array_0, ref int[,] array_1)
        {
            int max_0 = array_0[0, 0], max_1 = array_1[0, 0];
            int[] max_0_index = new int[2], max_1_index = new int[2];
            for (int row = 0; row < array_0.GetLength(0); row++)
            {
                for (int column = 0; column < array_0.GetLength(1); column++)
                {
                    if (array_0[row, column] > max_0)
                    {
                        max_0 = array_0[row, column];
                        max_0_index[0] = row;
                        max_0_index[1] = column;
                    }
                }
            }
            for (int row = 0; row < array_1.GetLength(0); row++)
            {
                for (int column = 0; column < array_1.GetLength(1); column++)
                {
                    if (array_1[row, column] > max_1)
                    {
                        max_1 = array_1[row, column];
                        max_1_index[0] = row;
                        max_1_index[1] = column;
                    }
                }
            }
            separator(); Console.WriteLine($"Max num in array_0: {max_0}, max num in array_1: {max_1}"); separator();
            array_0[max_0_index[0], max_0_index[1]] = max_1;
            array_1[max_1_index[0], max_1_index[1]] = max_0;
        }
        static void outputIndentedArray(int[,] array)
        {
            Console.Write("\t");
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    Console.Write($"{array[row, column]} ");
                }
                if(row != array.GetLength(0) - 1) Console.Write("\n\t");
                else Console.Write("\n");
            }
        }
        static void outputArrays(int[,] array_0, int[,] array_1)
        {
            Console.WriteLine("array_0:");
            outputIndentedArray(array_0);
            Console.WriteLine("array_1:");
            outputIndentedArray(array_1);
        }
        static void separator()
        {
            Console.WriteLine("-------------");
        }
    }
}