using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppWork.Models;
using Newtonsoft.Json;

namespace AppWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IUserDataProvider userDataProvider;

        public CompanyController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }
        [HttpGet]
        public  Task< List<Company>> Get()
        {
           var s= userDataProvider.GetCompanies();
            return s;
        }
    }
}