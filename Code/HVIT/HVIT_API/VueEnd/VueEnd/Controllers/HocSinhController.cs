using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;
using VueEnd.Service;

namespace VueEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HocSinhController : ControllerBase
    {
        private HocSinhService HocSinhService { get; set; }
        public HocSinhController()
        {
            HocSinhService = new HocSinhService();
        }
        [Route("")]
        [HttpGet]
        public IActionResult GetStudentList()
        {
            var studentList = HocSinhService.GetStudentList();
            return Ok(studentList);
        }

        [Route("{studentId}")]
        [HttpGet]
        public IActionResult GetStudentById(int studentId)
        {
            var student = HocSinhService.GetStudentListById(studentId);
            if (student == null)
                return BadRequest($"Student {studentId} id not exist!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddNewStudent(HocSinh student)
        {
            var newStudent = HocSinhService.AddNewStudent(student);
            return Ok(newStudent);
        }
    
        [HttpPut]
        public IActionResult UpdateStudent(HocSinh student)
        {
            var currentStudent = HocSinhService.UpdateStudent(student);
            if (currentStudent == null)
                return BadRequest($"Student {student.Id} id not exist!");
            return Ok(currentStudent);
        }

        [Route("{studentId}")]
        [HttpDelete]
        public IActionResult DeleteStudent(int studentId)
        {
            var currentStudent = HocSinhService.DeleteStudent(studentId);
            if (currentStudent == null)
                return BadRequest($"Student {studentId} id not exist!");
            return Ok(currentStudent);
        }
    }
}
