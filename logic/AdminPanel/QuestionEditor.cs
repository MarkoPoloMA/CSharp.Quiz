using QuizTopEx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.AdminPanel
{
    public class QuestionEditor
    {
        public void EditQuiz(Quiz quiz)
        {
            var tempQuestions = new List<Question>(quiz.questions);

            for (int i = 0; i < tempQuestions.Count; i++)
            {
                var question = tempQuestions[i];

                Console.WriteLine(question.ToString());

                Console.WriteLine("Что хотите скорректировать?");
                Console.WriteLine("1 - Ответ на вопрос");
                Console.WriteLine("2 - Текст вопроса");
                Console.WriteLine("3 - Завершить редактирование и сохранить изменения");

                int indexSelected;
                if (int.TryParse(Console.ReadLine(), out indexSelected)
                    && (indexSelected == 1 
                    || indexSelected == 2
                    || indexSelected == 3))
                {

                    if (indexSelected == 1)
                        EditAnswer(question);
                    
                    else if (indexSelected == 2)
                    {
                        Console.Write("Введите новый текст вопроса => ");
                        string newText = Console.ReadLine();
                        tempQuestions[i].Text = newText;
                    }
                    else if (indexSelected == 3)
                    {
                        for (int j = 0; j < tempQuestions.Count; j++)
                            quiz.questions[j] = tempQuestions[j];
                    }

                    Console.WriteLine("Корректировка завершена успешно");
                    Console.WriteLine(question.ToString());
                    break;
                }
                else
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
        public void EditAnswer(Question question)
        {
            Console.Write("Введите новый номер ответа (1 - 4) => ");
            if (int.TryParse(Console.ReadLine(), out int selectedAnswer)
                && selectedAnswer > 0
                && selectedAnswer <= question.Answers.Count)
            {
                question.CorrectAnswerIndex = selectedAnswer - 1;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}
