using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.loginAndRegistration
{
    public class LoginDataReader : IUserDataReader
    {
        public string ReadLogin()
        {
            return Console.ReadLine();
        }

        public string ReadPassword()
        {
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                    break;
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            Console.WriteLine();

            return password;
        }
    }
}
