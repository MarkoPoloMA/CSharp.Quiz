using QuizTopEx.dataBase;
using System;

namespace QuizTopEx.logic
{
    public class QuizChooser
    {
        private readonly IQuizDB quizDB;

        public QuizChooser(IQuizDB quizDB)
        {
            this.quizDB = quizDB;
        }

        public int ChooseQuiz()
        {
            for (int i = 0; i < quizDB.Quizzes.Count; i++)
                Console.WriteLine($"{i + 1}. {quizDB.Quizzes[i].Title}");

            Console.Write("Выберите викторину (введите номер): ");
            if (int.TryParse(Console.ReadLine(), out int selectedQuizIndex) &&
                selectedQuizIndex > 0 &&
                selectedQuizIndex <= quizDB.Quizzes.Count)
                return selectedQuizIndex - 1; 
            return -1;
        }
    }
}