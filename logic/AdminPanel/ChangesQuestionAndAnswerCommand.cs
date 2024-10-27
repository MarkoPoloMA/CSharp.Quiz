using QuizTopEx.dataBase;
using QuizTopEx.Entities;
using QuizTopEx.MenuCommand;
using QuizTopEx.serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.AdminPanel
{
    public class ChangesQuestionAndAnswerCommand : ICommand
    {
        private readonly IQuizDB quizDB;
        private readonly IJsonSerializer<Quiz> jsonSerializer;

        public ChangesQuestionAndAnswerCommand(IQuizDB quizDB, IJsonSerializer<Quiz> jsonSerializer)
        {
            this.quizDB = quizDB;
            this.jsonSerializer = jsonSerializer;
        }
        public string Description() => "Корректировка вопроса и ответов";

        public void Execute()
        {
            var quizSelector = new QuizSelector(quizDB);
            var selectedQuiz = quizSelector.SelectQuiz();

            if (selectedQuiz != null)
            {
                var questionEditor = new QuestionEditor();
                questionEditor.EditQuiz(selectedQuiz);
                jsonSerializer.Save(quizDB.Quizzes);
            }
        }
    }
}
