using Microsoft.AspNetCore.Mvc;
using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Controllers
{
    public class QuizController : Controller
    {

        private readonly IQuoteService quoteService;
        private readonly IAnswerService answerService;
        private readonly IUserService userService;

        public QuizController(IQuoteService quoteService, IAnswerService answerService, IUserService userService)
        {
            this.quoteService = quoteService;
            this.answerService = answerService;
            this.userService = userService;
        }

        public JsonResult ChangeMode(int newModeId, int userId)
        {
            int res = userService.ChangeMode(newModeId, userId);
            return Json(new { Success = res});
        }
        public IActionResult GetModes(int userId)
        {
            var curModeId = userService.getCurrentQuoteModeByUserId(userId);
            var settingsList = quoteService.getModeModels(curModeId);
            var settingsModel = new SettingsModel
            {
                UserId = userId,
                settings = settingsList
            };
            return PartialView("~/Views/Settings.cshtml", new QuizModel { Settings = settingsModel});
        }

        public IActionResult BinaryQuiz(int user, int Quote, int givenChoice, bool agreed)
        {
            var userModel = userService.GetUserById(user);
            var quoteModel = quoteService.getQuoteByQuoteId(Quote);
            QuizModel quizModel = new QuizModel()
            {
                User = userModel,
                Quote = quoteModel,
                Answers = null
            };
            QuizModel mod = answerService.CheckAnsweredQuestionAndSave(quizModel, givenChoice, agreed);
            return PartialView("~/Views/QuizResult.cshtml", mod);
        }

        public IActionResult Index(int user,int Quote,
                                IEnumerable<AnswerModel> Answers, int chosenAnswerId)
        {
            var userModel = userService.GetUserById(user);
            var quoteModel = quoteService.getQuoteByQuoteId(Quote);
            QuizModel quizModel = new QuizModel()
            {
                User = userModel,
                Quote = quoteModel,
                Answers = Answers
            };
            QuizModel mod = answerService.CheckAnsweredQuestionAndSave(quizModel, chosenAnswerId);
            return PartialView("~/Views/QuizResult.cshtml", mod);
        }
    }
}
