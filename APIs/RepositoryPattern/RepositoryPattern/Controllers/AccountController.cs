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
    public class AccountController : ControllerBase
    {
        private readonly RepositoryWrapper _repositoryWrapper;
        public AccountController()
        {
            _repositoryWrapper = new RepositoryWrapper();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(_repositoryWrapper.Account.FindAll());
        }

        [HttpPost]
        public IActionResult AddData(Account account)
        {
            return Ok();
        }
    }
}
