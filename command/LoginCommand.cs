using QuizTopEx.AdminPanel;
using QuizTopEx.dataBase;
using QuizTopEx.Entities;
using QuizTopEx.logic;
using QuizTopEx.loginAndRegistration;
using QuizTopEx.MenuCommand;
using QuizTopEx.models;
using QuizTopEx.serializer;
using System;

namespace QuizTopEx.command
{
    public class LoginCommand : ICommand
    {
        private readonly IUserDataReader userDataReader;
        private readonly IQuizDB quizDB;
        private readonly IUserDB userDB;
        private readonly IJsonSerializer<User> jsonSerializer;
        private readonly IJsonSerializer<Quiz> jsonQuizSerializer;

        public LoginCommand(IQuizDB quizDB, IUserDB userDB, IJsonSerializer<User> jsonSerializer, IJsonSerializer<Quiz> jsonQuizSerializer)
        {
            this.userDataReader = new LoginDataReader();
            this.jsonSerializer = jsonSerializer;
            this.quizDB = quizDB;
            this.userDB = userDB;
            this.jsonSerializer = jsonSerializer;
            this.jsonQuizSerializer = jsonQuizSerializer; 
        }

        public string Description() => "Войти в систему";

        public void Execute()
        {
            ConsoleMenu menu = new ConsoleMenu();

            Console.Write("Введите логин => ");
            var login = userDataReader.ReadLogin();

            Console.Write("Введите пароль => ");
            var password = userDataReader.ReadPassword();

            var currentUser = userDB.GetUser(login, password);
            if (currentUser == null)
            {
                Console.Clear();
                Console.WriteLine("Неверный логин или пароль. Попробуйте еще раз.");
                return;
            }

            else if (currentUser.IsAdmin)
            {
                Console.Clear();
                Console.WriteLine($"Вход выполнен:");
                Console.WriteLine($"Администратор: {currentUser.Name}");

                menu.AddCommand(new LogicCommand(quizDB, currentUser, jsonSerializer, userDB));
                menu.AddCommand(new RecentQuizResultsCommand(quizDB, currentUser));
                menu.AddCommand(new LoginAndPasswordSettings(userDB, currentUser));
                menu.AddCommand(new ChangesQuestionAndAnswerCommand(quizDB, jsonQuizSerializer));
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Вход выполнен:");
                Console.WriteLine($"Пользователь: {currentUser.Name}");


                menu.AddCommand(new LogicCommand(quizDB, currentUser, jsonSerializer, userDB));
                menu.AddCommand(new RecentQuizResultsCommand(quizDB, currentUser));
                menu.AddCommand(new LoginAndPasswordSettings(userDB, currentUser));
            }

            menu.Run();
        }
    }
}
