using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.MenuCommand
{
    public class ConsoleMenu
    {
        private readonly List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите команду: ");

                for (int i = 0; i < commands.Count; i++)
                    Console.WriteLine($"{i + 1}. {commands[i].Description()}");
                Console.WriteLine("0. Выход");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        Console.WriteLine("Выход из программы...");
                        break;
                    }
                    else if (choice > 0 && choice <= commands.Count)
                    {
                        commands[choice - 1].Execute();
                        Console.WriteLine("Нажмите любую кнопку...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    }
                }
                else
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
            }
        }
    }
}
