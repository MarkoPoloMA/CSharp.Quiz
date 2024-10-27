using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.models
{
    [Serializable]
    public class AnswerResult
    {
        public string QuizTitle { get; set; }
        public DateTime DateTimeCompleted { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public AnswerResult() { }
        public AnswerResult(string quizTitle, DateTime dateTimeCompleted, int totalQuestions, int correctAnswers)
        {
            QuizTitle = quizTitle;
            DateTimeCompleted = dateTimeCompleted;
            TotalQuestions = totalQuestions;
            CorrectAnswers = correctAnswers;
        }
        public override string ToString()
        {
            return $"{QuizTitle}\n" +
                   $"Дата и время: {DateTimeCompleted}\n" +
                   $"Правильные ответы: {CorrectAnswers}/{TotalQuestions}\n";
        }
    }
}
