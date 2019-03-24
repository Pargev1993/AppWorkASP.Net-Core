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
    public class StaffSkillController : ControllerBase
    {
        private IUserDataProvider userDataProvider;
        public StaffSkillController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }
        [HttpGet]
        public async Task<IEnumerable<StaffSkill>> Get()
        {
            return await userDataProvider.GetStaffSkills();
        }

    }
}