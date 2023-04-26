using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Students;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<CreateStudentsDto, Students>();
            CreateMap<Students, ReadStudentsDto>();
            CreateMap<UpdateStudentsDto, Students>();
        }
    }
}
