using System;
namespace ConsoleApplication1
{
    class Program
    {
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
	    swapMatrixColumns(ref matrix_0, findBiggestMatrixElementColumnUnderInclMainDiagonal(matrix_0), findSmallestMatrixElementColumnUnderMainDiagonal(matrix_0));
            Console.WriteLine("Output:");
            outputIndentedMatrix(matrix_0);
        }
        static int findBiggestMatrixElementColumnUnderInclMainDiagonal(int[,] matrix)
	{
            int biggest_number = matrix[0,0], biggest_number_column = 0;
	    for (int row = 0; row < matrix.GetLength(0); row++)
	    {
                for (int column = 0; column <= row; column++)
		{
                    if (matrix[row, column] > biggest_number) {
                        biggest_number = matrix[row, column];
			biggest_number_column = column;
		    }
		}
	    }
	    return biggest_number_column;
	}
	static int findSmallestMatrixElementColumnUnderMainDiagonal(int[,] matrix)
        {
            int smallest_number = matrix[0,0], smallest_number_column = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = row + 1; column < matrix.GetLength(1); column++)
                {Console.WriteLine($"{row} - row {column} - column; checking for smallest num");
                    if (matrix[row, column] < smallest_number) {Console.WriteLine($"{matrix[row, column]} - new smallest number");
                        smallest_number = matrix[row, column];
                        smallest_number_column = column;
                    }
                }
            }
            return smallest_number_column;
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
        static void outputIndentedMatrix(int[,] matrix)
        {
            Console.Write("\t");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                if(row != matrix.GetLength(0) - 1) Console.Write("\n\t");
                else Console.Write("\n");
            }
        }
    }
}
