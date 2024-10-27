using QuizTopEx.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.dataBase
{
    public interface IUserDB
    {
        List<User> Users { get; }

        void Add(User user);
        User GetUser(string login, string password);
        bool UserExits(string login);
    }
}
