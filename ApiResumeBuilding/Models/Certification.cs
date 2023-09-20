using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class Certification
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string CertificationName { get; set; }
        public DateTime? CertificationDate { get; set; }
        public string Organization { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
