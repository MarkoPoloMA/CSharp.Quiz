using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.MenuCommand
{
    public interface ICommand
    {
        void Execute();
        string Description();
    }
}
