using System;
using System.Text;
using System.IO;
namespace ConsoleApplication1
{
    class Person
    {
        public string first_name = "", last_name = "", full_name = "";
        public string GetFullName()
        {
            return this.full_name;
        }
    }
    class Group
    {
        public Participant[] participants = new Participant[0];
        public string group_name = "";
        public int participant_count = 0;
        public Participant[] GetParticipants()
        {
            return this.participants;
        }
        public string GetGroupName()
        {
            return this.group_name;
        }
        public void SetGroupName(string group_name)
        {
            this.group_name = group_name;
        }
        public int GetParitipantCount()
        {
            return this.participant_count;
        }
    }
    class Participant : Person
    {
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
    }

    class ParticipantGroup : Group
    {
        private float average_score = 0;
        public ParticipantGroup(Participant[] participants)
        {
            this.participants = participants;
            this.participant_count = participants.Length;
            CalculateAverageScore();
        }
        public void AddParticipant(Participant participant)
        {
            Participant[] new_participants = new Participant[this.participant_count + 1];
            for (int i = 0; i < this.participant_count; i++)
            {
                new_participants[i] = this.participants[i];
            }
            new_participants[this.participant_count] = participant;
            this.participants = new_participants;
            this.participant_count++;
            CalculateAverageScore();
        }
        public void SortByScore()
        {
            Participant[] new_participants = new Participant[this.participant_count];
            for (int i = 0; i < this.participant_count; i++)
            {
                new_participants[i] = this.participants[i];
            }
            for (int i = 0; i < this.participant_count; i++)
            {
                for (int j = 0; j < this.participant_count - 1; j++)
                {
                    if (new_participants[j].GetScore() < new_participants[j + 1].GetScore())
                    {
                        Participant temp = new_participants[j];
                        new_participants[j] = new_participants[j + 1];
                        new_participants[j + 1] = temp;
                    }
                }
            }
            this.participants = new_participants;
        }
        public void CalculateAverageScore()
        {
            float sum = 0;
            for (int i = 0; i < this.participant_count; i++)
            {
                sum += this.participants[i].GetScore();
            }
            this.average_score = sum / this.participant_count;
        }
        public float GetAverageScore()
        {
            return this.average_score;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string table_title = "Ski race results";
            string input_file_path = "participants.list";   // Should be located in the project's root directory
            /* INPUT FILE FORMAT

                <amount of groups>
                <amount of partitipants in the first group>
                <participant>[participant's full name] [participant's score]</participant>
                ...
                <amount of partitipants in the second group>
                <participant>[participant's full name] [participant's score]</participant>
                ...%

            */
            Participant[,] participant_groups = parseInputFile(input_file_path);
            Participant[] participants_grp_0 = new Participant[3];
            Participant[] participants_grp_1 = new Participant[3];
            for (int group = 0; group < participant_groups.GetLength(0); group++)
            {
                int current_group_participant = 0;
                while (participant_groups[group, current_group_participant] != null)
                {
                    if (group == 0)
                    {
                        participants_grp_0[current_group_participant] = participant_groups[group, current_group_participant];
                    }
                    else
                    {
                        participants_grp_1[current_group_participant] = participant_groups[group, current_group_participant];
                    }
                    current_group_participant++;
                }
            }
            sortParticipantGroup(ref participants_grp_0);
            sortParticipantGroup(ref participants_grp_1);
            Console.WriteLine(table_title);

            // Sort and place all values from participants_grp_0 and participants_grp_1 into the final array
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
            Console.Write("\nSave the list in a file (y/N): ");
            string answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "y" || answer == "Y")
            {
                Console.WriteLine("Enter a file name: ");
                string filename = Console.ReadLine();
                saveToFile(final_array, filename);
            }
            Console.WriteLine("Have a good day!");
        }
        static void saveToFile(Participant[] array, string output_filename)
        {
            StreamWriter sw = new StreamWriter(output_filename);
            for (int i = 0; i < array.Length; i++)
            {
                sw.WriteLine($"{array[i].GetFullName()} {array[i].GetScore()}");
            }
            sw.Close();
        }
        static Participant[,] parseInputFile(string path)
        {
            string line;
            StreamReader sr = new StreamReader(path);   // Open the input file in read-only mode
            int group_amount = int.Parse(sr.ReadLine());   // Read the amount of groups (first line)
            Participant[,] tmp_participants = new Participant[group_amount, File.ReadAllLines(path).Length];    // Create a 2D array to sort participants by groups
            int group_participants_remaining = 0, current_group = 0;
            // Parse the input file line by line
            while ((line = sr.ReadLine()) != null)  // Go on until sr is empty
            {
                group_participants_remaining = int.Parse(line); // Get the number of participants in the current group
                int current_group_participant = 0;  // Index of the current participant in the current group (incremented)
                while (group_participants_remaining > 0)    // For each group
                {
                    group_participants_remaining--;   // Decrement the number of participants in the current group
                    line = sr.ReadLine();
                    tmp_participants[current_group, current_group_participant] = new Participant(line.Split(' ')[0], line.Split(' ')[1], float.Parse(line.Split(' ')[2]));  // Create a new participant and add it to the current group
                    current_group_participant++;  // Increment the current group participant index
                }
                current_group++;    // Increment the current group index
            }
            return tmp_participants;    // Return the 2D array
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
