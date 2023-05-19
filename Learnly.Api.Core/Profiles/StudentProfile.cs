using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Student;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDto, Students>();
        }
    }
}
