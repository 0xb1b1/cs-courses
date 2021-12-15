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
        private string group;
        private float score;
        public Participant(string first_name, string last_name, string group, float score)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
            this.group = group;
            this.score = score;
        }
        public float GetScore()
        {
            return this.score;
        }
        public string GetGroupName()
        {
            return this.group;
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
            Participant[] participants = new Participant[6];
            participants[0] = new Participant("Oleg", "Styopovich", "CloudBusters", 5.4F);
            participants[1] = new Participant("Kot", "Artyomovich", "CloudBusters", 6.3F);
            participants[2] = new Participant("Anya", "Ahhhhhh", "BluntFinders", 7);
            participants[3] = new Participant("Galina", "Kry'nya", "CloudBusters", 8.4F);
            participants[4] = new Participant("Excel", "Breightnbikher", "BluntFinders", 4.99F);
            participants[5] = new Participant("Tema", "Claudrepovich", "BluntFinders", 5.3F);
            ParticipantGroup[] participant_groups = new ParticipantGroup[listGroups(participants).Length];
            sortStudentsByGroup(ref participant_groups, participants);
            sortGroupsByAverageGPA(ref participant_groups);
            sortGrouppedParticipantsByScore(ref participant_groups);
            printTableOfParticipants(participant_groups, table_title);
        }
        static void sortGrouppedParticipantsByScore(ref ParticipantGroup[] participant_groups)
        {
            for (int group = 0; group < participant_groups.Length; group++)
            {
                participant_groups[group].SortByScore();
            }
        }
        static string[] listGroups(Participant[] participants) {
            string[] groups = new string[participants.Length];
            int group_amount = 0;
            for (int i = 0; i < participants.Length; i++)
            {
                if (!groups.Contains(participants[i].GetGroupName()))
                {
                    groups[group_amount] = participants[i].GetGroupName();
                    group_amount++;
                }
            }
            string[] new_groups = new string[group_amount];
            for (int i = 0; i < group_amount; i++)
            {
                new_groups[i] = groups[i];
            }
            return new_groups;
        }
        static void sortGroupsByAverageGPA(ref ParticipantGroup[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length - 1; j++)
                {
                    if (groups[j].GetAverageScore() < groups[j + 1].GetAverageScore())
                    {
                        ParticipantGroup temp = groups[j];
                        groups[j] = groups[j + 1];
                        groups[j + 1] = temp;
                    }
                }
            }
        }
        static void sortStudentsByGroup(ref ParticipantGroup[] participant_groups, Participant[] participants) {
            string[] groups = listGroups(participants);
            for (int group = 0; group < groups.Length; group++)
            {
                participant_groups[group] = new ParticipantGroup(new Participant[0]);
                participant_groups[group].SetGroupName(groups[group]);
                for (int participant = 0; participant < participants.Length; participant++)
                {
                    if (participant_groups[group].GetGroupName() == participants[participant].GetGroupName())
                    {
                        participant_groups[group].AddParticipant(participants[participant]);
                    }
                }
            }
        }
        static Participant[] mergeParticipantGroups(ParticipantGroup[] participant_groups)
        {
            int participant_count = 0;
            for (int participant_group = 0; participant_group < participant_groups.Length; participant_group++)
            {
                participant_count += participant_groups[participant_group].GetParitipantCount();
            }
            Participant[] participants = new Participant[participant_count];
            int participant_index = 0;
            for (int i = 0; i < participant_groups.Length; i++)
            {
                Participant[] group_participants = participant_groups[i].GetStudents();
                for (int j = 0; j < group_participants.Length; j++)
                {
                    participants[participant_index] = group_participants[j];
                    participant_index++;
                }
            }
            return participants;
        }
        static void printTableOfParticipants(ParticipantGroup[] participant_groups, string table_title)
        {
            Participant[] participants = mergeParticipantGroups(participant_groups);
            Console.WriteLine($"{table_title}\n");
            string entry_tabs = "\t\t", shortened_string_tabs = "\t\t\t";
            Console.WriteLine($"Participant{shortened_string_tabs}GPA{shortened_string_tabs}Group");
            for (int participant = 0; participant < participants.Length; participant++)
            {
                Console.WriteLine($"{participants[participant].GetFullName()}{entry_tabs}{participants[participant].GetScore()}{entry_tabs}{participants[participant].GetGroupName()}");
            }
            Console.WriteLine();
        }
    }
}
