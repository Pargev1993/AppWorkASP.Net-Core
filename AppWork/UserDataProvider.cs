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
        public async Task<List<Company>> GetCompanies()

        {
            List<Company> companies = new List<Company>();
            string sqlcomandstring = "select * from Monitoring.dbo.Company";
            Company company = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(sqlcomandstring, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        company = new Company();
                        company.Id = (int)reader["id"];
                        company.Name = reader["Name"] as string;
                        company.Image = reader["image"] as string;
                        company.Linkedin = reader["Linkedin"] as string;
                        company.Phone = reader["Phone"] as string;
                        company.About = reader["About"] as string;

                       companies.Add(company);
                        
                    }
                    reader.Close();
                }
                return companies;
            }

              
        }

        public async Task<IEnumerable<GithubProfile>> GetGithubProfiles()
        {
            GithubProfile githubProfile = null;
            List<GithubProfile> githubProfiles = new List<GithubProfile>();
            string sqlcomandstring = "select * from Monitoring.dbo.GithubProfile";
            using (SqlConnection sqlconnection=new SqlConnection (connectionString))
            {
                await sqlconnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(sqlcomandstring, sqlconnection);
                using (SqlDataReader Reader=sqlCommand.ExecuteReader())
                {
                    foreach (var item in Reader)
                    {
                        githubProfile = new GithubProfile();
                        githubProfile.Id = (int)Reader["id"];
                        githubProfile.UserName = Reader["UserName"] as string;
                        githubProfile.Company = Reader["Company"] as string;
                        githubProfile.Name = Reader["Name"] as string;
                        githubProfile.Bio = Reader["Bio"] as string;
                        githubProfile.Location = Reader["Location"] as string;
                        githubProfile.Email = Reader["Email"] as string;
                        githubProfiles.Add(githubProfile);
                    }
                }
                return githubProfiles;
            }
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
