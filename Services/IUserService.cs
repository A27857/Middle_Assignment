using System;
using System.Collections.Generic;
using System.Linq;

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