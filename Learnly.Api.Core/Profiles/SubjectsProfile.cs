using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Subject;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class SubjectsProfile : Profile
    {
        public SubjectsProfile()
        {
            CreateMap<Subjects, ReadSubjectDto>();
            CreateMap<CreateSubjectDto, Subjects>();
        }
    }
}
