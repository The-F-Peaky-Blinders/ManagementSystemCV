using managementcv.Models;
using Microsoft.EntityFrameworkCore;

namespace managementcv.Infraestructures.Context
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {

        }

        public DbSet<User> users {get; set;} 
        public DbSet<Curriculum> curriculums {get; set;}
        public DbSet<Aptitude> aptitudes {get; set;}
        public DbSet<Education> educations {get; set;}
        public DbSet<Language> languages {get; set;}
        public DbSet<Skill> skills {get; set;}
        public DbSet<WorkExperience> WorkExperiences {get; set;}

    }
}