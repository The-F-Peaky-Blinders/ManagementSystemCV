using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystemCV.Models
{
  public class User
  {
      public int UserId { get; set; }

      [Required]
      public string? FirstName { get; set; }

      [Required]
      public string? LastName { get; set; }

      [Required, EmailAddress]
      public string? Email { get; set; }
      [Required]
      public string? Password { get; set; }

      [Required]
      public DateTime Birthdate { get; set; }

      [Required]
      public string? TelephonePrefixes { get; set; }

      [Required]
      public string? PhoneNumber { get; set; }

      [Required]
      public string? PictureUrl { get; set; }

      [Required]
      public string? City { get; set; }

      public Curriculum? Curriculum { get; set; }
  }
}
