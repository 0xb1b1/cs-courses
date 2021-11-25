using System;
namespace ConsoleApplication1
{
    struct Student
    {
        private string name;
        private float gpa = 0, grades_sum = 0;
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];
            students[0] = new Student("Oleg Bluntovich", new float[] {3.3F, 3.5F, 3.7F});
            students[1] = new Student("Kot Kotovich", new float[] {5, 4.4F, 3.7F});
            students[2] = new Student("Will Williams", new float[] {4.1F, 4, 3.9F});
            sortStudents(ref students);
            Console.WriteLine("Full name\tGPA");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].GetGPA() >= 4) Console.WriteLine("{0}\t{1}", students[i].GetName(), students[i].GetGPA());
            }
        }
        static void sortStudents(ref Student[] students)
        {
            Student temp;
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[i].GetGPA() < students[j].GetGPA())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
    }
}
