using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly RepositoryWrapper _repositoryWrapper;
        public OwnerController()
        {
            _repositoryWrapper = new RepositoryWrapper();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(_repositoryWrapper.Owner.FindAll());
        }

        [HttpPost]
        public IActionResult AddData(Owner owner)
        {
            var ret = _repositoryWrapper.Owner.CreateOwner(owner);
            return Ok(ret);
        }

        [HttpPut]
        public IActionResult UpdateData(Owner owner)
        {
            var ret = _repositoryWrapper.Owner.UpdateOwner(owner);
            if (ret == null)
            {
                return BadRequest($"{owner.OwnerId} không tồn tại!");
            }
            else
            {
                return Ok("Cập nhật thành công!");
            }
        }
    }
}
