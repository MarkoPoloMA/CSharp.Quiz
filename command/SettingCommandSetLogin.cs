using QuizTopEx.dataBase;
using QuizTopEx.loginAndRegistration;
using QuizTopEx.MenuCommand;
using QuizTopEx.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.command
{
    public class SettingCommandSetLogin : ICommand
    {
        private readonly IUserDataReader userDataReader;
        private readonly IUserDB userDB;
        private User currentUser;
        public SettingCommandSetLogin(IUserDB userDB, User currentUser)
        {
            this.userDB = userDB;
            this.currentUser = currentUser;
            userDataReader = new LoginDataReader();
        }
        public string Description() => "Поменять логин";

        public void Execute()
        {
            string pass;

            do
            {
                Console.Write("Введите старый логин => ");
                pass = userDataReader.ReadLogin();

                if (pass != currentUser.Name)
                    Console.WriteLine("Неверный логин, попробуйте еще раз.");

            } while (pass != currentUser.Name);

            Console.Write("Введите новый пароль => ");
            var newLogin = userDataReader.ReadLogin();

            User newUser = new User(newLogin, currentUser.Password, currentUser.AnswerResults);

            userDB.Users.Remove(currentUser);
            userDB.Add(newUser);
            currentUser = newUser;

            Console.Clear();
            Console.WriteLine($"Пароль изменён!");
            Console.ReadKey();
        }
    }
}
