using QuizTopEx.dataBase;
using QuizTopEx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.AdminPanel
{
    public class QuizSelector
    {
        private readonly IQuizDB quizDB;

        public QuizSelector(IQuizDB quizDB)
        {
            this.quizDB = quizDB;
        }
        public Quiz SelectQuiz()
        {
            Console.Clear();
            Console.WriteLine("Выберите викторину для корректировки:");

            for (int i = 0; i < quizDB.Quizzes.Count; i++)
                Console.WriteLine($"{i + 1}. {quizDB.Quizzes[i].Title}");

            Console.Write("Введите номер викторины => ");
            int quizIndex;

            if (!int.TryParse(Console.ReadLine(), out quizIndex)
                || quizIndex < 1
                || quizIndex > quizDB.Quizzes.Count)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                return null; 
            }

            return quizDB.Quizzes[quizIndex - 1];
        }
    }
}
