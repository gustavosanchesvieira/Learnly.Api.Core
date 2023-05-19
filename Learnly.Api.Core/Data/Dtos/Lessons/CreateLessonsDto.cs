using Learnly.Api.Core.Enums;

namespace Learnly.Api.Core.Data.Dtos.Lessons
{
    public class CreateLessonsDto
    {
        public DaysWeek DayWeek { get; set; }
        public string Scheduled { get; set; }
        public int SubjectId { get; set; }
    }
}
