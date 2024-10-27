using QuizTopEx.dataBase;
using QuizTopEx.loginAndRegistration;
using QuizTopEx.MenuCommand;
using QuizTopEx.models;
using System;

namespace QuizTopEx.command
{
    public class SettingCommandSetPassword : ICommand
    {
        private readonly IUserDataReader userDataReader;
        private readonly IUserDB userDB;
        private User currentUser;

        public SettingCommandSetPassword(IUserDB userDB, User currentUser)
        {
            this.userDB = userDB;
            this.currentUser = currentUser;
            userDataReader = new LoginDataReader();
        }

        public string Description() => "Поменять пароль";

        public void Execute()
        {
            string pass;

            do
            {
                Console.Write("Введите старый пароль => ");
                pass = userDataReader.ReadPassword();

                if (pass != currentUser.Password)
                    Console.WriteLine("Неверный пароль, попробуйте еще раз.");

            } while (pass != currentUser.Password);

            Console.Write("Введите новый пароль => ");
            var newPassword = userDataReader.ReadPassword();

            User newUser = new User(currentUser.Name, newPassword, currentUser.AnswerResults);

            userDB.Users.Remove(currentUser);
            userDB.Add(newUser);
            currentUser = newUser;

            Console.Clear();
            Console.WriteLine($"Логин изменён!");
            Console.ReadKey();
        }

    }
}
