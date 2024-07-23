using ManagementSystemCV.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemCV.Infraestructures.Context
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Aptitude> Aptitudes { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

    }
}