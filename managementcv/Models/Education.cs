namespace managementcv.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string? InstitutionName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public int StartYear { get; set; }
        public string? StartMonth { get; set; }
        public int EndYear{ get; set; }
        public string? EndtMonth { get; set; }

        //Relación n:1
        public int CurriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }
    }
}