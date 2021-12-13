using System;
namespace ConsoleApplication1
{
    struct Participant
    {
        private string first_name, last_name, full_name, group;
        private float score;
        public Participant(string first_name, string last_name, string group, float score)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
            this.group = group;
            this.score = score;
        }
        public void SetScore(float score)
        {
            this.score = score;
        }
        public float GetScore()
        {
            return this.score;
        }
        public void SetFullName(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
        }
        public void SetFirstName(string first_name)
        {
            this.first_name = first_name;
            this.full_name = $"{first_name} {this.last_name}";
        }
        public void SetLastName(string last_name)
        {
            this.last_name = last_name;
            this.full_name = $"{this.first_name} {last_name}";
        }
        public string GetFullName()
        {
            return this.full_name;
        }
        public string GetFirstName()
        {
            return this.first_name;
        }
        public string GetLastName()
        {
            return this.last_name;
        }
        public void SetGroupName(string group)
        {
            this.group = group;
        }
        public string GetGroupName()
        {
            return this.group;
        }
    }

    struct ParticipantGroup
    {
        private Participant[] participants;
        private string group_name = "";
        private int participant_count = 0;
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
        public void RemoveParticipant(string full_name)
        {
            Participant[] new_students = new Participant[this.participant_count - 1];
            int index = 0;
            for (int i = 0; i < this.participant_count; i++)
            {
                if (this.participants[i].GetFullName() != full_name)
                {
                    new_students[index] = this.participants[i];
                    index++;
                }
            }
            this.participants = new_students;
            this.participant_count--;
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
            printTableOfParticipantsByGroup(participant_groups, table_title);
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
        static void printTableOfParticipantsByGroup(ParticipantGroup[] participant_groups, string table_title)
        {
            Console.WriteLine($"{table_title}\n");
            string entry_tabs = "\t\t", shortened_string_tabs = "\t\t\t";
            for (int group = 0; group < participant_groups.Length; group++)
            {
                Console.WriteLine($"Group {participant_groups[group].GetGroupName()}{entry_tabs}Average GPA: {participant_groups[group].GetAverageScore()}");
                Console.WriteLine($"Participant{shortened_string_tabs}GPA");
                for (int participant = 0; participant < participant_groups[group].GetStudents().Length; participant++)
                {
                    Console.WriteLine($"{participant_groups[group].GetStudents()[participant].GetFullName()}{entry_tabs}{participant_groups[group].GetStudents()[participant].GetScore()}");
                }
                Console.WriteLine();
            }
        }
    }
}
