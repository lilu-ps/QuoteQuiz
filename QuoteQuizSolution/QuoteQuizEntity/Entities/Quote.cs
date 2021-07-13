using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuoteQuizEntity.Entities
{
    public partial class Quote
    {
        public int Id { get; set; }
        public int QuoteTypeId { get; set; }
        public string QuoteText { get; set; }
        public QuoteType QuoteType { get; set; }
    }
}