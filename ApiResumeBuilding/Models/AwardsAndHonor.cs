using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class AwardsAndHonor
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string AwardName { get; set; }
        public DateTime? AwardDate { get; set; }
        public string AwardingOrganization { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
