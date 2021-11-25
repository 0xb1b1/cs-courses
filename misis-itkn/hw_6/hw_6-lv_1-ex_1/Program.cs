using System;
namespace ConsoleApplication1
{
    struct Athlete
    {
        public string last_name, community;
        public int score_0, score_1, best_score;
        public Athlete(string last_name, string community, int score_0, int score_1)
        {
            this.last_name = last_name;
            this.community = community;
            this.score_0 = score_0;
            this.score_1 = score_1;
            this.best_score = Math.Max(score_0, score_1); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Athlete[] athletes = new Athlete[3];
            athletes[0] = new Athlete("Oleg Bluntovich", "A", 6, 7);
            athletes[1] = new Athlete("Kot Kotovich", "B", 4, 8);
            athletes[2] = new Athlete("Will Williams", "C", 6, 9);
            sortAthletes(ref athletes);
            Console.WriteLine("Full name\tCommunity\tBest score");
            for (int i = 0; i < athletes.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", athletes[i].last_name, athletes[i].community, athletes[i].best_score);
            }
        }
        static void sortAthletes(ref Athlete[] athletes)
        {
            Athlete temp;
            for (int i = 0; i < athletes.Length; i++)
            {
                for (int j = i + 1; j < athletes.Length; j++)
                {
                    if (athletes[i].best_score < athletes[j].best_score)
                    {
                        temp = athletes[i];
                        athletes[i] = athletes[j];
                        athletes[j] = temp;
                    }
                }
            }
        }
    }
}
