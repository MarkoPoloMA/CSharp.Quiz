using QuizTopEx.dataBase;
using System;
using QuizTopEx.serializer;
using QuizTopEx.command;
using QuizTopEx.MenuCommand;
using QuizTopEx.Entities;
using QuizTopEx.models;
using Newtonsoft.Json;

namespace QuizTopEx
{ //доделать админ панель
    public class Program
    {
        public static void Main()
        {
            IJsonSerializer<Quiz> questionSerializer = new JsonSerializer<Quiz>("Quiz.json");
            IJsonSerializer<User> userSerializer = new JsonSerializer<User>("Users.json");

            IUserDB userDB = new UserDB(userSerializer);
            IQuizDB quizDB = new QuizDB(questionSerializer);

            ConsoleMenu consoleMenu = new ConsoleMenu();

            consoleMenu.AddCommand(new LoginCommand(quizDB, userDB, userSerializer, questionSerializer));
            consoleMenu.AddCommand(new RegistationCommand(quizDB, userDB, userSerializer));
            consoleMenu.Run();
            

            Console.ReadKey();
        }
    }
}
