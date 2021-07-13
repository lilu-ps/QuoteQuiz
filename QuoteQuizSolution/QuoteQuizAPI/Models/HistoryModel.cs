using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class HistoryModel
    {
        public List<UserGameModel> chosenUserHistory { get; set; }
        public int viewerUserId { get; set; }
    }
}
