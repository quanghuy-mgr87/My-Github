using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VueEnd.Entities;
using VueEnd.IService;

namespace VueEnd.Service
{
    public class UserService : IUserService
    {
        private QLHocSinhDbContext dbContext { get; }
        public UserService()
        {
            dbContext = new QLHocSinhDbContext();
        }
        public string GetMD5(string str)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }

            return sbHash.ToString();

        }
        public IEnumerable<User> AddUser(User user)
        {
            var newUser = dbContext.Users.Where(x => x.TaiKhoan == user.TaiKhoan || x.Email == user.Email);
            if (newUser.Count() == 0)
            {
                user.MatKhau = GetMD5(user.MatKhau);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                newUser = null;
            }
            return newUser;
        }

        public IEnumerable<User> GetUserList()
        {
            var lstUser = dbContext.Users.AsQueryable();
            return lstUser;
        }

        public User UpdateUser(User user)
        {
            var currentUser = dbContext.Users.SingleOrDefault(x => x.TaiKhoan == user.TaiKhoan);
            if (currentUser != null)
            {
                currentUser.QuyenAdmin = user.QuyenAdmin;
                currentUser.SoDienThoai = user.SoDienThoai;
                currentUser.Email = user.Email;
                if (currentUser.MatKhau != user.MatKhau)
                {
                    currentUser.MatKhau = GetMD5(user.MatKhau);
                }
                dbContext.Users.Update(currentUser);
                dbContext.SaveChanges();
            }
            return currentUser;
        }

        public User CheckUserPass(string username, string password)
        {
            var currentUser = dbContext.Users.SingleOrDefault(x => x.TaiKhoan == username);
            if (currentUser != null)
            {
                if (currentUser.MatKhau == GetMD5(password))
                {
                    return currentUser;
                }
                currentUser = null;
            }
            return currentUser;
        }
    }
}
