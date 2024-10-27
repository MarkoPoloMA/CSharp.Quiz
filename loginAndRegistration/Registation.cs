using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.loginAndRegistration
{
    public class RegistationDataReader : IUserDataReader
    {
        public string ReadLogin()
        {
            string login;

            while (true)
            {
                login = Console.ReadLine();
                if (!string.IsNullOrEmpty(login))
                    break;

                Console.Write("Логин не может быть пустым. Пожалуйста, введите логин => ");
            }
            return login;
        }

        public string ReadPassword()
        {
            string password;
            while (true)
            {
                password = Console.ReadLine();
                if (!string.IsNullOrEmpty(password))
                    break;

                Console.Write("Пароль не может быть пустым. Пожалуйста, введите пароль => ");
            }
            return password;
        }
    }
}
