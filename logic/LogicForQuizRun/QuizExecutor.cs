using QuizTopEx.Entities;
using QuizTopEx.models;
using System;

namespace QuizTopEx.logic
{
    public class QuizExecutor
    {
        public AnswerResult ExecuteQuiz(Quiz selectedQuiz)
        {
            int count = 0;

            Console.WriteLine($"Вопросы викторины по теме - {selectedQuiz.Title}");
            foreach (var question in selectedQuiz.questions)
            {
                Console.Clear();
                Console.WriteLine($"Вопрос: {question.Text}");
                Console.WriteLine("Ответы:");

                for (int j = 0; j < question.Answers.Count; j++)
                    Console.WriteLine($"{j + 1}. {question.Answers[j]}");

                if (int.TryParse(Console.ReadLine(), out int answerIndex) &&
                    answerIndex > 0 &&
                    answerIndex <= question.Answers.Count &&
                    answerIndex - 1 == question.CorrectAnswerIndex)

                    Console.WriteLine("Верно!");
                else
                {
                    count++;
                    Console.WriteLine($"Не верно. Правильный ответ {question.Answers[question.CorrectAnswerIndex]}");
                }
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }

            return new AnswerResult
            {
                QuizTitle = selectedQuiz.Title,
                DateTimeCompleted = DateTime.Now,
                TotalQuestions = selectedQuiz.questions.Count,
                CorrectAnswers = selectedQuiz.questions.Count - count
            };
        }
    }
}