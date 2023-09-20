using System;
using System.Collections.Generic;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class PersonalInformation
    {
        public PersonalInformation()
        {
            AwardsAndHonors = new HashSet<AwardsAndHonor>();
            Certifications = new HashSet<Certification>();
            Educations = new HashSet<Education>();
            Languages = new HashSet<Language>();
            Projects = new HashSet<Project>();
            Skills = new HashSet<Skill>();
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<AwardsAndHonor> AwardsAndHonors { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
