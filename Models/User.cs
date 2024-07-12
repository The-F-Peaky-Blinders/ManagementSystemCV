namespace managementcv.Models
{
    public class User
    {
        public int UserId {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string? Email {get; set;}
        public string? Password {get; set;}
        public DateOnly Birthdate {get; set;}
        public string? TelephonePrefixes {get; set;}
        public string? PhoneNumber {get; set;}
        public string? PictureUrl {get; set;}
        public string? City {get; set;}

        //Relación 1:1 padre
        public Curriculum? Curriculum {get; set;}

    }
}