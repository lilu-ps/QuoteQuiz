using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class QuoteModel
    {
        public int Id { get; set; }
        public int QuoteTypeId { get; set; }
        public string QuoteText { get; set; }
        public QuoteTypeModel QuoteType { get; set; }
    }
}
