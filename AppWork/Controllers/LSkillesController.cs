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
    public class LSkillesController : ControllerBase
    {
        private IUserDataProvider userDataProvider;
        public LSkillesController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }
        public async Task<IEnumerable<LinkedinSkill>> Get()
        {
            return await userDataProvider.GetLinkedinSkills();
        }
    }
}