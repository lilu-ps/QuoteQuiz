using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuoteQuizEntity.Entities
{
    public partial class AnsweredQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuoteId { get; set; }
        public int ChosenAnswerId { get; set; }
        public DateTime AnswerDate { get; set; }
        public Answer ChosenAnswer { get; set; }
        public bool Agreed { get; set; }
        //public User user { get; set; }

    }
}