using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input_string = "this is a very veeeery long string that contains stringey things storing stringz in a string";
            string[] words = input_string.Split(' ');
            string search_string = "str";

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = i + 1; j < word.Length; j++)
                    {
                        if (word.Substring(i, j - i) == search_string)
                        {
                            Console.WriteLine(word);
                        }
                    }
                }
            }
        }
    }
}
