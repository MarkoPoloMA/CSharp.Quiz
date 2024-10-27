using Newtonsoft.Json;
using QuizTopEx.dataBase;
using QuizTopEx.models;
using QuizTopEx.serializer;
using System;
using System.Linq;

namespace QuizTopEx.logic
{
    public class ResultProcessor
    {
        private readonly IQuizDB quizDB;
        private readonly IUserDB userDB;
        private readonly IJsonSerializer<User> jsonSerializer;

        public ResultProcessor(IQuizDB quizDB, IJsonSerializer<User> jsonSerializer, IUserDB userDB)
        {
            this.quizDB = quizDB;
            this.jsonSerializer = jsonSerializer;
            this.userDB = userDB;
        }
        public void ProcessResult(User currentUser, AnswerResult result)
        {
            Console.Clear();
            Console.WriteLine("Викторина завершена!");
            Console.WriteLine(result.ToString());

            currentUser.AddAnswerResult(result);
            SerializeUserResults(currentUser, result);
        }

        private void SerializeUserResults(User user, AnswerResult result)
        {
            var currentUsers = jsonSerializer.Load();

            var existingUser = currentUsers.FirstOrDefault(u => u.Name == user.Name);

            if (existingUser != null)
            {
                existingUser.AnswerResults.Add(result);

                jsonSerializer.Save(currentUsers);
                Console.WriteLine("Результат пользователя успешно обновлен.");
            }
        }
    }
}