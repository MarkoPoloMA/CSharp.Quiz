using Newtonsoft.Json;
using QuizTopEx.dataBase;
using QuizTopEx.Entities;
using QuizTopEx.serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.models
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<AnswerResult> AnswerResults { get; set; }
        public bool IsAdmin { get; set; }
        public User(string name, string password, bool isAdmin)
        {
            Name = name;
            Password = password;
            AnswerResults = new List<AnswerResult>();
            IsAdmin = isAdmin;
        }
        [JsonConstructor]
        public User(string name, string password, List<AnswerResult> AnswerResults)
        {
            Name = name;
            Password = password;
            this.AnswerResults = AnswerResults;
        }
        public void AddAnswerResult(AnswerResult result)
        {
            AnswerResults.Add(result);
        }
        public void ChangeUsername(string newUsername)
        {
            Name = newUsername;
        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
