namespace Learnly.Api.Core.Models
{
    public class Matriculation
    {
        public Students Student { get; set; }
        public int StudentId { get; set; }
        public Subjects Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
