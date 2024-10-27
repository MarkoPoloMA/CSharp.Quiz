using QuizTopEx.Entities;
using QuizTopEx.MenuCommand;
using QuizTopEx.dataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTopEx.models;
using QuizTopEx.serializer;

namespace QuizTopEx.logic
{
    public class LogicCommand : ICommand
    {
        private readonly IQuizDB quizDB;
        private readonly IUserDB userDB;
        private readonly IJsonSerializer<User> jsonSerializer;
        private readonly QuizChooser quizChooser;
        private readonly QuizExecutor quizExecutor;
        private readonly ResultProcessor resultProcessor;
        public User currentUser { get; set; }

        public LogicCommand(IQuizDB quizDB, User currentUser, IJsonSerializer<User> jsonSerializer, IUserDB userDB)
        {
            this.quizDB = quizDB;
            this.jsonSerializer = jsonSerializer;
            this.quizChooser = new QuizChooser(quizDB);
            this.quizExecutor = new QuizExecutor();
            this.resultProcessor = new ResultProcessor(quizDB, jsonSerializer, userDB);
            this.currentUser = currentUser;
            this.userDB = userDB;
        }

        public string Description() => "Выбрать викторину";

        public void Execute()
        {
            int selectedQuizIndex = quizChooser.ChooseQuiz();

            if (selectedQuizIndex != -1)
            {
                Console.Clear();
                var selectedQuiz = quizDB.Quizzes[selectedQuizIndex];
                var result = quizExecutor.ExecuteQuiz(selectedQuiz);
                resultProcessor.ProcessResult(currentUser, result);
            }
            else
            {
                Console.WriteLine("Выбор не верный. Такой викторины нет!");
            }
        }
    }
}