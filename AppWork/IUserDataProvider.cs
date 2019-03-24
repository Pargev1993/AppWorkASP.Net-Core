using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWork.Models;

namespace AppWork
{
   public interface IUserDataProvider
    {
        Task<IEnumerable<GithubProfile>> GetGithubProfiles();
        Task<IEnumerable<Job>> GetJobs( );
        Task<IEnumerable<LinkedinProfile>> GetLinkedinProfiles();
        Task<IEnumerable<LinkedinSkill>> GetLinkedinSkills();
        Task<IEnumerable<StaffSkill>> GetStaffSkills();
        Task<List<Company>> GetCompanies();
        
    }
}
