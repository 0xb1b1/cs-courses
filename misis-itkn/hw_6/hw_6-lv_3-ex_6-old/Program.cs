using System;
namespace ConsoleApplication1
{
    struct SurveyResponce
    {
        private string[] questions, answers;
        private string first_name, last_name, full_name;
        public SurveyResponce(string first_name, string last_name, string[,] qa_pairs)
        {
            this.answers = new string[qa_pairs.GetLength(0)];
            this.questions = new string[qa_pairs.GetLength(0)];
            this.first_name = first_name;
            this.last_name = last_name;
            this.full_name = $"{first_name} {last_name}";
            this.ParseQA(qa_pairs);
        }
        public void ParseQA(string[,] qa_pairs)
        {
            for (int pair = 0; pair < answers.GetLength(0); pair++)
            {
                this.questions[pair] = qa_pairs[pair, 0];
                this.answers[pair] = qa_pairs[pair, 1];
            }
        }
        public string[] GetQuestions()
        {
            return this.questions;
        }
        public string[] GetAnswers()
        {
            return this.answers;
        }
        public string GetFirstName()
        {
            return this.first_name;
        }
        public string GetLastName()
        {
            return this.last_name;
        }
        public string GetFullName()
        {
            return this.full_name;
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
        public void SetFullName(string full_name)
        {
            this.full_name = full_name;
            string[] names = full_name.Split(' ');
            this.first_name = names[0];
            this.last_name = names[1];
        }
    }
    struct Survey
    {
        private SurveyResponce[] survey_responces;
        private string[] questions;
        private string[][]? answers_by_question = null;
        public Survey(SurveyResponce[] survey_responces)
        {
            this.survey_responces = survey_responces;
            this.questions = new string[survey_responces.GetLength(0)];
            this.CreateAnswersByQuestion();
            this.ParseQuestions(survey_responces);
        }
        private void ParseQuestions(SurveyResponce[] survey_responces)
        {
            int questions_recorded = 0;
            string[] temp_questions = new string[survey_responces.GetLength(0) * survey_responces[0].GetQuestions().GetLength(0)];
            for (int responce = 0; responce < survey_responces.GetLength(0); responce++)
            {
                for (int i = 0; i < survey_responces[responce].GetQuestions().GetLength(0); i++)
                {
                    if (!temp_questions.Contains(survey_responces[responce].GetQuestions()[i]))
                    {
                        temp_questions[questions_recorded] = survey_responces[responce].GetQuestions()[i];
                        questions_recorded++;
                    }
                }
            }
            string[] new_questions = new string[questions_recorded];
            for (int i = 0; i < questions_recorded; i++)
            {
                new_questions[i] = temp_questions[i];
            }
            this.questions = new_questions;
        }
        private void CreateAnswersByQuestion()
        {
            string[][] temp_answers_by_question = new string[questions.Length][];
            for (int question = 0; question < questions.Length; question++)
            {
                string[] temp_question_answers = new string[this.CountAnswers()];
                int answer_count = 0;
                for (int responce = 0; responce < survey_responces.Length; responce++)
                {
                    for (int i = 0; i < survey_responces[responce].GetQuestions().GetLength(0); i++)
                    {
                        if (survey_responces[responce].GetQuestions()[i] == questions[question])
                        {
                            temp_question_answers[responce + 1] = survey_responces[responce].GetAnswers()[i];
                            answer_count++;
                        }
                    }
                }
                string[] question_answers = new string[answer_count];
                for (int i = 0; i < answer_count; i++)
                {
                    question_answers[i] = temp_question_answers[i];
                }
                temp_answers_by_question[question] = question_answers;
            }
            this.answers_by_question = temp_answers_by_question;
        }
        public string[][]? GetAnswersByQuestion()
        {
            return this.answers_by_question;
        }
        private int CountAnswers()
        {
            int count = 0;
            for (int responce = 0; responce < survey_responces.GetLength(0); responce++)
            {
                count += survey_responces[responce].GetQuestions().GetLength(0);
            }
            return count;
        }
        public string[] GetQuestions()
        {
            return this.questions;
        }
        public void SetParticipantFirstName(string full_name, string first_name)
        {
            for (int i = 0; i < this.survey_responces.GetLength(0); i++)
            {
                if (this.survey_responces[i].GetFullName() == full_name)
                {
                    this.survey_responces[i].SetFirstName(first_name);
                }
            }
        }
        public void SetParticipantLastName(string full_name, string last_name)
        {
            for (int i = 0; i < this.survey_responces.GetLength(0); i++)
            {
                if (this.survey_responces[i].GetFullName() == full_name)
                {
                    this.survey_responces[i].SetLastName(last_name);
                }
            }
        }
        public void SetParticipantFullName(string full_name, string new_full_name)
        {
            for (int i = 0; i < this.survey_responces.GetLength(0); i++)
            {
                if (this.survey_responces[i].GetFullName() == full_name)
                {
                    this.survey_responces[i].SetFullName(new_full_name);
                }
            }
        }
        public string[]? GetAnswers(string question)
        {
            if (!this.questions.Contains(question)) return null;
            string[] answers = new string[this.survey_responces.GetLength(0)];
            for (int i = 0; i < this.survey_responces.GetLength(0); i++)
            {
                for (int j = 0; j < this.survey_responces[i].GetQuestions().GetLength(0); j++)
                {
                    if (this.survey_responces[i].GetQuestions()[j] == question)
                    {
                        answers[i] = this.survey_responces[i].GetAnswers()[j];
                    }
                }
            }
            return answers;
        }
        public double? CalculatePopularity(string question, string answer)
        {
            if (this.GetAnswers(question) == null) return null;
            string[]? answers_for_question = this.GetAnswers(question);
            int matching_answers = 0;
            for (int i = 0; i < answers_for_question.GetLength(0); i++)
            {
                if (answers_for_question[i] == answer)
                {
                    matching_answers++;
                }
            }
            return (double)matching_answers / answers_for_question.GetLength(0) * 100;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SurveyResponce[] survey_responces = new SurveyResponce[5];
            survey_responces[0] = new SurveyResponce("Oleg", "Styopovich", new string [,] {
                { "Which animal do you associate with Japan?", "Python" },
                { "What is the most common Japanese personality trait?", "Creativity" },
                { "Which inanimate object or concept do you associate with Japan?", "Lewdness" }
                });
            survey_responces[1] = new SurveyResponce("Kot", "Artyomovich", new string [,] {
                { "Which animal do you associate with Japan?", "Panda" },
                { "What is the most common Japanese personality trait?", "Work affinity" },
                { "Which inanimate object or concept do you associate with Japan?", "Notebook" }
                });
            survey_responces[2] = new SurveyResponce("Anya", "Ahhhhhh", new string [,] {
                { "Which animal do you associate with Japan?", "Panda" },
                { "What is the most common Japanese personality trait?", "Creativity" },
                { "Which inanimate object or concept do you associate with Japan?", "Anime" }
                });
            survey_responces[3] = new SurveyResponce("Galina", "Kry'nya", new string [,] {
                { "Which animal do you associate with Japan?", "Blue bird" },
                { "What is the most common Japanese personality trait?", "Creativity" },
                { "Which inanimate object or concept do you associate with Japan?", "Notebook" }
                });
            survey_responces[4] = new SurveyResponce("Excel", "Breightnbikher", new string [,] {
                { "Which animal do you associate with Japan?", "C++" },
                { "What is the most common Japanese personality trait?", "Creativity" },
                { "Which inanimate object or concept do you associate with Japan?", "Lewdness" }
                });
            survey_responces[5] = new SurveyResponce("Tema", "Claudrepovich", new string [,] {
                { "Which animal do you associate with Japan?", "RapPanda" },
                { "What is the most common Japanese personality trait?", "Musical ability" },
                { "Which inanimate object or concept do you associate with Japan?", "Laptop" }
                });
            Survey survey = new Survey(survey_responces);
            for (int i = 0; i < survey.GetQuestions().GetLength(0); i++)
            {
                Console.WriteLine(survey.GetQuestions()[i]);
            }
        }
    }
}
