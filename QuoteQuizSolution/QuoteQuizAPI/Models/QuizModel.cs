using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class QuizModel
    {
        public UserModel User { get; set; }
        public QuoteModel Quote { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }
        public AnsweredQuestionModel ChosenAnswer { get; set; }
        public AnswerModel CorrectAnswer { get; set; }
        public SettingsModel Settings { get; set; }
        public List<UserModel> OtherUsers { get; set; }

    }
}
