using System.ComponentModel.DataAnnotations;

namespace Learnly.Api.Core.Models
{
    public class Subjects
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}
