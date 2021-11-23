using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array_0 = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            int[] array_1 = new int[8] { 8, 7, 6, 5, 4, 3, 2, 1 };
            Console.WriteLine("Input:");
            outputArrays(array_0, array_1);
            removeByIndex(ref array_0, biggestElementLocation(array_0));
            removeByIndex(ref array_1, biggestElementLocation(array_1));
            int[] out_array = array_0.Concat(array_1).ToArray();
            Console.WriteLine("Output:");
            outputArray(out_array);
        }
        static void removeByIndex(ref int[] array, int rm_index)
        {
            array = array.Where((source, index) =>index != rm_index).ToArray();
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
        static void outputArray(int[] array)
        {
            Console.Write("\t");
            for (int element = 0; element < array.GetLength(0); element++)
            {
                Console.Write($"{array[element]} ");
            }
            Console.WriteLine();
        }
        static void outputArrays(int[] array_0, int[] array_1)
        {
            Console.Write("array_0:\n\t");
            outputArray(array_0);
            Console.Write("array_1:\n\t");
            outputArray(array_1);
        }
    }
}