using Learnly.Api.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Learnly.Api.Core.Models
{
    public class Lessons
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DaysWeek DayWeek { get; set; }
        public string Scheduled { get; set; }
        public Subjects Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
