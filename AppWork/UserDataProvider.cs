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
                        company = new Company
                        {
                            Id = (int)reader["id"],
                            Name = reader["Name"] as string,
                            Image = reader["image"] as string,
                            Linkedin = reader["Linkedin"] as string,
                            Phone = reader["Phone"] as string,
                            About = reader["About"] as string
                        };

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
                        githubProfile = new GithubProfile
                        {
                            Id = (int)Reader["id"],
                            UserName = Reader["UserName"] as string,
                            Company = Reader["Company"] as string,
                            Name = Reader["Name"] as string,
                            Bio = Reader["Bio"] as string,
                            Location = Reader["Location"] as string,
                            Email = Reader["Email"] as string
                        };
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
                        job = new Job
                        {
                            Id = (int)reader["id"],
                            Title = reader["Title"] as string,
                            Email = reader["Email"] as string,
                            Category = reader["Category"] as string,
                            Description = reader["Description"] as string
                        };
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
                        linkedinProfile = new LinkedinProfile
                        {
                            Id = (int)reader["id"],
                            Username = reader["UserName"] as string,
                            FullName = reader["FullName"] as string,
                            Specialty = reader["Specialty"] as string,
                            Location = reader["Location"] as string
                        };
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
                        linkedinSkill = new LinkedinSkill
                        {
                            Id = (int)reader["id"],
                            Name = reader["Name"] as string
                        };
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
                        staffSkill = new StaffSkill
                        {
                            Id = (int)reader["id"],
                            Name = reader["Name"] as string,
                            Type = reader["Type"] as string
                        };
                        staffSkills.Add(staffSkill);
                    }
                }
                return staffSkills;
            }

        }
    }
}
