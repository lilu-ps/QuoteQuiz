using QuoteQuizAPI.Models;
using QuoteQuizEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Services.Interfaces
{
    public interface IQuoteService
    {
        public QuoteModel addQuote(QuoteModel quote);
        public int editQuote(int Id);
        public int deleteQuote(int Id);
        public QuoteModel getNewQuote(UserModel user, int prevId);
        public int getPreviousQuoteID(int userId);
        public QuoteModel getQuoteByQuoteId(int QuoteId);
        public QuizModel getQuizModel(UserModel user);
        public List<ModeModel> getModeModels(int currentModeId);
    }
}
