using QuizTopEx.dataBase;
using QuizTopEx.MenuCommand;
using QuizTopEx.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.command
{
    public class RecentQuizResultsCommand : ICommand
    {
        private readonly IQuizDB QuizDB;
        private User currentUser;

        public RecentQuizResultsCommand(IQuizDB quizDB, User user)
        {
            this.QuizDB = quizDB;
            this.currentUser = user;
        }

        public string Description() => "Результаты всех пройденных викторин.";

        public void Execute()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Пользователь не найден.");
                return;
            }

            var results = currentUser.AnswerResults; 

            if (results.Count == 0)
                return;

            Console.WriteLine($"Результаты для пользователя {currentUser.Name}:");
            for (int i = 0; i < results.Count; i++)
                Console.WriteLine($"{i + 1} - {results[i].ToString()}");
        }
    }

}
