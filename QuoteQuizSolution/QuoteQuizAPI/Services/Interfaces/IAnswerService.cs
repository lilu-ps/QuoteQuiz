using QuoteQuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Services.Interfaces
{
    public interface IAnswerService
    {
        public int getMostRecentQuoteId(int userId);
        public QuizModel CheckAnsweredQuestionAndSave(QuizModel quizModel, int chosenAnswerId, bool agreed = false);
        public IEnumerable<AnswerModel> getAnswesToQuote(int quoteId);
        //public QuizModel CheckBinaryAndSave(QuizModel quizModel, int givenChoiceId, bool agreed);
    }
}
