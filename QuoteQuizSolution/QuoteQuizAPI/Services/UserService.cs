using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuoteQuizAPI.Constants;
using QuoteQuizAPI.Models;
using QuoteQuizAPI.Services.Interfaces;
using QuoteQuizEntity.Entities;

namespace QuoteQuizAPI.Services
{
    public class UserService : IUserService
    {
        private readonly QuoteQuizDBContext context;
        private readonly IMapper mapper;

        public UserService(QuoteQuizDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int ChangeMode(int newModeId, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            user.CurrentQuoteModeId = newModeId;
            return context.SaveChanges();
        }


        public int getCurrentQuoteModeByUserId(int userId)
        {
           return context.Users.FirstOrDefault(e => e.Id == userId).CurrentQuoteModeId;
        }

        public UserModel ModifyUser(int userId, string email, string firstName,
                                        string lastName, string password)
        {
            var user = GetUserDBById(userId);
            if (email != null && context.Users.FirstOrDefault(u => u.Username == email) == null)
                user.Username = email;
            
            if (firstName != null)
                user.FirstName = firstName;

            if (lastName != null)
                user.LastName = lastName;
            
            if (password != null)
                user.Password = Encrypt(password);

            context.SaveChanges();
            return castUserToUserModel(user);
        }

        private User GetUserDBById(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            var userType = context.UserTypes.SingleOrDefault(u => u.Id == user.UserTypeId);
            var modeType = context.QuoteTypes.SingleOrDefault(u => u.Id == user.CurrentQuoteModeId);
            user.UserType = userType;
            user.CurrentQuoteMode = modeType;
            return user;
        }

        //public int Id { get; set; }
        //public string AnswerText { get; set; }
        //public int QuoteId { get; set; }
        //public QuoteModel Quote { get; set; }
        //public bool IsCorrect { get; set; }


        //public int Id { get; set; }
        //public int QuoteTypeId { get; set; }
        //public string QuoteText { get; set; }
        //public QuoteTypeModel QuoteType { get; set; }

        //public int Id { get; set; }
        //public string QuoteTypeName { get; set; }
        public List<UserGameModel> GetUserGameHistory(int userId, string userName)
        {

            var userGameHistory = (from answer in context.AnsweredQuestions
             join quote in context.Quotes on answer.QuoteId equals quote.Id
             join quoteType in context.QuoteTypes on quote.QuoteTypeId equals quoteType.Id
             join chosen in context.Answers on answer.ChosenAnswerId equals chosen.Id
             where answer.UserId == userId
             select new UserGameModel
             {
                 userId = userId,
                 Username = userName,
                 QuoteText = quote.QuoteText,
                 IsCorrect = (quoteType.QuoteTypeName == Constants.ModeConstants.Binary
                            &&((chosen.IsCorrect && answer.Agreed)||(!chosen.IsCorrect && !answer.Agreed))) ||
                             (quoteType.QuoteTypeName == Constants.ModeConstants.MultipleChoice
                             && chosen.IsCorrect)
             }).ToList();
            return userGameHistory;
        }


        public UserModel GetUserById(int id)
        {
            return castUserToUserModel(GetUserDBById(id));
        }

        public UserModel UpdateUser(UserModel model)
        {
            if (model == null) return null;
            var user = context.Users.FirstOrDefault(u => u.Id == model.Id);

            if (user == null) return null;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Password = Encrypt(model.Password);
            user.Username = model.Username;
            context.SaveChanges();

            return mapper.Map<UserModel>(user);

        }

        public int DeleteUser(int Id)
        {
            if (!context.Users.Any(x => x.Id == Id))
            {
                return -1;
            }
            User user = context.Users.FirstOrDefault(x => x.Id == Id);
            context.Users.Remove(user);

            return context.SaveChanges();
        }

        public List<UserModel> GetOtherUsers(int userId)
        {
            var users = context.Users.Where(e => e.Id != userId).Select(user => new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                UserTypeId = user.UserTypeId,
                UserType = new UserTypeModel()
                {
                    Id = user.UserTypeId,
                    UserTypeDesc = user.UserType.UserTypeDesc
                },
                IsActive = user.IsActive,
                CurrentQuoteModeId = user.CurrentQuoteModeId,
                CurrentQuoteMode = new QuoteTypeModel
                {
                    Id = user.CurrentQuoteMode.Id,
                    QuoteTypeName = user.CurrentQuoteMode.QuoteTypeName
                }
            });
            return users.ToList();
        }

        public int DisableUser(int Id)
        {
            if (!context.Users.Any(x => x.Id == Id))
            {
                return -1;
            }
            User user = context.Users.FirstOrDefault(x => x.Id == Id);
            user.IsActive = false;
            context.SaveChanges();

            return context.SaveChanges();
        }

        public UserModel RegisterUser(RegisterViewModel model)
        {
            if (model == null) return null;
            var alreadyExists = context.Users.FirstOrDefault(u => u.Username == model.Username);
            if (alreadyExists != null) return null;

            var userType = context.UserTypes.SingleOrDefault(u => u.UserTypeDesc == UserConstants.Player);
            var modeType = context.QuoteTypes.SingleOrDefault(u => u.QuoteTypeName == ModeConstants.Binary);

            User newUser = new User()
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = Encrypt(model.Password),
                    IsActive = true,
                    UserTypeId = userType.Id,
                    UserType = userType,
                    CurrentQuoteModeId = modeType.Id,
                    CurrentQuoteMode = modeType
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            
            return castUserToUserModel(newUser);
        }
        public UserModel ValidateUser(string userName, string password)
        {
            var encryptedPassword = Encrypt(password);
            var user = context.Users.
                                Include(a => a.CurrentQuoteMode).
                                Include(a => a.UserType).
                                FirstOrDefault(a => a.Username == userName && a.Password == encryptedPassword && a.IsActive == true);
            if (user == null)
                return null;
            user.UserType = context.UserTypes.SingleOrDefault(e => e.Id == user.UserTypeId);
            user.CurrentQuoteMode = context.QuoteTypes.SingleOrDefault(e => e.Id == user.CurrentQuoteModeId);
            return castUserToUserModel(user);
        }

        private UserModel castUserToUserModel(User user)
        {
            UserModel cast = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                UserTypeId = user.UserTypeId,
                UserType = new UserTypeModel()
                {
                    Id = user.UserTypeId,
                    UserTypeDesc = user.UserType.UserTypeDesc
                },
                IsActive = user.IsActive,
                CurrentQuoteModeId = user.CurrentQuoteModeId,
                CurrentQuoteMode = new QuoteTypeModel
                {
                    Id = user.CurrentQuoteMode.Id,
                    QuoteTypeName = user.CurrentQuoteMode.QuoteTypeName
                }
            };
            return cast;
        }

        private string Encrypt(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private string Decrypt(string ecodedPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(ecodedPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }

}
