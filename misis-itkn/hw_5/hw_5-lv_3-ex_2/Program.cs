// Instantiate Del by using a lambda expression.
//Del del4 = name =>  { Console.WriteLine($"Notification received for: {name}"); };
using System;
namespace ConsoleApplication1
{
    class Program
    {
        public static class SortArray
        {
            public static void ByIncreasingValue(ref int[] array)
            {
                int temp;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
            public static void ByDecreasingValue(ref int[] array)
            {
                int temp;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
        delegate void ReorderMatrixDecreasing(ref int[] array);
        static ReorderMatrixDecreasing sort_decreasing = SortArray.ByDecreasingValue;
        static ReorderMatrixDecreasing sort_increasing = SortArray.ByIncreasingValue;
        
        static void Main(string[] args)
        {
            int[,] matrix_0 = new int[5, 6] {
                                        {1,3,2,3,4,5},
                                        {2,3,4,2,3,1},
                                        {3,1,54,5,4,2},
                                        {4,3,2,2,8,5},
                                        {5,1,2,1,4,33}
                                        };
            Console.WriteLine("Input:");
            outputIndentedMatrix(matrix_0);
            reorderMatrixByIndex(ref matrix_0);
            Console.WriteLine("Output:");
            outputIndentedMatrix(matrix_0);
        }
        static void reorderMatrixByIndex(ref int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++) {
                int[] row = new int[matrix.GetLength(1)];
                initializeMatrixRowArray(ref matrix, ref row, i);
                if(i % 2 == 0) sort_increasing(ref row);
                else sort_decreasing(ref row);
                plugRowIntoMatrix(ref matrix, ref row, i);
            }
        }
        static void plugRowIntoMatrix(ref int[,] matrix, ref int[] row, int row_index)
        {
            for (int i = 0; i < row.Length; i++)
            {
                matrix[row_index, i] = row[i];
            }
        }
        static void initializeMatrixRowArray(ref int[,] matrix, ref int[] array, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] = matrix[row, i];
            }
        }
        static void outputIndentedMatrix(int[,] array)
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
    }
}