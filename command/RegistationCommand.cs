using QuizTopEx.dataBase;
using QuizTopEx.Entities;
using QuizTopEx.logic;
using QuizTopEx.loginAndRegistration;
using QuizTopEx.MenuCommand;
using QuizTopEx.models;
using QuizTopEx.serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.command
{
    public class RegistationCommand : ICommand
    {
        private readonly IUserDataReader userDataReader;
        private readonly IJsonSerializer<User> jsonSerializer;
        private readonly IQuizDB quizDB;
        private readonly IUserDB userDB;
        private readonly ConsoleMenu menu;

        public RegistationCommand(IQuizDB quizDB, IUserDB userDB , IJsonSerializer<User> jsonSerializer)
        {
            this.userDataReader = new RegistationDataReader();
            this.menu = new ConsoleMenu();
            this.quizDB = quizDB;
            this.userDB = userDB;
            this.jsonSerializer = jsonSerializer;
        }

        public string Description() => $"Регистрация пользователя";
        public void Execute()
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Введите логин => ");
            var login = userDataReader.ReadLogin();

            Console.Write("Введите пароль => ");
            var password = userDataReader.ReadPassword();
            if (userDB.UserExits(login))
            {
                Console.WriteLine("Пользователь с таким логином уже существует. Пожалуйста, выберите другой логин.");
                return;
            }

            User currentUser = new User(login, password, false);
            try
            {
                userDB.Add(currentUser);

                Console.Clear();
                Console.WriteLine($"Регистрация выполнена:");
                Console.WriteLine($"Пользователь:  {currentUser.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при регистрации: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();

            menu.AddCommand(new LogicCommand(quizDB, currentUser, jsonSerializer, userDB));
            menu.AddCommand(new RecentQuizResultsCommand(quizDB, currentUser));
            menu.AddCommand(new LoginAndPasswordSettings(userDB, currentUser));

            menu.Run();
        }
    }
}
