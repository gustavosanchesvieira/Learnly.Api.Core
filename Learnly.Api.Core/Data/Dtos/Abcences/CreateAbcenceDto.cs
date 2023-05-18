namespace Learnly.Api.Core.Data.Dtos.Abcences
{
    public class CreateAbcenceDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Amount { get; set; }
    }
}
