namespace Learnly.Api.Core.Data.Dtos.Grades
{
    public class ReadGradesDto
    {
        public int Id { get; set; }
        public double FirstGrade { get; set; }
        public double SecondGrade { get; set; }
        public double Average { get; set; }
        public string SubjectName { get; set; }
    }
}
