
namespace Learnly.Api.Core.Data.Dtos.Grades
{
    public class CreateGradesDto
    {
        public double FirstGrade { get; set; }
        public double SecondGrade { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }
}
