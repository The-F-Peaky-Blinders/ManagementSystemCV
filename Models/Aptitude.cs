namespace ManagementSystemCV.Models
{
    public class Aptitude
    {
        public int AptitudeId { get; set; }
        public string? AptitudeName { get; set; }
        public string? Description { get; set; }

        //Relación n:1
        public int CurriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }
    }
}