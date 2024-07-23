namespace ManagementSystemCV.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? ProficiencyLevel { get; set; }

        //Relación n:1
        public int CurriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }

    }
}