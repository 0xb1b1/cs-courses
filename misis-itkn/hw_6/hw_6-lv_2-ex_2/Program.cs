using System;
namespace ConsoleApplication1
{
    struct Student
    {
        private string name;
        private float gpa = 0;
        private float[] grades;
        public Student(string name, float[] grades)
        {
            this.name = name;
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
            Student[] students = new Student[6];
            students[0] = new Student("Oleg Styopovich", new float[] {3.3F, 2, 3.7F});
            students[1] = new Student("Kot Kotovich", new float[] {2, 4.4F, 3.7F});
            students[2] = new Student("Sergey MkUltramarine", new float[] {4.1F, 4, 3.9F});
            students[3] = new Student("Uwu owO", new float[] {3.3F, 4.4F, 2.1F});
            students[4] = new Student("Pig Puggovich", new float[] {2.112F, 3.1F, 3.43F});
            students[5] = new Student("Test Guinea", new float[] {2, 4.4F, 3.7F});
            int expelled_students = sortStudents(ref students);
            Console.WriteLine("Full name\tGPA");
            for (int student = 0; student < students.Length - expelled_students; student++)
            {
                Console.WriteLine("{0}\t{1}", students[student].GetName(), students[student].GetGPA());
            }
        }
        static int sortStudents(ref Student[] students)
        {
            int expelled_count = 0;
            Student temp;
            for (int student = 0; student < students.Length; student++)
            {
                for (int check = student + 1; check < students.Length; check++)
                {
                    if (students[student].GetGPA() < students[check].GetGPA())
                    {
                        temp = students[student];
                        students[student] = students[check];
                        students[check] = temp;
                    }
                }
            }
            for (int student = 0; student < students.Length; student++)
            {
                if (!students[student].hasPassed())
                {
                    for (int check = student; check < students.Length - 1; check++)
                    {
                        students[check] = students[check + 1];
                    }
                    expelled_count++;
                }
            }
            return expelled_count;
        }
    }
}
