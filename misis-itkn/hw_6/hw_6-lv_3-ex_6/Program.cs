using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Response[] survey_responses = new Response[6];
            survey_responses[0] = new Response(new string []{
                "Python",
                "Creativity",
                "Lewdness"
                });
            survey_responses[1] = new Response(new string [] {
                "Panda",
                "Work affinity",
                "Notebook"
                });
            survey_responses[2] = new Response(new string [] {
                "Panda",
                "Creativity",
                "Anime"
                });
            survey_responses[3] = new Response(new string [] {
                "Blue bird",
                "Creativity",
                "Notebook"
                });
            survey_responses[4] = new Response(new string [] {
                "C++",
                "",
                "Lewdness"
                });
            survey_responses[5] = new Response(new string [] {
                "RapPanda",
                "Musical ability",
                "Laptop"
                });
            Console.WriteLine("Input data:\nRsp. pt. 1:\t\tRsp. pt. 2:\t\tRsp. pt. 3:");
            for (int i = 0; i < survey_responses.Length; i++) {
                Console.WriteLine("{0}\t\t{1}\t\t{2}", survey_responses[i].answer_0, survey_responses[i].answer_1, survey_responses[i].answer_2);
            }
            findAverages(survey_responses);
            relocateAverages(survey_responses);
            sortResponses(survey_responses);
            Console.WriteLine("--------------------\nOutput:\n5 most popular survey responses:\nRsp. pt. 1:\t%\tRsp. pt. 2:\t%\tRsp. pt. 3:\t%");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}\t{1:n1}\t{2}\t{3:n1}\t{4}\t{5:n1}", survey_responses[i].answer_0, survey_responses[i].average_0, survey_responses[i].answer_1, survey_responses[i].average_1, survey_responses[i].answer_2, survey_responses[i].average_2);
            }
        }
    struct Response
    {
        public string answer_0, answer_1, answer_2;
        public float average_0, average_1, average_2;
        public Response(string[] answers)
        {
            this.answer_0 = answers[0];
            this.answer_1 = answers[1];
            this.answer_2 = answers[2];
            this.average_0 = 0;
            this.average_1 = 0;
            this.average_2 = 0;
        }
    }
        static void relocateAverages(Response[] answers)
        {
            for (int i = 0; i < answers.Length; i++)
                for (int j = i + 1; j < answers.Length; j++)
                {
                    relocateAverage(ref answers[i].average_0, ref answers[j].average_0, ref answers[i].answer_0, ref answers[j].answer_0);
                    relocateAverage(ref answers[i].average_1, ref answers[j].average_1, ref answers[i].answer_1, ref answers[j].answer_1);
                    relocateAverage(ref answers[i].average_2, ref answers[j].average_2, ref answers[i].answer_2, ref answers[j].answer_2);
                }
        }
        static void sortResponses(Response[] answers)
        {
        for(int i = 1; i < answers.Length; i++)
            for (int k = i; k < answers.Length; k++)
            {
                if (answers[i].answer_0 == answers[i - 1].answer_0)
                {
                    string temp_string = answers[i].answer_0;
                    float temp = answers[i].average_0;
                    for (int j = i + 1; j < answers.Length; j++)
                    {
                        answers[j - 1].answer_0 = answers[j].answer_0; answers[j - 1].average_0 = answers[j].average_0;
                    }
                    answers[answers.Length - 1].answer_0 = temp_string; answers[answers.Length - 1].average_0 = temp;
                }
                if (answers[i].answer_1 == answers[i - 1].answer_1)
                {
                    string temp_string = answers[i].answer_1;
                    float temp = answers[i].average_1;
                    for (int j = i + 1; j < answers.Length; j++)
                    {
                        answers[j - 1].answer_1 = answers[j].answer_1; answers[j - 1].average_1 = answers[j].average_1;
                    }
                    answers[answers.Length - 1].answer_1 = temp_string; answers[answers.Length - 1].average_1 = temp;
                }
                if (answers[i].answer_2 == answers[i - 1].answer_2)
                {
                    string temp_string = answers[i].answer_2;
                    float temp = answers[i].average_2;
                    for (int j = i + 1; j < answers.Length; j++)
                    {
                        answers[j - 1].answer_2 = answers[j].answer_2; answers[j - 1].average_2 = answers[j].average_2;
                    }
                    answers[answers.Length - 1].answer_2 = temp_string; answers[answers.Length - 1].average_2 = temp;
                }
            }
        }
        static void relocateAverage(ref float average_0, ref float average_1, ref string answer_0, ref string answer_1)
        {
            if (average_0 < average_1)
            {
                float temp = average_0; average_0 = average_1; average_1 = temp;
                string temp_string = answer_0; answer_0 = answer_1; answer_1 = temp_string;
            }
        }
        static void findAverages(Response[] answers)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                for (int j = 0; j < answers.Length; j++)
                {
                    findDuplicates(answers[i].answer_0, answers[j].answer_0, ref answers[i].average_0);
                    findDuplicates(answers[i].answer_1, answers[j].answer_1, ref answers[i].average_1);
                    findDuplicates(answers[i].answer_2, answers[j].answer_2, ref answers[i].average_2);
                }
                answers[i].average_0 /= answers.Length;
                answers[i].average_1 /= answers.Length;
                answers[i].average_2 /= answers.Length;
            }
        }
        static void findDuplicates(string answer_0, string answer_1, ref float average_0)
        {
            if (answer_0 == answer_1 && answer_0 != "")
                average_0++;
        }
    }
}

