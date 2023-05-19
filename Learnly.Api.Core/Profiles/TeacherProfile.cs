using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Teacher;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
        }
    }
}
