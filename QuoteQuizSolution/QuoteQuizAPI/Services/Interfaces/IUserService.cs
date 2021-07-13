using QuoteQuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuizAPI.Services.Interfaces
{
    public interface IUserService
    {
        public UserModel ValidateUser(string userName, string password);
        public UserModel RegisterUser(RegisterViewModel model);
        public UserModel UpdateUser(UserModel model);
        public int DeleteUser(int Id);
        public int DisableUser(int Id);
        public UserModel GetUserById(int id);
        public int ChangeMode(int newModeId, int userId);
        public UserModel ModifyUser(int userId, string email, string firstName,
                                        string lastName, string password);
        public int getCurrentQuoteModeByUserId(int userId);
        public List<UserModel> GetOtherUsers(int userId);
        public List<UserGameModel> GetUserGameHistory(int userId, string userName);
        public UserTypeModel GetUserTypeMode(int typeId);
    }
}
