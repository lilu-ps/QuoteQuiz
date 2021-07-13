using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuoteQuizEntity.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }
        public bool IsCorrect { get; set; }
    }
}