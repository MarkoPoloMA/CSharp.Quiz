using QuizTopEx.Entities;
using QuizTopEx.models;
using System.Collections.Generic;

namespace QuizTopEx.dataBase
{
    public interface IQuizDB
    {
        List<Quiz> Quizzes { get; }

        void Initialize();
    }
}