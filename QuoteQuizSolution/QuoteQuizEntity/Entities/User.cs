using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuoteQuizEntity.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public int CurrentQuoteModeId { get; set; }
        public UserType UserType { get; set; }
        public QuoteType CurrentQuoteMode{get;set;}
    }
}