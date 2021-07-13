using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class AnsweredQuestionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuoteId { get; set; }
        public int ChosenAnswerId { get; set; }
        public DateTime AnswerDate { get; set; }
        public AnswerModel ChosenAnswer { get; set; }
        public UserModel user { get; set; }
        public QuoteModel Quote { get; set; }
        public bool Agreed { get; set; }
    }
}
