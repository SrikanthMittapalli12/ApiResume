using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class Skill
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string SkillName { get; set; }
        public string SkillLevel { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
