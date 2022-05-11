using DemoApiDBFirst.Controller;
using DemoApiDBFirst.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApiDBFirst.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private LopService lopService = new LopService();

        [HttpGet]
        public IActionResult LayDSLop()
        {
            var lstLop = lopService.LayDSLop();
            if (lstLop.Count > 0)
            {
                return Ok(lstLop);
            }
            else
            {
                return BadRequest("Danh sách trống!");
            }
        }

        [HttpPost]
        public IActionResult ThemLop(Lop newLop)
        {
            bool check = lopService.ThemLop(newLop);
            if (check == true)
            {
                return Ok("Thêm thành công!");
            }
            else
            {
                return BadRequest($"Tên lớp {newLop.TenLop} đã tồn tại!");
            }
        }

        [HttpPut]
        public IActionResult SuaLop(Lop lopUpdate)
        {
            bool check = lopService.SuaLop(lopUpdate);
            if (check == true)
            {
                return Ok("Sửa thành công!");
            }
            else
            {
                return BadRequest($"Lớp có ID là {lopUpdate.LopId} không tồn tại!");
            }
        }

        [HttpDelete]
        public IActionResult XoaLop(int LopId)
        {
            bool check = lopService.XoaLop(LopId);
            if (check == true)
            {
                return Ok($"Đã xoá lớp có ID {LopId}");
            }
            else
            {
                return BadRequest($"Lớp có ID là {LopId} không tồn tại!");
            }
        }
    }
}
