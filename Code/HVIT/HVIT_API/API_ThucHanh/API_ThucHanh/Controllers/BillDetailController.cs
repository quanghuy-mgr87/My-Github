using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ThucHanh.Entities;
using API_ThucHanh.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucHanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private BillDetailServices billDetailServices { get; set; }
        public BillDetailController()
        {
            billDetailServices = new BillDetailServices();
        }

        // GET: api/billDetail
        [Route("")]
        [HttpGet]
        public IActionResult GetBillList()
        {
            var lstBillDetails = billDetailServices.GetBillDetailList();
            if (lstBillDetails.Count() == 0)
            {
                return BadRequest("Blank bill details list!");
            }
            return Ok(lstBillDetails);
        }

        //POST: api/billDetail
        [HttpPost]
        public IActionResult CreateNewBillDetail(BillDetail billDetail)
        {
            var newBillDetail = billDetailServices.CreateNewBillDetail(billDetail);
            if (newBillDetail == null)
            {
                return BadRequest("Bill or product is not exist!");
            }
            return Ok(newBillDetail);
        }
    }
}
