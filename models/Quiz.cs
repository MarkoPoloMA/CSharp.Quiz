using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.Entities
{
    [Serializable]
    public class Quiz
    {
        public string Title { get; set; }
        public List<Question> questions { get; set; }
        public Quiz() { }
        public Quiz(string title, List<Question> questions)
        {
            Title = title;
            this.questions = questions;
        }
    }
}
