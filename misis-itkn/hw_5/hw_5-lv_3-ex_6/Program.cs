using System;
namespace ConsoleApplication1
{
    class Program
    {
        public static class MatrixBiggestElementIndexFinder
        {
            public static int InMatrixRow(int[,] matrix, int row)
            {
                int biggest_element = matrix[row, 0], biggest_element_index = 0;
                for(int i = 0; i < matrix.GetLength(1); i++) {
                    if(matrix[row, i] > biggest_element)
                    {
                        biggest_element = matrix[row, i];
                        biggest_element_index = i;
                    }
                }
                return biggest_element_index;
            }
            public static int OnMainDiagonal(int[,] matrix)
            {
                int biggest_element = matrix[0, 0], biggest_element_index = 0;
                for(int i = 0; i < matrix.GetLength(0); i++) {
                    if (Math.Max(biggest_element, matrix[i, i]) == matrix[i, i])
                    {
                        biggest_element = matrix[i, i];
                        biggest_element_index = i;
                    }
                }
                return biggest_element_index;
            }
        }
        delegate int MatrixRowElementFinder(int[,] matrix, int row);
        delegate int MatrixElementFinder(int[,] matrix);
        static MatrixRowElementFinder row_biggest_index = MatrixBiggestElementIndexFinder.InMatrixRow;
        static MatrixElementFinder main_diagonal_biggest_index = MatrixBiggestElementIndexFinder.OnMainDiagonal;

        static void Main(string[] args)
        {
            int[,] matrix_0 = new int[6, 6] {
                                        {1,69,2,3,4,5},
                                        {2,3,4,2,3,1},
                                        {3,1,54,5,4,2},
                                        {4,3,2,2,8,5},
                                        {2,3,8,5,33,3},
                                        {5,1,2,1,4,33}
                                        };
            Console.WriteLine("Input:");
            outputIndentedMatrix(matrix_0);
            swapColumnsBiggestOnMainDiagonalBiggestFirstRow(ref matrix_0);
            Console.WriteLine("Output:");
            outputIndentedMatrix(matrix_0);
        }
        static void swapColumnsBiggestOnMainDiagonalBiggestFirstRow(ref int[,] matrix)
        {
            swapMatrixColumns(ref matrix, row_biggest_index(matrix, 0), main_diagonal_biggest_index(matrix));
        }
        static void swapMatrixColumns(ref int[,] matrix, int column_1, int column_2)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, column_1];
                matrix[i, column_1] = matrix[i, column_2];
                matrix[i, column_2] = temp;
            }
        }
        static void plugColumnIntoMatrix(ref int[,] matrix, ref int[] column, int column_index)
        {
            for (int i = 0; i < column.Length; i++)
            {
                matrix[i, column_index] = column[i];
            }
        }
        static void initializeMatrixColumnArray(ref int[,] matrix, ref int[] array, int column)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = matrix[column, i];
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