// Instantiate Del by using a lambda expression.
//Del del4 = name =>  { Console.WriteLine($"Notification received for: {name}"); };
using System;
namespace ConsoleApplication1
{
    class Program
    {
        public static class SortArray
        {
            public static int[] ByIncreasingValue(int[] array)
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
                return array;
            }
            public static int[] ByDecreasingValue(int[] array)
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
                return array;
            }
        }
        delegate int[] ReorderMatrixDecreasing(int[] array);
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
            for (int row = 0; row < matrix_0.GetLength(0); row++)
            {
                switch(row % 2)
                {
                    case 0:
                        reorderMatrixRowByIndex(ref matrix_0, row, sort_increasing);
                        break;
                    case 1:
                        reorderMatrixRowByIndex(ref matrix_0, row, sort_decreasing);
                        break;
                }
            }
            Console.WriteLine("Output:");
            outputIndentedMatrix(matrix_0);
        }
        static void reorderMatrixRowByIndex(ref int[,] matrix, int row, ReorderMatrixDecreasing sort)
        {
            int[] row_local = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                row_local[col] = matrix[row, col];
            }
            plugRowIntoMatrix(ref matrix, sort(row_local), row);
        }
        static void plugRowIntoMatrix(ref int[,] matrix, int[] row, int row_index)
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

