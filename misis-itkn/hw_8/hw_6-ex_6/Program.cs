using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = "aadfda iifffii ifffii uufffuuu";
            string vowels = "a e i o u y";
            string[] words_list = words.Split(' ');
            string[] vowels_list = vowels.Split(' ');
            int[] syllable_count_list = new int[words_list.Length];

            for (int word = 0; word < words_list.Length; word++)
            {
                for (int letter = 0; letter < words_list[word].Length; letter++)
                {
                    for (int vowel = 0; vowel < vowels_list.Length; vowel++)
                    {
                        if (words_list[word][letter] == vowels_list[vowel][0])
                        {
                            syllable_count_list[word]++;
                        }
                    }
                }
            }
            int[,] distinct_syllable_counts = new int[syllable_count_list.Length, 2];
            int distinct_syllable_counts_index = 0;
            for (int i = 0; i < syllable_count_list.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < distinct_syllable_counts_index; j++)
                {
                    if (syllable_count_list[i] == distinct_syllable_counts[j, 0])
                    {
                        found = true;
                        distinct_syllable_counts[j, 1]++;
                    }
                }
                if (!found)
                {
                    distinct_syllable_counts[distinct_syllable_counts_index, 0] = syllable_count_list[i];
                    distinct_syllable_counts[distinct_syllable_counts_index, 1] = 1;
                    distinct_syllable_counts_index++;
                }
            }

            for (int i = 0; i < syllable_count_list.Length; i++)
            {
                Console.WriteLine(words_list[i] + ": " + syllable_count_list[i]);
            }
            for (int i = 0; i < distinct_syllable_counts_index; i++)
            {
                Console.WriteLine(distinct_syllable_counts[i, 0] + ": " + distinct_syllable_counts[i, 1]);
            }
        }
    }
}
