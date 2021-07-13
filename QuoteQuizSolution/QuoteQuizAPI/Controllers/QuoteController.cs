using Microsoft.AspNetCore.Mvc;
using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteService quoteService;
        private readonly IAnswerService answerService;
        private readonly IUserService userService;


        public QuoteController(IQuoteService quoteService, IAnswerService answerService, 
                               IUserService userService) {
            this.quoteService = quoteService;
            this.answerService = answerService;
            this.userService = userService;
        }

        public IActionResult TabIndex(int userId)
        {
            UserModel user = userService.GetUserById(userId);
            return RedirectToAction("Index", "Quote", user);
        }

        public IActionResult AddQuote(int creatorId, string Quote, string QuoteAnsw, bool isCorrect,
                                      bool isMultChoice, string secChoice, string thirdChoice)
        {
            return RedirectToAction("ManageQuotes", "Quote", creatorId);
        }



        public IActionResult Index(UserModel user)
        {
            var qm = quoteService.getQuizModel(user);
            return PartialView("~/Views/Quiz.cshtml", qm);

        }

        public IActionResult ManageQuotes(int currentUserId)
        {
            var quoteAddModel = new QuoteAddModel()
            {
                CreatorId = currentUserId
            };
            return PartialView("~/Views/QuoteTab.cshtml", quoteAddModel);
        }

        public IActionResult LoggedInPage(UserModel user)
        {
            user.UserType = userService.GetUserTypeMode(user.UserTypeId);
            var qm = quoteService.getQuizModel(user);
            return View("~/Views/Home/Index.cshtml", qm);
        }

    }
}
