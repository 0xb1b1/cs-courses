using System;
namespace ConsoleApplication1
{
    struct Student
    {
        private string name, group;
        private float gpa = 0, grades_sum = 0;
        private float[] grades;
        public Student(string name, string group, float[] grades)
        {
            this.name = name;
            this.group = group;
            this.grades = grades;
            this.CalculateGPA();
        }
        public void CalculateGPA()
        {
            float marks_sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                marks_sum += grades[i];
            }
            this.gpa = marks_sum / grades.Length;
        }
        public float GetGPA()
        {
            return this.gpa;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetGroup()
        {
            return this.group;
        }
        public bool hasPassed()
        {
            for(int i = 0; i < grades.Length; i++)
            {
                if (this.grades[i] <= 2) return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            students[0] = new Student("Oleg Bluntovich", "BPM-21-1", new float[] {3.3F, 3.5F, 3.7F});
            students[1] = new Student("Kot Kotovich", "BPM-21-1", new float[] {2, 4.4F, 3.7F});
            students[2] = new Student("Will Williams", "BPM-21-3", new float[] {4.1F, 4, 3.9F});
            students[3] = new Student("Xandra Uwu", "BPM-21-2", new float[] {3.3F, 2.3F, 4.6F});
            students[4] = new Student("Axel Abobovich", "BPM-21-2", new float[] {2.5F, 4.4F, 4.1F});
            int expelled_students = sortStudents(ref students);
            Console.WriteLine("Full name\tGPA");
            for (int i = 0; i < students.Length - expelled_students; i++)
            {
                Console.WriteLine("{0}\t{1}", students[i].GetName(), students[i].GetGPA());
            }
        }
        static string[] listGroups(Student[] students) {
            string[] groups = new string[students.Length];
            for (int i = 0; i < students.Length; i++)
            {
                if (!groups.Contains(students[i].GetGroup()))
                {
                    groups[group_amount] = students[i].GetGroup();
                }
            }
            return groups;
        }
    }
}