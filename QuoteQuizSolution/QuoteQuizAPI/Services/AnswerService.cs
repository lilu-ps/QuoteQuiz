using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using QuoteQuizEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly QuoteQuizDBContext context;

        public AnswerService(QuoteQuizDBContext context)
        {
            this.context = context;
        }
        public int getMostRecentQuoteId(int userId)
        {
            var mostRecentAnaswer = context.AnsweredQuestions.Where(e => e.UserId == userId).OrderByDescending(e => e.AnswerDate).FirstOrDefault();
            if (mostRecentAnaswer == null) return -1;
            return mostRecentAnaswer.QuoteId;
        }

        public IEnumerable<AnswerModel> getAnswesToQuote(int quoteId)
        {
            var answers = context.Answers.Where(e => e.QuoteId == quoteId).
                                            Select(e => new AnswerModel
                                            {
                                                Id = e.Id,
                                                AnswerText = e.AnswerText,
                                                QuoteId = e.QuoteId,
                                                Quote = new QuoteModel()
                                                {
                                                    Id = e.Quote.Id,
                                                    QuoteTypeId = e.Quote.QuoteTypeId,
                                                    QuoteText = e.Quote.QuoteText
                                                },
                                                IsCorrect = e.IsCorrect
                                            }).ToList();
            return answers;
        }

        
        public QuizModel CheckAnsweredQuestionAndSave(QuizModel quizModel, int chosenAnswerId, bool agreed = false)
        {
            Answer answ = context.Answers.Where(e => e.Id == chosenAnswerId).SingleOrDefault();
            DateTime date = System.DateTime.Now;
            AnsweredQuestion answQ = new AnsweredQuestion()
            {
                UserId = quizModel.User.Id,
                QuoteId = quizModel.Quote.Id,
                ChosenAnswerId = chosenAnswerId,
                AnswerDate = date,
                ChosenAnswer = answ,
                Agreed = agreed
            };
            context.AnsweredQuestions.Add(answQ);
            context.SaveChanges();
            quizModel.Answers = getAnswesToQuote(quizModel.Quote.Id);
            var chosen = quizModel.Answers.FirstOrDefault(e => e.Id == chosenAnswerId);
            var chosenAnswer = new AnsweredQuestionModel()
            {
                Id = answQ.Id,
                UserId = answQ.UserId,
                QuoteId = answQ.QuoteId,
                ChosenAnswerId = answQ.ChosenAnswerId,
                AnswerDate = answQ.AnswerDate,
                ChosenAnswer = chosen,
                Agreed = agreed
            };
            quizModel.ChosenAnswer = chosenAnswer;
            quizModel.CorrectAnswer = quizModel.Answers.Where(e => e.IsCorrect == true).FirstOrDefault();
            return quizModel;
        }
    }
}
