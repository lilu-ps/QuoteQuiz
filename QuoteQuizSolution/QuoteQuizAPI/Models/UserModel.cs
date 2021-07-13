using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public int CurrentQuoteModeId { get; set; }
        public UserTypeModel UserType { get; set; }
        public QuoteTypeModel CurrentQuoteMode { get; set; }
    }
}
