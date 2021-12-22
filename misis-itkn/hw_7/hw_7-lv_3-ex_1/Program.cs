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
        public string group_name = "";
        public string GetGroupName()
        {
            return this.group_name;
        }
        public void SetGroupName(string group_name)
        {
            this.group_name = group_name;
        }
    }
    class Student : Person
    {
        private string group;
        private float gpa = 0;
        private float[] grades;
        public Student(string first_name, string last_name, string group, float[] grades)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
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
        public float GetGPA()
        {
            return this.gpa;
        }
        public string GetGroupName()
        {
            return this.group;
        }
    }

    class StudentGroup : Group
    {
        private Student[] students;
        private int student_count = 0;
        private float average_gpa = 0;
        public StudentGroup(Student[] students)
        {
            this.students = students;
            this.student_count = students.Length;
        }
        public void AddStudent(Student student)
        {
            Student[] new_students = new Student[this.student_count + 1];
            for (int i = 0; i < this.student_count; i++)
            {
                new_students[i] = this.students[i];
            }
            new_students[this.student_count] = student;
            this.students = new_students;
            this.student_count++;
            CalculateAverageGPA();
        }
        public void SortByGPA()
        {
            Student[] new_students = new Student[this.student_count];
            for (int i = 0; i < this.student_count; i++)
            {
                new_students[i] = this.students[i];
            }
            for (int i = 0; i < this.student_count; i++)
            {
                for (int j = 0; j < this.student_count - 1; j++)
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
        public void CalculateAverageGPA()
        {
            float gpa_sum = 0;
            for (int i = 0; i < this.student_count; i++)
            {
                gpa_sum += this.students[i].GetGPA();
            }
            this.average_gpa = gpa_sum / this.student_count;
        }
        public float GetAverageGPA()
        {
            return this.average_gpa;
        }
        public Student[] GetStudents()
        {
            return this.students;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string table_name = "Student groups - GPA rating";
            Student[] students = new Student[6];
            students[0] = new Student("Oleg", "Styopovich", "BPM-21-1", new float[] {3.3F, 3.5F, 3.7F});
            students[1] = new Student("Kot", "Artyomovich", "BPM-21-1", new float[] {2, 4.4F, 3.7F});
            students[2] = new Student("Anya", "Ahhhhhh", "BPM-21-3", new float[] {4.1F, 4, 3.9F});
            students[3] = new Student("Galina", "Kry'nya", "BPM-21-2", new float[] {3.3F, 2.3F, 4.6F});
            students[4] = new Student("Excel", "Breightnbikher", "BPM-21-2", new float[] {2.5F, 4.4F, 4.1F});
            students[5] = new Student("Tema", "Claudrepovich", "BPM-21-1", new float[] {2.2F, 4.7F, 3.99F});
            StudentGroup[] student_groups = new StudentGroup[listGroups(students).Length];
            sortStudentsByGroup(ref student_groups, students);
            sortGroupsByAverageGPA(ref student_groups);
            sortGrouppedStudentsByGPA(ref student_groups);
            printTableOfStudentsByGroup(student_groups, table_name);
        }
        static void sortGrouppedStudentsByGPA(ref StudentGroup[] student_groups)
        {
            for (int group = 0; group < student_groups.Length; group++)
            {
                student_groups[group].SortByGPA();
            }
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
        static void printTableOfStudentsByGroup(StudentGroup[] student_groups, string table_title)
        {
            Console.WriteLine($"{table_title}\n");
            string entry_tabs = "\t\t", shortened_string_tabs = "\t\t\t";
            for (int group = 0; group < student_groups.Length; group++)
            {
                Console.WriteLine($"Group {student_groups[group].GetGroupName()}{entry_tabs}Average GPA: {student_groups[group].GetAverageGPA()}");
                Console.WriteLine($"Student{shortened_string_tabs}GPA");
                for (int student = 0; student < student_groups[group].GetStudents().Length; student++)
                {
                    Console.WriteLine($"{student_groups[group].GetStudents()[student].GetFullName()}{entry_tabs}{student_groups[group].GetStudents()[student].GetGPA()}");
                }
                Console.WriteLine();
            }
        }
    }
}
