using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx
{
    public interface IUserDataReader
    {
        string ReadLogin();
        string ReadPassword();
    }
}
