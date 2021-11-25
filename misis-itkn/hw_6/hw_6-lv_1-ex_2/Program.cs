using System;
namespace ConsoleApplication1
{
    struct CrossAthlete
    {
        private string name, instructor_last_name;
        private char group;
        private float time;
        public static int treshold;
        public CrossAthlete(string name, string instructor_last_name, char group, float time)
        {
            this.name = name;
            this.instructor_last_name = instructor_last_name;
            this.group = group;
            this.time = time;
        }
        public float getTime()
        {
            return time;
        }
        public string getName()
        {
            return name;
        }
        public string getInstructorLastName()
        {
            return instructor_last_name;
        }
        public char getGroup()
        {
            return group;
        }
        public bool hasPassed()
        {
            return time <= treshold;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CrossAthlete.treshold = 10;
            CrossAthlete[] cross_athletes = new CrossAthlete[3];
            cross_athletes[0] = new CrossAthlete("Oleg Bluntovich", "McGregor", 'A', 9.69F);
            cross_athletes[1] = new CrossAthlete("Kot Popovich", "Fizruk", 'B', 11.11F);
            cross_athletes[2] = new CrossAthlete("Will Aboba", "Fizruk", 'C', 2.1337F);
            sortCrossAthletes(ref cross_athletes);
            Console.WriteLine("Passed (y/n)\tName\tGroup\tInstructor\tTime");
            for (int i = 0; i < cross_athletes.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", cross_athletes[i].hasPassed() == true ? "Yes" : "No", cross_athletes[i].getName(), cross_athletes[i].getGroup(), cross_athletes[i].getInstructorLastName(), cross_athletes[i].getTime());
            }
        }
        static void sortCrossAthletes(ref CrossAthlete[] cross_athletes)
        {
            for (int i = 0; i < cross_athletes.Length; i++)
            {
                for (int j = i + 1; j < cross_athletes.Length; j++)
                {
                    if (cross_athletes[i].getTime() > cross_athletes[j].getTime())
                    {
                        CrossAthlete temp = cross_athletes[i];
                        cross_athletes[i] = cross_athletes[j];
                        cross_athletes[j] = temp;
                    }
                }
            }
        } 
    }
}
