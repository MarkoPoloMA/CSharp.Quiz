using QuizTopEx.Entities;
using QuizTopEx.models;
using QuizTopEx.serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.dataBase
{
    public class UserDB : IUserDB
    {
        private readonly IJsonSerializer<User> userSerializer;
        public List<User> Users { get; private set; }

        public UserDB(IJsonSerializer<User> userSerializer)
        {
            this.userSerializer = userSerializer;

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                Users = this.userSerializer.Load();
                if (!Users.Exists(user => user.Name == "admin" && user.IsAdmin))
                    Users.Add(new User("admin", "admin", true));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке пользователей: {ex.Message}");
            }
        }


        public void Add(User user)
        {
            if (Users.Any(u => u.Name == user.Name))
            {
                Console.WriteLine("Пользователь с таким ником уже существует");
                return;
            }

            Users.Add(user);
            this.userSerializer.Save(Users);
        }

        public User GetUser(string login, string password) => Users.Find(u => u.Name == login && u.Password == password);
        public bool UserExits(string login) => Users.Any(u => u.Name == login);
        public bool IsAdmin(string login) => Users.Any(a => a.Name == login);

    }
}
