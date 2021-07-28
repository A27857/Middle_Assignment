using System;
using System.Collections.Generic;
using System.Linq;
using Middle_Assignments.Helpers;

namespace Middle_Assignments
{
    public class UserService : IUserService
    {
        private LibraryContext _context;

        public UserService(LibraryContext context)
        {
            _context = context;
        }

        public User Authenticate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.DbUser.SingleOrDefault(x => x.UserName == userName);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public List<User> GetAllUser()
        {
            return _context.DbUser.ToList();
        }

        public User GetUserById(int id)
        {
            var userTemp = _context.DbUser.FirstOrDefault(p=>p.UserId == id);
            if (userTemp == null)
            {
                return null;
            }
            return userTemp;
        }

        public User CreateUser(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.DbUser.Any(x => x.UserName == user.UserName))
                throw new AppException("Username \"" + user.UserName + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.DbUser.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void UpdateUser(User userParam, string password = null)
        {
            var user = _context.DbUser.Find(userParam.UserId);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.UserName) && userParam.UserName != user.UserName)
            {
                // throw error if the new username is already taken
                if (_context.DbUser.Any(x => x.UserName == userParam.UserName))
                    throw new AppException("Username " + userParam.UserName + " is already taken");

                user.UserName = userParam.UserName;
            }
            
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
            }

            _context.DbUser.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var user = _context.DbUser.Find(id);
            if (user != null)
            {
                _context.DbUser.Remove(user);
                _context.SaveChanges();
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
