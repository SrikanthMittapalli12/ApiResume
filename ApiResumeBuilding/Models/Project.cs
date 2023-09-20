using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
