using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class ModeModel
    {
        public QuoteTypeModel type { get; set; }
        public bool IsCurrentMode { get; set; }
    }
}
