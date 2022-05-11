using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;

namespace VueEnd.IService
{
    interface IUserService
    {
        public IEnumerable<User> GetUserList();
        public IEnumerable<User> AddUser(User user);
        public User UpdateUser(User user);
        public User CheckUserPass(string username, string password);
    }
}
