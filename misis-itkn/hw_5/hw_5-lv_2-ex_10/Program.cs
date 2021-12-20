using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix_0 = new int[6, 6] {
                                        {1,-69,2,3,4,5},
                                        {2,3,4,2,3,1},
                                        {3,1,54,5,4,2},
                                        {4,3,2,2,8,5},
                                        {2,3,8,5,33,3},
                                        {5,1,2,1,4,33}
                                        };
	        Console.WriteLine("Input:");
	        outputIndentedMatrix(matrix_0, 0);
            removeMatrixColumnsTask(ref matrix_0);
            Console.WriteLine("Output:");
            outputIndentedMatrix(matrix_0, 2);
        }
        static int findBiggestMatrixElementColumnUnderInclMainDiagonal(int[,] matrix)
	{
            int biggest_number = matrix[0,0], biggest_number_column = 0;
	    for (int row = 0; row < matrix.GetLength(0); row++)
	    {
            for (int column = 0; column <= row; column++)
		    {Console.WriteLine($"{row} - row {column} - column; checking for the biggest num");
                if (matrix[row, column] > biggest_number) {
                    biggest_number = matrix[row, column];
			        biggest_number_column = column;
		        }
		    }
	    }
        Console.WriteLine($"{biggest_number} - biggest number, column: {biggest_number_column}");
	    return biggest_number_column;
	}
	static int findSmallestMatrixElementColumnAboveMainDiagonal(int[,] matrix)
        {
            int smallest_number = matrix[0,1], smallest_number_column = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = row + 1; column < matrix.GetLength(1); column++)
                {Console.WriteLine($"{row} - row {column} - column; checking for the smallest num");
                    if (matrix[row, column] < smallest_number) {Console.WriteLine($"{matrix[row, column]} - new smallest number");
                        smallest_number = matrix[row, column];
                        smallest_number_column = column;
                    }
                }
            }
            Console.WriteLine($"{smallest_number} - smallest number, column: {smallest_number_column}");
            return smallest_number_column;
        }
        static void removeMatrixColumn(ref int[,] matrix, int column_0)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int column = column_0; column < matrix.GetLength(1) - 1; column++)
                {
                    matrix[i, column] = matrix[i, column + 1];
                }
            }
        }
        static void removeMatrixColumnsTask(ref int[,] matrix)
        {
            int biggest_number_column = findBiggestMatrixElementColumnUnderInclMainDiagonal(matrix);
            int smallest_number_column = findSmallestMatrixElementColumnAboveMainDiagonal(matrix);
            int smallest_number_column_offset = 0;
            removeMatrixColumn(ref matrix, biggest_number_column);
            if (biggest_number_column < smallest_number_column)
            {
                smallest_number_column_offset = 1;//TODO
            }
            removeMatrixColumn(ref matrix, smallest_number_column - smallest_number_column_offset);
        }
        static void outputIndentedMatrix(int[,] matrix, int columns_cap)
        {
            Console.Write("\t");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - columns_cap; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                if(row != matrix.GetLength(0) - 1) Console.Write("\n\t");
                else Console.Write("\n");
            }
        }
    }
}
