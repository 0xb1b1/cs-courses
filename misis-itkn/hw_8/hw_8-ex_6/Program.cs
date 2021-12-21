using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = "This is a nice string";
            string vowels = "a e i o u y";
            string[] word_list = words.Split(' ');
            string[] vowels_list = vowels.Split(' ');
            int[] syllable_count_list = new int[word_list.Length];

            for (int word = 0; word < word_list.Length; word++)
            {
                for (int letter = 0; letter < word_list[word].Length; letter++)
                {
                    for (int vowel = 0; vowel < vowels_list.Length; vowel++)
                    {
                        if (word_list[word][letter] == vowels_list[vowel][0])
                        {
                            syllable_count_list[word]++;
                        }
                    }
                }
                if (syllable_count_list[word] == 0)
                {
                    syllable_count_list[word] = 1;
                }
            }
            
            // count unique syllable counts
            int[] unique_syllables = new int[word_list.Length];
            int unique_syllables_count = 0;
            for (int word = 0; word < word_list.Length; word++)
            {
                bool unique = true;
                for (int unique_word = 0; unique_word < unique_syllables_count; unique_word++)
                {
                    if (syllable_count_list[word] == unique_syllables[unique_word])
                    {
                        unique = false;
                    }
                }
                if (unique)
                {
                    unique_syllables[unique_syllables_count] = syllable_count_list[word];
                    unique_syllables_count++;
                }
            }

            // sort unique syllable counts
            for (int i = 0; i < unique_syllables_count; i++)
            {
                for (int j = 0; j < unique_syllables_count - 1; j++)
                {
                    if (unique_syllables[j] > unique_syllables[j + 1])
                    {
                        int temp = unique_syllables[j];
                        unique_syllables[j] = unique_syllables[j + 1];
                        unique_syllables[j + 1] = temp;
                    }
                }
            }

            // print input data
            Console.WriteLine($"Input data:\n{words}\n------------------------------");

            // print unique syllable counts
            int current_syllable_count = 0;
            Console.WriteLine("Syllable count:\t| Occurrences:");
            foreach (int i in unique_syllables)
            {
                if (current_syllable_count >= unique_syllables_count)
                {
                    break;
                }
                int this_syllable_count = 0;
                foreach (int j in syllable_count_list)
                {
                    if (j == i)
                    {
                        this_syllable_count++;
                    }
                }
                Console.WriteLine($"{i}\t\t| {this_syllable_count}");
                current_syllable_count++;
            }
        }
    }
}
