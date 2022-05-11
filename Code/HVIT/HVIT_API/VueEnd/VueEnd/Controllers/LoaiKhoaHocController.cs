using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueEnd.Entities;
using VueEnd.Service;

namespace VueEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private LoaiKhoaHocService loaiKhoaHocService { get; set; }
        public LoaiKhoaHocController()
        {
            loaiKhoaHocService = new LoaiKhoaHocService();
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetTypeOfCourseList()
        {
            string keyword = null;
            var lstLoaiKhoaHoc = loaiKhoaHocService.GetListTypeOfCourse(keyword);
            return Ok(lstLoaiKhoaHoc);
        }

        [Route("searchCourse/{name}")]
        [HttpGet]
        public IActionResult GetTypeOfCourseListByName(string name)
        {
            var lstLoaiKhoaHoc = loaiKhoaHocService.GetListTypeOfCourse(name);
            return Ok(lstLoaiKhoaHoc);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTypeOfCourseById(int id)
        {
            var loaiKhoaHoc = loaiKhoaHocService.GetTypeOfCourseById(id);
            if (loaiKhoaHoc == null)
            {
                return BadRequest("Chủ đề không tồn tại!");
            }
            return Ok(loaiKhoaHoc);
        }

        [HttpPost]
        public IActionResult CreateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc)
        {
            var newKhoaHoc = loaiKhoaHocService.CreateTypeOfCourse(loaiKhoaHoc);
            if (newKhoaHoc == null)
            {
                return BadRequest($"Khoá học đã tồn tại!");
            }
            return Ok(newKhoaHoc);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteTypeOfCourse(int id)
        {
            var loaiKhoaHoc = loaiKhoaHocService.DeleteTypeOfCourse(id);
            if (loaiKhoaHoc == null)
            {
                return BadRequest("Chủ đề không tồn tại!");
            }
            return Ok(loaiKhoaHoc);
        }

        [HttpPut]
        public IActionResult UpdateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc)
        {
            var newLoaiKhoaHoc = loaiKhoaHocService.UpdateTypeOfCourse(loaiKhoaHoc);
            if (newLoaiKhoaHoc == null)
            {
                return BadRequest("Chủ đề không tồn tại!");
            }
            return Ok(newLoaiKhoaHoc);
        }
    }
}
