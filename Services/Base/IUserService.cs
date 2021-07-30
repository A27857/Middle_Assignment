using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Middle_Assignments
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        List<User> GetAllUser();
        User GetUserById(int id);
        User CreateUser(User user, string password);
        void UpdateUser(User user, string password = null);
        void DeleteUserById(int id);
    }
}