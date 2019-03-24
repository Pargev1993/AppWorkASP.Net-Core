using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppWork.Models;

namespace AppWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IUserDataProvider userDataProvider;
        public JobController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }
        [HttpGet]
        public async Task<IEnumerable<Job>> Get()
        {

            return await userDataProvider.GetJobs();
        }
    }
}