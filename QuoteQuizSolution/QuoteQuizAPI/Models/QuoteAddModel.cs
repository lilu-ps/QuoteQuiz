using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class QuoteAddModel
    {
        public string QuoteText { get; set; }
        public string QuoteAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsMultipleChoice { get; set; }
        public string FirstWrongChoice { get; set; }
        public string SecondWrongChoice { get; set; }
    }

}
