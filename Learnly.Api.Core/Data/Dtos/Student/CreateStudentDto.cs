namespace Learnly.Api.Core.Data.Dtos.Student
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
