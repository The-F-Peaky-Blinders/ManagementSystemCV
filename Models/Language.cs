namespace managementcv.Models
{
    public class Language

    {
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? FluencyLevel { get; set; }

        //Relación n:1
        public int CurriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }
    }
}