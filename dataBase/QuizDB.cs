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
    public class QuizDB : IQuizDB
    {
        private readonly IJsonSerializer<Quiz> questionSerializer;
        public List<Quiz> Quizzes { get; private set; }

        public QuizDB(IJsonSerializer<Quiz> questionSerializer)
        {
            this.questionSerializer = questionSerializer;

            Initialize();
        }
        public void Initialize()
        {
            this.Quizzes = questionSerializer.Load();

            if (this.Quizzes.Count <= 0)
            {
                AddSampleQuestions();
                questionSerializer.Load();
            }
        }

        private void AddSampleQuestions()
        {
            List<Quiz> sampleQuestions = new List<Quiz>
            {
                new Quiz
                {
                    Title = "Информатика",
                    questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Какой язык программирования используется в веб-разработке?",
                            Answers = new List<string> { "Python", "JavaScript", "C#", "Java" },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Что такое бит?",
                            Answers = new List<string>
                            {
                                "Наименьшая единица измерения информации.",
                                "Наименьшая единица измерения времени.",
                                "Наименьшая единица измерения скорости.",
                                "Наименьшая единица измерения мощности."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Какое из чисел является двоичным?",
                            Answers = new List<string>
                            {
                                "1010",
                                "1234",
                                "5678",
                                "9012"
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое алгоритм?",
                            Answers = new List<string>
                            {
                                "Последовательность действий, приводящая к решению задачи.",
                                "Программа, написанная на языке программирования.",
                                "Компьютерная сеть.",
                                "Операционная система."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое операционная система?",
                            Answers = new List<string>
                            {
                                "Программа, которая управляет работой компьютера.",
                                "Программа, которая позволяет создавать веб-сайты.",
                                "Программа, которая позволяет редактировать изображения.",
                                "Программа, которая позволяет играть в игры."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Какой язык программирования считается первым в мире?",
                            Answers = new List<string>
                            {
                                "C++",
                                "Java",
                                "Python",
                                "Plankalkül"
                            },
                            CorrectAnswerIndex = 3
                        },
                        new Question
                        {
                            Text = "Что такое компилятор?",
                            Answers = new List<string>
                            {
                                "Программа, которая переводит код с языка программирования на машинный язык.",
                                "Программа, которая позволяет редактировать текст.",
                                "Программа, которая позволяет создавать презентации.",
                                "Программа, которая позволяет просматривать веб-страницы."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое интернет?",
                            Answers = new List<string>
                            {
                                "Глобальная сеть, соединяющая компьютеры по всему миру.",
                                "Локальная сеть, соединяющая компьютеры в пределах одного здания.",
                                "Программа, которая позволяет отправлять электронные письма.",
                                "Программа, которая позволяет просматривать веб-страницы."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое HTML?",
                            Answers = new List<string>
                            {
                                "Язык разметки, используемый для создания веб-страниц.",
                                "Язык программирования, используемый для создания веб-приложений.",
                                "Программа, которая позволяет редактировать изображения.",
                                "Программа, которая позволяет создавать базы данных."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое CSS?",
                            Answers = new List<string>
                            {
                                "Язык стилей, используемый для оформления веб-страниц.",
                                "Язык программирования, используемый для создания веб-приложений.",
                                "Программа, которая позволяет редактировать изображения.",
                                "Программа, которая позволяет создавать базы данных."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое JavaScript?",
                            Answers = new List<string>
                            {
                                "Язык программирования, используемый для создания интерактивных элементов на веб-страницах.",
                                "Язык разметки, используемый для создания веб-страниц.",
                                "Язык стилей, используемый для оформления веб-страниц.",
                                "Программа, которая позволяет редактировать изображения."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое база данных?",
                            Answers = new List<string>
                            {
                                "Организованное хранилище данных.",
                                "Программа, которая позволяет редактировать изображения.",
                                "Программа, которая позволяет создавать презентации.",
                                "Программа, которая позволяет отправлять электронные письма."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое SQL?",
                            Answers = new List<string>
                            {
                                "Язык запросов к базам данных.",
                                "Язык программирования, используемый для создания веб-приложений.",
                                "Язык стилей, используемый для оформления веб-страниц.",
                                "Программа, которая позволяет редактировать изображения."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое вирус?",
                            Answers = new List<string>
                            {
                                "Программа, которая может нанести вред компьютеру.",
                                "Программа, которая позволяет редактировать текст.",
                                "Программа, которая позволяет создавать презентации.",
                                "Программа, которая позволяет просматривать веб-страницы."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое брандмауэр?",
                            Answers = new List<string>
                            {
                                "Программа, которая защищает компьютер от несанкционированного доступа.",
                                "Программа, которая позволяет редактировать текст.",
                                "Программа, которая позволяет создавать презентации.",
                                "Программа, которая позволяет просматривать веб-страницы."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое антивирус?",
                            Answers = new List<string>
                            {
                                "Программа, которая защищает компьютер от вирусов.",
                                "Программа, которая позволяет редактировать текст.",
                                "Программа, которая позволяет создавать презентации.",
                                "Программа, которая позволяет просматривать веб-страницы."
                            },
                            CorrectAnswerIndex = 0
                        }
                    }
                },
                new Quiz
                {
                    Title = "Физика",
                    questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Какой язык программирования используется в веб-разработке?",
                            Answers = new List<string> { "Python", "JavaScript", "C#", "Java" },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Что такое бит?",
                            Answers = new List<string>
                            {
                                "Наименьшая единица измерения информации.",
                                "Наименьшая единица измерения времени.",
                                "Наименьшая единица измерения скорости.",
                                "Наименьшая единица измерения мощности."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое сила?",
                            Answers = new List<string>
                            {
                                "Способность совершать работу.",
                                "Величина, характеризующая движение.",
                                "Взаимодействие между телами.",
                                "Мера инерции тела."
                            },
                            CorrectAnswerIndex = 2
                        },
                        new Question
                        {
                            Text = "Какая из величин является скалярной?",
                            Answers = new List<string>
                            {
                                "Скорость.",
                                "Сила.",
                                "Ускорение.",
                                "Масса."
                            },
                            CorrectAnswerIndex = 3
                        },
                        new Question
                        {
                            Text = "Какое из утверждений верно?",
                            Answers = new List<string>
                            {
                                "Тело, на которое не действуют силы, находится в состоянии покоя.",
                                "Тело, на которое не действуют силы, находится в состоянии движения.",
                                "Тело, на которое не действуют силы, может быть как в состоянии покоя, так и в состоянии движения.",
                                "Тело, на которое не действуют силы, находится в состоянии равновесия."
                            },
                            CorrectAnswerIndex = 2
                        },
                        new Question
                        {
                            Text = "Что такое механическая работа?",
                            Answers = new List<string>
                            {
                                "Перемещение тела на определенное расстояние.",
                                "Изменение скорости тела.",
                                "Продукт силы на перемещение.",
                                "Изменение положения тела в пространстве."
                            },
                            CorrectAnswerIndex = 2
                        },
                        new Question
                        {
                            Text = "Какая из величин является мерой инерции тела?",
                            Answers = new List<string>
                            {
                                "Масса.",
                                "Вес.",
                                "Сила.",
                                "Скорость."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Какая из величин является мерой энергии?",
                            Answers = new List<string>
                            {
                                "Мощность.",
                                "Работа.",
                                "Сила.",
                                "Скорость."
                            },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Что такое кинетическая энергия?",
                            Answers = new List<string>
                            {
                                "Энергия покоя тела.",
                                "Энергия движения тела.",
                                "Энергия взаимодействия тел.",
                                "Энергия, связанная с положением тела в гравитационном поле."
                            },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Что такое потенциальная энергия?",
                            Answers = new List<string>
                            {
                                "Энергия движения тела.",
                                "Энергия, связанная с положением тела в гравитационном поле.",
                                "Энергия взаимодействия тел.",
                                "Энергия, связанная с деформацией тела."
                            },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Какая из величин является мерой скорости изменения энергии?",
                            Answers = new List<string>
                            {
                                "Мощность.",
                                "Работа.",
                                "Сила.",
                                "Скорость."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое импульс тела?",
                            Answers = new List<string>
                            {
                                "Произведение массы тела на его скорость.",
                                "Произведение силы на время ее действия.",
                                "Изменение скорости тела.",
                                "Изменение положения тела в пространстве."
                            },
                            CorrectAnswerIndex = 0
                        },
                        new Question
                        {
                            Text = "Какое число следует за числом 7 в последовательности 1, 2, 4, 7?",
                            Answers = new List<string>
                            {
                                "9",
                                "11",
                                "10",
                                "12"
                            },
                            CorrectAnswerIndex = 2
                        },
                        new Question
                        {
                            Text = "Сколько всего дней в неделе?",
                            Answers = new List<string>
                            {
                                "5",
                                "6",
                                "7",
                                "8"
                            },
                            CorrectAnswerIndex = 2
                        },
                        new Question
                        {
                            Text = "Какое число является противоположным числу -5?",
                            Answers = new List<string>
                            {
                                "-5",
                                "5",
                                "0",
                                "10"
                            },
                            CorrectAnswerIndex = 1
                        },
                        new Question
                        {
                            Text = "Какое число является наибольшим в наборе {2, 5, 8, 1}?",
                            Answers = new List<string>
                            {
                                "1",
                                "2",
                                "5",
                                "8"
                            },
                            CorrectAnswerIndex = 3
                        },
                        new Question
                        {
                            Text = "Что такое 10% от 100?",
                            Answers = new List<string>
                            {
                                "1",
                                "10",
                                "100",
                                "1000"
                            },
                            CorrectAnswerIndex = 1
                        }
                    }
                },
                new Quiz()
                {
                    Title = "Математика",
                    questions = new List<Question>()
                }
            };
            questionSerializer.Save(sampleQuestions);
        }
    }
}