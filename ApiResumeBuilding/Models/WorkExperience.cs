using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class WorkExperience
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
