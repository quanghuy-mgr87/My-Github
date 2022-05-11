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
    public class LopController : ControllerBase
    {
        private LopService LopService { get; set; }
        public LopController()
        {
            LopService = new LopService();
        }
        [Route("")]
        [HttpGet]
        public IActionResult GetClassList()
        {
            var lstClass = LopService.GetClassList();
            return Ok(lstClass);
        }

        [Route("searchClass/{keyword}")]
        [HttpGet]
        public IActionResult SearchClass(string keyword)
        {
            var lstClass = LopService.SearchClass(keyword);
            return Ok(lstClass);
        }

        [Route("{classId}")]
        [HttpGet]
        public IActionResult GetClassById(int classId)
        {
            var currentClass = LopService.GetClassById(classId);
            if (currentClass == null)
                return BadRequest($"Class {classId} is not exist!");
            return Ok(currentClass);
        }

        [HttpPost]
        public IActionResult AddNewClass(Lop newClass)
        {
            var currentClass = LopService.AddNewClass(newClass);
            return Ok(currentClass);
        }

        [HttpPut]
        public IActionResult UpdateClass(Lop udClass)
        {
            var currentClass = LopService.UpdateClass(udClass);
            if (currentClass == null)
                return BadRequest($"Class {udClass.Id} is not exist!");
            return Ok(udClass);
        }

        [Route("{classId}")]
        [HttpDelete]
        public IActionResult DeleteClass(int classId)
        {
            var currentClass = LopService.DeleteClass(classId);
            if (currentClass == null)
                return BadRequest($"Class {classId} is not exist!");
            return Ok(currentClass);
        }
    }
}
