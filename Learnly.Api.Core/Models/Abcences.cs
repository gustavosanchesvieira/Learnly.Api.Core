namespace Learnly.Api.Core.Models
{
    public class Abcences
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int AbcencesLimit { get; set; }
        public Subjects Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
