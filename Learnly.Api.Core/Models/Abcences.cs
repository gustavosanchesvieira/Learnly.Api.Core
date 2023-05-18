using System.ComponentModel.DataAnnotations;

namespace Learnly.Api.Core.Models
{
    public class Abcences
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Amount { get; set; }
        public Subjects Subject { get; set; }
        public int SubjectId { get; set; }
        public Students Student { get; set; }
        public int StudentId { get; set; }
    }
}
