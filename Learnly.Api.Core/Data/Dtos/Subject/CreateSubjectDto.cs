namespace Learnly.Api.Core.Data.Dtos.Subject
{
    public class CreateSubjectDto
    {
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public int AbcencesLimit { get; set; }
        public int TeacherId { get; set; }
    }
}
