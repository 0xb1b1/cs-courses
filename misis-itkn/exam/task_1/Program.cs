using System;
namespace Task1
{
    class Program
    {
        static int findSmallestNeg(int[] arr, int w)
        {
            int smallest_neg = 0;
            int smallest_neg_index = -1;
            for(int i = 0; i < w; i++)
            {
                if(arr[i] < smallest_neg)
                {
                    smallest_neg = arr[i];
                    smallest_neg_index = i;
                }
            }
            return(smallest_neg_index);
        }
        static int findLastPos(int[] arr, int w)
        {
            int last_pos_index = -1;
            for(int i = 0; i < w; i++)
            {
                if(arr[i] > 0)
                {
                    last_pos_index = i;
                }
            }
            return(last_pos_index);
        }
        static void customSort(ref int[,] arr, int row, int a, int b)
        {
            for(int i = a + 1; i < b; i++)
            {
                int biggest_num = arr[row, i];
                int biggest_index = i;
                for(int j = i; j < b; j++)
                {
                    if(arr[row, j] > biggest_num)
                    {
                        biggest_num = arr[row, j];
                        biggest_index = j;
                    }
                    int swap = arr[row, i];
                    arr[row, i] = arr[row, j];
                    arr[row, j] = swap;
                }
            }
        }
        static int[] getRow(int[,] arr, int row, int w)
        {
            int[] output = new int[w];
            for(int i = 0; i < w; i++)
            {
                output[i] = arr[row, i];
            }
            return(output);
        }

        static void customMethod(ref int[,] arr, int w, int h)
        {
            for(int i = 0; i < h; i++)
            {
                int smallest_neg_index = findSmallestNeg(getRow(arr, i, w), w);
                int last_pos_index = findLastPos(getRow(arr, i, w), w);
                if(smallest_neg_index == -1 || last_pos_index == -1 || (last_pos_index - smallest_neg_index <= 1))
                {
                    continue;
                }
                customSort(ref arr, i, smallest_neg_index, last_pos_index);
            }
        }

        
        static void Main(string[] args)
        {
            const int width = 5, 
                height = 5;
            int[,] input_array = new int[width, height] {
                { -1, 2, 3, 4, 5}, // 4, 3, 2
                { 6,  7, 8, 9, 10}, // no negatives; do nothing
                { -1, -12, 13, 14, 15},    // 14; 13
                { -16, -17, -18, -19, -20},  // positive-only; do nothing
                { -22, -22, -23, 24, -25}   // only one number to sort; do nothing
            };
            customMethod(ref input_array, width, height);
            outputIndentedMatrix(input_array);
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
