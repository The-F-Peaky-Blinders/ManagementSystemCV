
namespace ManagementSystemCV.Models
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public int StartYear { get; set; }
        public string? StartMonth { get; set; }
        public int EndYear { get; set; }
        public string? EndMonth { get; set; }
        
        //Relación n:1
        public int CurriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }
    }
}