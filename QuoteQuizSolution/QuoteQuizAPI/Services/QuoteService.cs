using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using QuoteQuizEntity.Entities;

namespace QuoteQuizAPI.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly QuoteQuizDBContext context;
        private readonly IAnswerService answerService;

        public QuoteService(QuoteQuizDBContext context, IAnswerService answerService)
        {
            this.context = context;
            this.answerService = answerService;
        }

        public QuoteModel addQuote(QuoteModel quote)
        {
            return quote;
        }
        public int editQuote(int Id)
        {
            return -1;
        }
        public int deleteQuote(int Id)
        {
            return -1;
        }

      

        public int getPreviousQuoteID(int userId)
        {

            return -1;
        }
        public QuoteModel getNewQuote(UserModel user, int prevId)
        {   

            var list = context.Quotes.Where(item => item.QuoteTypeId == user.CurrentQuoteModeId).ToList();
            int index = prevId > 0 ? list.FindIndex(a => a.Id == prevId) : -1;

            
            var res = list.Count() > 0 ? list[(index + 1) % list.Count()] : null;
            if (res != null)
            {
                return convertcastQuoteToQuoteModel(res);
            }
            return convertcastQuoteToQuoteModel(context.Quotes.Where(item => item.QuoteTypeId == user.CurrentQuoteModeId).FirstOrDefault());
        }

        public QuoteModel getQuoteByQuoteId(int QuoteId)
        {
            var quote = context.Quotes.SingleOrDefault(e => e.Id == QuoteId);
            return convertcastQuoteToQuoteModel(quote);
        }

        public QuizModel getQuizModel(UserModel user)
        {
            QuoteModel quote = getNewQuote(user, answerService.getMostRecentQuoteId(user.Id));
            var answers = answerService.getAnswesToQuote(quote.Id);
            var qm = new QuizModel()
            {
                User = user,
                Quote = quote,
                Answers = answers
            };
            return qm;
        }

        public List<ModeModel> getModeModels(int currentModeId)
        {
            return context.QuoteTypes.Select(e => new ModeModel { IsCurrentMode = e.Id == currentModeId,
                                                                  type = new QuoteTypeModel
                                                                  {
                                                                      Id = e.Id,
                                                                      QuoteTypeName = e.QuoteTypeName
                                                                  }}).ToList();                                                                
        }

        private QuoteModel convertcastQuoteToQuoteModel(Quote quote)
        {
            if (quote == null) return null;
            quote.QuoteType = context.QuoteTypes.SingleOrDefault(e => e.Id == quote.QuoteTypeId);
            return new QuoteModel()
            {
                Id = quote.Id,
                QuoteTypeId = quote.QuoteTypeId,
                QuoteText = quote.QuoteText,
                QuoteType = new QuoteTypeModel()
                {
                    Id = quote.QuoteType.Id,
                    QuoteTypeName = quote.QuoteType.QuoteTypeName
                }
            };
        }
    }
}
