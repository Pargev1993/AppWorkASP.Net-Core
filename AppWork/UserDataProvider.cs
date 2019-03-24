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
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                await sqlconnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(sqlcomandstring, sqlconnection);
                using (SqlDataReader Reader = sqlCommand.ExecuteReader())
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

        public async Task<IEnumerable<Job>> GetJobs()
        {
            string ComandText = "select * from Monitoring.dbo.Job";
            Job job = null;
            List<Job> jobs = new List<Job>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(ComandText, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    foreach (var item in reader)
                    {
                        job = new Job();
                        job.Id = (int)reader["id"];
                        job.Title = reader["Title"] as string;
                        job.Email = reader["Email"] as string;
                        job.Category = reader["Category"] as string;
                        job.Description = reader["Description"] as string;
                        jobs.Add(job);
                    }
                }
                return jobs;
            }
        }

        public async Task<IEnumerable<LinkedinProfile>> GetLinkedinProfiles()
        {
            LinkedinProfile linkedinProfile = null;
            List<LinkedinProfile> linkedinProfiles = new List<LinkedinProfile>();
            string comandtext = "select * from Monitoring.dbo.LinkedinProfile";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(comandtext, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        linkedinProfile = new LinkedinProfile();
                        linkedinProfile.Id = (int)reader["id"];
                        linkedinProfile.Username = reader["UserName"] as string;
                        linkedinProfile.FullName = reader["FullName"] as string;
                        linkedinProfile.Specialty = reader["Specialty"] as string;
                        linkedinProfile.Location = reader["Location"] as string;
                        linkedinProfiles.Add(linkedinProfile);
                    }
                }
                return linkedinProfiles;
            }
        }

        public async Task<IEnumerable<LinkedinSkill>> GetLinkedinSkills()
        {
            LinkedinSkill linkedinSkill = null;
            List<LinkedinSkill> linkedinSkills = new List<LinkedinSkill>();
            string comandtext = "select * from Monitoring.dbo.LinkedinSkill";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(comandtext, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        linkedinSkill = new LinkedinSkill();
                        linkedinSkill.Id = (int)reader["id"];
                        linkedinSkill.Name = reader["Name"] as string;
                        linkedinSkills.Add(linkedinSkill);
                      
                    }
                }
                return linkedinSkills;
            }

        }

        public async Task<IEnumerable<StaffSkill>> GetStaffSkills()
        {
            StaffSkill staffSkill = null;
            List<StaffSkill> staffSkills = new List<StaffSkill>();
            string comandtext = "select * from Monitoring.dbo.StaffSkill";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlCommand = new SqlCommand(comandtext, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffSkill = new StaffSkill();
                        staffSkill.Id = (int)reader["id"];
                        staffSkill.Name = reader["Name"] as string;
                        staffSkill.Type = reader["Type"] as string;
                        staffSkills.Add(staffSkill);
                    }
                }
                return staffSkills;
            }

        }
    }
}
