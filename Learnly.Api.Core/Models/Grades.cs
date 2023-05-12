using System.ComponentModel.DataAnnotations;

namespace Learnly.Api.Core.Models
{
    public class Grades
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double FirstGrade { get; set; }
        public double SecondGrade { get; set; }
        public double Average { get; set; }
        public Subjects Subject { get; set; }
        public int SubjectId { get; set; }
        public Students Student { get; set; }
        public int StudentId { get; set; }
    }
}
