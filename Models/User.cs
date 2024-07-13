using System;
using System.ComponentModel.DataAnnotations;

namespace managementcv.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
 

        [Required]
        public DateTime Birthdate { get; set; }

        public string? TelephonePrefixes { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PictureUrl { get; set; }
        public string? City { get; set; }

        // Relación 1:1 con Curriculum
        public Curriculum? Curriculum { get; set; }
    }
}
