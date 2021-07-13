using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class UserGameModel
    {
        public int userId { get; set; }
        public string Username { get; set; }
        public string QuoteText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
