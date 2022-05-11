using DoAn.Entities;
using DoAn.Helper;
using DoAn.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services
{
    class UserServices : IUserServices
    {
        private AppDbContext dbContext { get; }
        public UserServices()
        {
            dbContext = new AppDbContext();
        }
        public bool DeleteUser(int userId)
        {
            var user = dbContext.users.Find(userId);
            if (user != null)
            {
                dbContext.users.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> GetUserList(string keyword = "")
        {
            IList<User> lstUser = dbContext.users.AsQueryable().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                lstUser = (IList<User>)lstUser.Where(x => x.username.Contains(keyword));
            }
            var lstResult = lstUser.Select(x => new User()
            {
                id = x.id,
                username = x.username,
                email = x.email,
                ngaySinh = x.ngaySinh,
                soDienThoai = x.soDienThoai,
                roleId = x.roleId
            }).ToList();
            return lstResult;
        }

        public bool SignIn(string username, string password)
        {
            var user = dbContext.users.SingleOrDefault(x => x.username == username);
            if (user != null)
            {
                if (user.password == InputHelper.MD5Hash(password))
                    return true;
                return false;
            }
            return false;
        }

        public bool SignUp(User user)
        {
            if (!dbContext.users.Any(x => x.username == user.username))
            {
                user.id = 0;
                user.roleId = 2;
                user.password = InputHelper.MD5Hash(user.password);
                dbContext.users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserById(int id)
        {
            User user = dbContext.users.Find(id);
            return user;
        }

        public bool UpdateUser(User user)
        {
            var currentUser = dbContext.users.SingleOrDefault(x => x.id == user.id);
            if (currentUser != null)
            {
                currentUser.password = user.password;
                currentUser.email = user.email;
                currentUser.ngaySinh = user.ngaySinh;
                currentUser.roleId = user.roleId;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserByUsername(string username)
        {
            User user = dbContext.users.SingleOrDefault(x => x.username == username);
            return user;
        }
    }
}
