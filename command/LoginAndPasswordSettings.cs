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
    public class LoginAndPasswordSettings : ICommand
    {
        private readonly IUserDB userDB;
        private User currentUser;

        public LoginAndPasswordSettings(IUserDB userDB, User currentUser)
        {
            this.userDB = userDB;
            this.currentUser = currentUser;
        }

        public string Description() => "Настройки пароля и логина";

        public void Execute()
        {
            ConsoleMenu menu = new ConsoleMenu();

            menu.AddCommand(new SettingCommandSetPassword(userDB, currentUser));
            menu.AddCommand(new SettingCommandSetLogin(userDB, currentUser));

            menu.Run();
        }
    }
}

