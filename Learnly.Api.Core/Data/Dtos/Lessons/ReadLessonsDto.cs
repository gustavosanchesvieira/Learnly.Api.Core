using Learnly.Api.Core.Enums;

namespace Learnly.Api.Core.Data.Dtos.Lessons
{
    public class ReadLessonsDto
    {
        public int Id { get; set; }
        public DaysWeek DayWeek { get; set; }
        public string Scheduled { get; set; }
        public string SubjectName { get; set; }
    }
}
