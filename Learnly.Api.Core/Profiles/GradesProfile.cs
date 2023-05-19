using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Grades;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class GradesProfile : Profile
    {
        public GradesProfile()
        {
            CreateMap<Grades, ReadGradesDto>().
                ForMember(x => x.SubjectName, y => y.MapFrom(z => z.Subject.Name));
            CreateMap<CreateGradesDto, Grades>().
                ForMember(x => x.Average, y => y.MapFrom(z => (z.FirstGrade + z.SecondGrade) / 2));
        }
    }
}
