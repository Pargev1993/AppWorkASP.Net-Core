using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppWork.Models;
using Dapper;

namespace AppWork
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Monitoring; Integrated Security = True;";
        public  List<string> GetCompanies()

        {
            List<Company> companies = new List<Company>();
            string sqlcomandstring = "select * from Monitoring.dbo.Company";
            Company company = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                 sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlcomandstring, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        company = new Company();
                        company.Name = reader["Name"] as string;
                        companies.Add(company);
                        
                    }

                }
            }
            return companies.Select(com => com.Name).ToList();
        }

        public Task<IEnumerable<GithubProfile>> GetGithubProfiles(GithubProfile githubProfile)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Job>> GetJobs(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinkedinProfile>> GetLinkedinProfiles(LinkedinProfile linkedinProfile)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinkedinSkill>> GetLinkedinSkills(LinkedinSkill linkedinSkill)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StaffSkill>> GetStaffSkills(StaffSkill staffSkill)
        {
            throw new NotImplementedException();
        }
    }
}
