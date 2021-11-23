using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int array_1_size = 8, array_0_size_orig = 7;
            const int array_0_size = array_0_size_orig + array_1_size - 2;
            int[] array_0 = new int[array_0_size] { 1, 2, 3, 4, 5, 7, 6, 0, 0, 0, 0, 0, 0};
            int[] array_1 = new int[array_1_size] { 8, 7, 6, 5, 4, 3, 2, 1 };
            Console.WriteLine("Input:");
            outputArrays(array_0, array_0_size - array_0_size_orig, array_1, 0);
            removeByIndex(ref array_0, biggestElementLocation(array_0));
            removeByIndex(ref array_1, biggestElementLocation(array_1));
            //int[] out_array = array_0.Concat(array_1).ToArray();
            concatArrays(ref array_0, array_1, array_0_size_orig - 1, 1);
            Console.WriteLine("Output:");
            outputArray(array_0, 0);
        }
        static void concatArrays(ref int[] array_0, int[] array_1, int start_index, int offset)
        {
            for (int i = 0; i < array_1.Length - offset; i++)
            {
                array_0[i + start_index] = array_1[i];
            }
        }
        static void removeByIndex(ref int[] array, int rm_index)
        {
            //array = array.Where((source, index) =>index != rm_index).ToArray();
            for (int i = rm_index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
        static int biggestElementLocation(int[] array)
        {
            int biggest = array[0];
            int biggest_index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > biggest)
                {
                    biggest = array[i];
                    biggest_index = i;
                }
            }
            return biggest_index;
        }
        static void outputArray(int[] array, int offset)
        {
            Console.Write("\t");
            for (int element = 0; element < array.Length - offset; element++)
            {
                Console.Write($"{array[element]} ");
            }
            Console.WriteLine();
        }
        static void outputArrays(int[] array_0, int offset_0, int[] array_1, int offset_1)
        {
            Console.Write("array_0:\n\t");
            outputArray(array_0, offset_0);
            Console.Write("array_1:\n\t");
            outputArray(array_1, offset_1);
        }
    }
}