using System;
using System.Collections.Generic;

namespace AppWork.Models
{
    public partial class LinkedinProfile
    {
        public LinkedinProfile()
        {
           
            LinkedinSkill = new HashSet<LinkedinSkill>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Location { get; set; }
        public string Education { get; set; }
        public string Company { get; set; }
        public int? ConnectionCount { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public DateTime? Connected { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? LastUpdate { get; set; }

      
        public ICollection<LinkedinSkill> LinkedinSkill { get; set; }
    }
}
