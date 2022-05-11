using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VueEnd.Entities;
using VueEnd.Service;

namespace VueEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService UserService { get; set; }
        public UserController()
        {
            UserService = new UserService();
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetUserList()
        {
            var userList = UserService.GetUserList();
            return Ok(userList);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CreateNewUser(User user)
        {
            var newUser = UserService.AddUser(user);
            if (newUser != null)
            {
                newUser.ToList().ForEach(x => x.MatKhau = "");
                return BadRequest(newUser);
            }
            return Ok(newUser);
        }
        [HttpPut]
        public IActionResult UpdatePassword(User user)
        {
            var currentUser = UserService.UpdateUser(user);
            if (currentUser == null)
            {
                return BadRequest($"{user.TaiKhoan} không tồn tại!");
            }
            return Ok(currentUser);
        }
        [HttpPost]
        [Route("checkUserPass")]
        public IActionResult CheckPassword(User user)
        {
            var currentUser = UserService.CheckUserPass(user.TaiKhoan, user.MatKhau);
            if (currentUser == null)
            {
                return BadRequest($"Tài khoản hoặc mật khẩu không chính xác!");
            }
            return Ok(currentUser);
        }
    }
}
