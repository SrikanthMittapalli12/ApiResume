using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public int? PersonalInfoId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public DateTime? GraduationDate { get; set; }

        public virtual PersonalInformation PersonalInfo { get; set; }
    }
}
