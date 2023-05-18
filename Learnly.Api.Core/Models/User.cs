using System.ComponentModel.DataAnnotations;

namespace Learnly.Api.Core.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string RA { get; set; }
        public string Password { get; set; }
        public Students Student { get; set; }
        public int StudentId { get; set; }
    }
}
