using System;
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
