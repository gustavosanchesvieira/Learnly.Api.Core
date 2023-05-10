namespace Learnly.Api.Core.Data.Dtos.Abcences
{
    public class ReadAbcencesDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int AbcencesLimit { get; set; }
        public Models.Subjects Subject { get; set; }
    }
}
