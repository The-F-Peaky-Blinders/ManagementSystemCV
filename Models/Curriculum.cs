namespace managementcv.Models
{
    public class Curriculum
    {
        public int CurriculumId { get; set; }
        public string? Title { get; set; }
        public string? AboutMe { get; set; }

        // Relación 1:1 hijo
        public int UserId { get; set; }
        public User? User { get; set; }

        // Relaciones 1:N padres
        public ICollection<Aptitude>? Aptitudes { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<WorkExperience>? WorkExperiences { get; set; }


    }
}