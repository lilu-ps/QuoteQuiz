using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuoteQuizAPI.Services.Interfaces;
using QuoteQuizEntity.Entities;

namespace QuoteQuizAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly QuoteQuizDBContext context;

        public ReviewService(QuoteQuizDBContext context)
        {
            this.context = context;
        }
    }
}
