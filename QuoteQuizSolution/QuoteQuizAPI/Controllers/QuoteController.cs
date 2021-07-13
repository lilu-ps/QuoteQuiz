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





        public IActionResult Index(UserModel user)
        {
            var qm = quoteService.getQuizModel(user);
            return PartialView("~/Views/Quiz.cshtml", qm);

        }

        public IActionResult LoggedInPage(UserModel user)
        {
            var qm = quoteService.getQuizModel(user);
            return View("~/Views/Home/Index.cshtml", qm);
        }

    }
}
