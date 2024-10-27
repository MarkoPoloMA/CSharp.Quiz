using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.Entities
{
    [Serializable]
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public Question() { }
        public Question(string text, List<string> answers, int correctAnswerIndex)
        {
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }
        public void EditAnswer(int index, string newAnswer)
        {
            if (index >= 0 && index < Answers.Count)
                Answers[index] = newAnswer;
            else
                throw new ArgumentOutOfRangeException("Некорректный вариант");
        }
        public void EditCorrectAnswerIndex(int newIndex)
        {
            if (newIndex >= 0 && newIndex < Answers.Count)
                CorrectAnswerIndex = newIndex;
            else
                throw new ArgumentOutOfRangeException("Некорректный вариант");
        }
        public override string ToString()
        {
            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Text);
            stringBuilder.Append("Варианты ответов:");
            foreach (var item in Answers)
                stringBuilder.AppendLine(item);
            stringBuilder.AppendLine($"Правильный ответ: {CorrectAnswerIndex + 1}");

            return stringBuilder.ToString();
        }
    }
}
