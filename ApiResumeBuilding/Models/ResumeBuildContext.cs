using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiResumeBuilding.Models
{
    public partial class ResumeBuildContext : DbContext
    {
        public ResumeBuildContext()
        {
        }

        public ResumeBuildContext(DbContextOptions<ResumeBuildContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AwardsAndHonor> AwardsAndHonors { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CI15T36P\\SQLEXPRESS;Database=ResumeBuild;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AwardsAndHonor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwardDate)
                    .HasColumnType("date")
                    .HasColumnName("award_date");

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("award_name");

                entity.Property(e => e.AwardingOrganization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("awarding_organization");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.AwardsAndHonors)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__AwardsAnd__perso__49C3F6B7");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CertificationDate)
                    .HasColumnType("date")
                    .HasColumnName("certification_date");

                entity.Property(e => e.CertificationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("certification_name");

                entity.Property(e => e.Organization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("organization");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__Certifica__perso__412EB0B6");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactUsId)
                    .HasName("PK__ContactU__E10B7AE89B21BA51");

                entity.Property(e => e.ContactUsId).HasColumnName("ContactUsID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("degree");

                entity.Property(e => e.GraduationDate)
                    .HasColumnType("date")
                    .HasColumnName("graduation_date");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("institution");

                entity.Property(e => e.Major)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("major");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__Education__perso__38996AB5");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("language_name");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.Property(e => e.ProficiencyLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proficiency_level");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Languages)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__Languages__perso__440B1D61");
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.ToTable("PersonalInformation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Summary)
                    .HasColumnType("text")
                    .HasColumnName("summary");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnType("text")
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnType("date")
                    .HasColumnName("project_end_date");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("date")
                    .HasColumnName("project_start_date");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__Projects__person__46E78A0C");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.Property(e => e.SkillLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("skill_level");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__Skills__personal__3B75D760");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsAppId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.ToTable("WorkExperience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.PersonalInfoId).HasColumnName("personal_info_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.PersonalInfo)
                    .WithMany(p => p.WorkExperiences)
                    .HasForeignKey(d => d.PersonalInfoId)
                    .HasConstraintName("FK__WorkExper__perso__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
