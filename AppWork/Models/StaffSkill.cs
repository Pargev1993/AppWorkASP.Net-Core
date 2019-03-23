using System;
using System.Collections.Generic;

namespace AppWork.Models
{
    public partial class StaffSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int JobId { get; set; }

        public Job Job { get; set; }
    }
}
