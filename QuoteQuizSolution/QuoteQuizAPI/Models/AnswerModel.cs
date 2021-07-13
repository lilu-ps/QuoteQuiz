using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuoteId { get; set; }
        public QuoteModel Quote { get; set; }
        public bool IsCorrect { get; set; }
    }
}
