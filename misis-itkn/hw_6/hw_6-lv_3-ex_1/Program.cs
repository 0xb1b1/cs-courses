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
        public void SetGrades(float[] grades)
        {
            this.grades = grades;
            this.CalculateGPA();
        }
        public void AddGrade(float grade)
        {
            Array.Resize(ref this.grades, this.grades.Length + 1);
            this.grades[this.grades.Length - 1] = grade;
            this.CalculateGPA();
        }
        public float GetGPA()
        {
            return this.gpa;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
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

    struct StudentGroup
    {
        private Student[] students;
        private string group_name = "";
        private int students_count = 0;
        public StudentGroup(Student[] students)
        {
            this.students = students;
            this.students_count = students.Length;
        }
        public void AddStudent(Student student)
        {
            Student[] new_students = new Student[this.students_count + 1];
            for (int i = 0; i < this.students_count; i++)
            {
                new_students[i] = this.students[i];
            }
            new_students[this.students_count] = student;
            this.students = new_students;
            this.students_count++;
        }
        public void RemoveStudent(int index)
        {
            Student[] new_students = new Student[this.students_count - 1];
            for (int i = 0; i < index; i++)
            {
                new_students[i] = this.students[i];
            }
            for (int i = index; i < this.students_count - 1; i++)
            {
                new_students[i] = this.students[i + 1];
            }
            this.students = new_students;
            this.students_count--;
        }
        public void SortByGPA()
        {
            Student[] new_students = new Student[this.students_count];
            for (int i = 0; i < this.students_count; i++)
            {
                new_students[i] = this.students[i];
            }
            for (int i = 0; i < this.students_count; i++)
            {
                for (int j = 0; j < this.students_count - 1; j++)
                {
                    if (new_students[j].GetGPA() < new_students[j + 1].GetGPA())
                    {
                        Student temp = new_students[j];
                        new_students[j] = new_students[j + 1];
                        new_students[j + 1] = temp;
                    }
                }
            }
            this.students = new_students;
        }
        public float GetAverageGPA()
        {
            float sum = 0;
            for (int i = 0; i < this.students_count; i++)
            {
                sum += this.students[i].GetGPA();
            }
            return sum / this.students_count;
        }
        public Student[] GetStudents()
        {
            return this.students;
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
            Student[] students = new Student[5];
            students[0] = new Student("Oleg Bluntovich", "BPM-21-1", new float[] {3.3F, 3.5F, 3.7F});
            students[1] = new Student("Kot Kotovich", "BPM-21-1", new float[] {2, 4.4F, 3.7F});
            students[2] = new Student("Will Williams", "BPM-21-3", new float[] {4.1F, 4, 3.9F});
            students[3] = new Student("Xandra Uwu", "BPM-21-2", new float[] {3.3F, 2.3F, 4.6F});
            students[4] = new Student("Axel Abobovich", "BPM-21-2", new float[] {2.5F, 4.4F, 4.1F});
            StudentGroup[] student_groups = new StudentGroup[listGroups(students).Length];
            sortStudentsByGroup(ref student_groups, students);
            sortGroupsByAverageGPA(ref student_groups);
            for (int group = 0; group < student_groups.Length; group++)
            {
                student_groups[group].SortByGPA();
            }
            string[] student_group_names = listGroups(students);
            printStudentGroups(student_groups);
        }
        static string[] listGroups(Student[] students) {
            string[] groups = new string[students.Length];
            int group_amount = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (!groups.Contains(students[i].GetGroupName()))
                {
                    groups[group_amount] = students[i].GetGroupName();
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
        static void sortGroupsByAverageGPA(ref StudentGroup[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length - 1; j++)
                {
                    if (groups[j].GetAverageGPA() < groups[j + 1].GetAverageGPA())
                    {
                        StudentGroup temp = groups[j];
                        groups[j] = groups[j + 1];
                        groups[j + 1] = temp;
                    }
                }
            }
        }
        static void sortStudentsByGroup(ref StudentGroup[] student_groups, Student[] students) {
            string[] groups = listGroups(students);
            for (int group = 0; group < groups.Length; group++)
            {
                student_groups[group] = new StudentGroup(new Student[0]);
                student_groups[group].SetGroupName(groups[group]);
                for (int student = 0; student < students.Length; student++)
                {
                    if (student_groups[group].GetGroupName() == students[student].GetGroupName())
                    {
                        student_groups[group].AddStudent(students[student]);
                    }
                }
            }
        }
        static void printStudentGroups(StudentGroup[] student_groups)
        {
            for (int group = 0; group < student_groups.Length; group++)
            {
                Console.WriteLine($"Group {student_groups[group].GetGroupName()}\tAverage GPA: {student_groups[group].GetAverageGPA()}");
                Console.WriteLine("Student\t\tGPA");
                for (int student = 0; student < student_groups[group].GetStudents().Length; student++)
                {
                    Console.WriteLine($"{student_groups[group].GetStudents()[student].GetName()}\t{student_groups[group].GetStudents()[student].GetGPA()}");
                }
                Console.WriteLine();
            }
        }
    }
}
