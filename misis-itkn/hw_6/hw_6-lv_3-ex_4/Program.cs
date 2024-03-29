﻿using System;
namespace ConsoleApplication1
{
    struct Participant
    {
        private string first_name, last_name, full_name;
        private float score;
        public Participant(string first_name, string last_name, float score)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
            this.score = score;
        }
        public float GetScore()
        {
            return this.score;
        }
        public string GetFullName()
        {
            return this.full_name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string table_title = "Ski race results";
            Participant[] participants_grp_0 = new Participant[3];
            Participant[] participants_grp_1 = new Participant[3];
            // group 0
            participants_grp_0[0] = new Participant("Oleg", "Styopovich", 5.4F);
            participants_grp_0[1] = new Participant("Kot", "Artyomovich", 6.3F);
            participants_grp_0[2] = new Participant("Galina", "Kry'nya", 8.4F);
            // group 1
            participants_grp_1[0] = new Participant("Anya", "Ahhhhhh", 7);
            participants_grp_1[1] = new Participant("Excel", "Breightnbikher",4.99F);
            participants_grp_1[2] = new Participant("Tema", "Claudrepovich", 5.3F);
            sortParticipantGroup(ref participants_grp_0);
            sortParticipantGroup(ref participants_grp_1);
            Console.WriteLine(table_title);

            // sort and place all values from participants_grp_0 and participants_grp_1 into the final array
            Participant[] final_array = new Participant[participants_grp_1.Length + participants_grp_0.Length];
            int i = 0, j = 0, k = 0;
            int n1 = participants_grp_0.Length, n2 = participants_grp_1.Length;
            while (i < n1 && j < n2)
            {
                if (participants_grp_0[i].GetScore() > participants_grp_1[j].GetScore())
                {
                    final_array[k++] = participants_grp_0[i++];
                }
                else
                {
                    final_array[k++] = participants_grp_1[j++];
                }
            }
            while (i < n1)
            {
                final_array[k++] = participants_grp_0[i++];
            }
            while (j < n2)
            {
                final_array[k++] = participants_grp_1[j++];
            }

            Console.WriteLine("Groups:");
            printGroup(final_array);
        }
        static void sortParticipantGroup(ref Participant[] participant_group)
        {
            for (int i = 0; i < participant_group.Length; i++)
            {
                for (int j = i + 1; j < participant_group.Length; j++)
                {
                    if (participant_group[i].GetScore() < participant_group[j].GetScore())
                    {
                        Participant temp = participant_group[i];
                        participant_group[i] = participant_group[j];
                        participant_group[j] = temp;
                    }
                }
            }
        }
        static void printGroup(Participant[] participant_group)
        {
            for (int i = 0; i < participant_group.Length; i++)
            {
                Console.WriteLine($"{participant_group[i].GetFullName()} - {participant_group[i].GetScore()}");
            }
        }
    }
}
