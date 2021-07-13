using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using QuoteQuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IQuoteService quoteService;

        public UserController(IUserService userService, IQuoteService quoteService)
        {
            this.userService = userService;
            this.quoteService = quoteService;
        }

        public IActionResult DisableUser(int userId)
        {
            var res = userService.DisableUser(userId);
            return RedirectToAction("Login", "User");
        }

        public IActionResult DeleteUser(int userId)
        {
            var res = userService.DeleteUser(userId);
            return RedirectToAction("Login", "User");
        }

        public IActionResult LogOut(int userId)
        {
            return RedirectToAction("Login", "User");
        }

        public IActionResult DisableUserFromAdmin(int admId, int userId)
        {
            var res = userService.DisableUser(userId);
            return RedirectToAction("ReviewOthers", "User", admId);
        }

        public IActionResult DeleteUserFromAdmin(int admId, int userId)
        {
            var res = userService.DeleteUser(userId);
            var user = userService.GetUserById(admId);
            var qm = new QuizModel
            {
                OtherUsers = userService.GetOtherUsers(admId),
                User = user
            };
            return PartialView("~/Views/ReviewGames.cshtml", qm);
        }



        public IActionResult ReviewOthers(int userId)
        {
            var user = userService.GetUserById(userId);
            var qm = new QuizModel
            {
                OtherUsers = userService.GetOtherUsers(userId),
                User = user
            };
            return PartialView("~/Views/ReviewGames.cshtml", qm);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Register.cshtml");
        }

        public IActionResult ModifyUser(int userId, string email, string firstName,
                                        string lastName , string password)
        {
            var userModel = userService.ModifyUser(userId, email, firstName, lastName, password);
            var quizModel = new QuizModel
            {
                User = userModel
            };
            return View("~/Views/AccountManagement.cshtml", quizModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                var user = userService.RegisterUser(model);
                if (user == null)
                {
                    return RedirectToAction("Register", "User");
                }
                return RedirectToAction("LoggedInPage", "Quote", user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Register", "User");
            }
        }



        [HttpGet]
        public IActionResult Login()
        {
            //return View(model);
            return View("~/Views/Login.cshtml");
        }

        public IActionResult getMyGames(int id)
        {
            var user = userService.GetUserById(id);
            return RedirectToAction("getUserGames","User", new { viewerId = id, id = id, username = "You"});

        }

        public IActionResult getUserGames(int viewerId, int id, string username)
        {
            var userGameHistory = userService.GetUserGameHistory(id, username);
            var historyModel = new HistoryModel
            {
                viewerUserId = viewerId,
                chosenUserHistory = userGameHistory
            };
            return View("~/Views/UserGames.cshtml", historyModel); 
        }

        public IActionResult UserManagement(int userId)
        {
            var user = userService.GetUserById(userId);
            var quizModel = new QuizModel
            {
                User = user
            };
            return View("~/Views/AccountManagement.cshtml", quizModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var userModel = Authentication(model);
                if (userModel == null)
                {
                    ModelState.AddModelError("", "Invalid password or username");
                    return RedirectToAction("Login", "User");
                }
                if (!userModel.IsActive)
                {
                    return RedirectToAction("Login", "User");
                }
                //return RedirectToAction
                return RedirectToAction("LoggedInPage", "Quote", userModel);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "User");
            }

        }
        private UserModel Authentication(LoginViewModel model)
        {
            var currentUser = userService.ValidateUser(model.Username, model.Password);
            if (currentUser == null)
            {
                return null;
            }

            //SecurityProvider.
            return currentUser;

        }
    }
}
;