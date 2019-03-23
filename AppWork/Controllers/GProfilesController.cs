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
    public class GProfilesController : ControllerBase
    {
        private IUserDataProvider userDataProvider;
        public GProfilesController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }

        public async Task<IEnumerable<GithubProfile>> Get()
        {
            return await userDataProvider.GetGithubProfiles();
        }
    }
}