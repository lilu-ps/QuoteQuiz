using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class SettingsModel
    {
        public List<ModeModel> settings { get; set; }
        public int UserId { get; set; }
    }
}
