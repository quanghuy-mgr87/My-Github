using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ThucHanh.Entities;
using API_ThucHanh.IServices;
using API_ThucHanh.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucHanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillServices billServices;
        public BillController()
        {
            billServices = new BillServices();
        }

        //GET:  api/bill
        [Route("")]
        [HttpGet]
        public IActionResult GetBillList()
        {
            var lstBill = billServices.GetBillList("");
            if (lstBill.Count() == 0)
                return BadRequest("Bill list is empty!");
            return Ok(lstBill);
        }

        //POST: api/bill
        [HttpPost]
        public IActionResult PostBill(Bill bill)
        {
            var newBill = billServices.CreateNewBill(bill);
            return Ok(newBill);
        }
    }
}
