using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Subjects;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class SubjectsProfile : Profile
    {
        public SubjectsProfile()
        {
            CreateMap<CreateSubjectsDto, Subjects>();
            CreateMap<Subjects, ReadSubjectsDto>();
            CreateMap<UpdateSubjectsDto, Subjects>();
        }
    }
}
