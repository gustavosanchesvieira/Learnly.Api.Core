using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Lessons;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class LessonsProfile : Profile
    {
        public LessonsProfile()
        {
            CreateMap<Lessons, ReadLessonsDto>().
                ForMember(x => x.SubjectName, y => y.MapFrom(z => z.Subject.Name));
            CreateMap<CreateLessonsDto, Lessons>();
        }
    }
}
