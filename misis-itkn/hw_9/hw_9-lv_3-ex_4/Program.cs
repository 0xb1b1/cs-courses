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
        public Participant[] GetStudents()
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
            int group_amount = 2;
            Participant[,] participant_groups = parseInputFile(@"C:\Users\voxel\git\cs-courses\misis-itkn\hw_9\hw_9-lv_3-ex_4\participants.list", group_amount);
            Participant[] participants_grp_0 = new Participant[3];
            Participant[] participants_grp_1 = new Participant[3];Console.WriteLine("DEBUG LINE 0"); Console.WriteLine($"GROUP AMOUNT PARSED {participant_groups.GetLength(0)}");
            for (int group = 0; group < participant_groups.GetLength(0); group++)
            {
                int current_group_participant = 0;
                while (participant_groups[group, current_group_participant] != null)
                { Console.WriteLine("DEBUG LINE 1"); Console.WriteLine($"Group: {group} Current member No: {current_group_participant}");Console.WriteLine("DEBUG LINE 2");
                    if (group == 0)
                    {Console.WriteLine($"Added {participant_groups[group, current_group_participant].GetFullName()} to grp 0");
                        participants_grp_0[current_group_participant] = participant_groups[group, current_group_participant];
                    }
                    else
                    {Console.WriteLine($"Added {participant_groups[group, current_group_participant].GetFullName()} to grp 1");
                        participants_grp_1[current_group_participant] = participant_groups[group, current_group_participant];
                    }
                    current_group_participant++;
                }
            }Console.WriteLine($"{participants_grp_0.Length} {participants_grp_1.Length}\n{participants_grp_0[1].GetFullName()} {participants_grp_0[1].GetScore()}");
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
        static Participant[,] parseInputFile(string path, int group_amount)
        {
            Participant[,] tmp_participants = new Participant[group_amount, File.ReadAllLines(path).Length];
            string line;
            StreamReader sr = new StreamReader(path);
            int group_participants_remaining = 0, total_participants = 0, current_group = 0;
            int[] group_sizes = new int[File.ReadAllLines(path).Length];
            while ((line = sr.ReadLine()) != null)
            {
                group_participants_remaining = int.Parse(line);Console.WriteLine($"GROUP PARTICIPANTS LINE: {group_participants_remaining}");
                int current_group_participant = 0;
                group_sizes[current_group] = group_participants_remaining;
                while (group_participants_remaining > 0)
                {
                    group_participants_remaining--;
                    line = sr.ReadLine();
                    tmp_participants[current_group, current_group_participant] = new Participant(line.Split(' ')[0], line.Split(' ')[1], float.Parse(line.Split(' ')[2]));
                    total_participants++; Console.WriteLine($"Added from parser {tmp_participants[current_group, current_group_participant].GetFullName()}, score: {tmp_participants[current_group, current_group_participant].GetScore()}");
                }
                current_group++;
            }
            return tmp_participants;
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
