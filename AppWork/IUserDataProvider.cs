using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWork.Models;

namespace AppWork
{
   public interface IUserDataProvider
    {
        Task<IEnumerable<GithubProfile>> GetGithubProfiles(GithubProfile githubProfile);
        Task<IEnumerable<Job>> GetJobs( Job job);
        Task<IEnumerable<LinkedinProfile>> GetLinkedinProfiles(LinkedinProfile linkedinProfile);
        Task<IEnumerable<LinkedinSkill>> GetLinkedinSkills(LinkedinSkill linkedinSkill);
        Task<IEnumerable<StaffSkill>> GetStaffSkills(StaffSkill staffSkill);
        List<string> GetCompanies();
        
    }
}
