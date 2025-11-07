using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        public DataSetDateTime FechaNacimiento { get; set; }
        public int edad;
    }
}
