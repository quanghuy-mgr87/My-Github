using DoAn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.IServices
{
    interface IUserServices
    {
        public List<User> GetUserList(string keyword = "");
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
        public bool SignUp(User user);
        public bool SignIn(string username, string password);
        public bool DeleteUser(int userId);
        public bool UpdateUser(User user);
    }
}
