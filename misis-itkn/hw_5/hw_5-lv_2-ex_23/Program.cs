using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix_0 = new int[5, 6] {
                                        {-1,3,2,3,4,5},
                                        {2,3,-4,-2,3,1},
                                        {-3,-1,-54,-5,-4,2},    // replace this row
                                        {-4,3,2,2,-8,5},
                                        {5,1,2,1,-4,33}
                                        };
            int[,] matrix_1 = new int[5, 6] {
                                        {2,6,-3,4,-5,6},
                                        {3,-4,5,6,7,8},
                                        {4,5,6,7,8,9},
                                        {5,-6,7,-8,-9,-10}, // replace this row
                                        {6,7,8,9,10,11}
                                        };
            Console.WriteLine("Input:");
            outputMatrices(matrix_0, matrix_1);
            swapMostlyNegativeMatrixRows(ref matrix_0, ref matrix_1);
            Console.WriteLine("Output:");
            outputMatrices(matrix_0, matrix_1);
        }
        static void swapMostlyNegativeMatrixRows(ref int[,] matrix_0, ref int[,] matrix_1)
        {
            int matrix_0_row = findMostlyNegativeElementsMatrixRow(matrix_0)[0, 0];
            int matrix_1_row = findMostlyNegativeElementsMatrixRow(matrix_1)[0, 0];
            swapMatrixRows(ref matrix_0, matrix_0_row, ref matrix_1, matrix_1_row);   
        }
        static void swapMatrixRows(ref int[,] matrix_0, int row_0, ref int[,] matrix_1, int row_1)
        {
            int temp;
            for (int i = 0; i < matrix_0.GetLength(1); i++)
            {
                temp = matrix_0[row_0, i];
                matrix_0[row_0, i] = matrix_1[row_1, i];
                matrix_1[row_1, i] = temp;
            }
        }

        static int[,] findMostlyNegativeElementsMatrixRow(int[,] matrix_0)  // Designed to be reusable; outputs a matrix with the row's number and its contents
        {
            int max_negative_elements = 0;
            int max_negative_elements_row = 0;
            for(int row = 0; row < matrix_0.GetLength(0); row++)
            {
                int negative_elements = 0;
                for(int col = 0; col < matrix_0.GetLength(1); col++)
                {
                    if(matrix_0[row, col] < 0)
                    {
                        negative_elements++;
                    }
                }
                if(negative_elements > max_negative_elements)
                {
                    max_negative_elements = negative_elements;
                    max_negative_elements_row = row;
                }
            }
            int[,] result = new int[2, matrix_0.GetLength(1)];
            for(int col = 0; col < matrix_0.GetLength(1); col++)
            {
                result[1, col] = matrix_0[max_negative_elements_row, col];
            }
            result[0,0] = max_negative_elements_row;
            return result;
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
        static void outputMatrices(int[,] array_0, int[,] array_1)
        {
            Console.WriteLine("array_0:");
            outputIndentedMatrix(array_0);
            Console.WriteLine("array_1:");
            outputIndentedMatrix(array_1);
        }
    }
}