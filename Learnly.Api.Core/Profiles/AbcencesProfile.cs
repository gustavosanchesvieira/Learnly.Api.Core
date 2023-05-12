using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Abcences;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class AbcencesProfile : Profile
    {
        public AbcencesProfile()
        {
            CreateMap<CreateAbcencesDto, Abcences>();
            CreateMap<Abcences, ReadAbcencesDto>().
                ForMember(x => x.SubjectName, y => y.MapFrom(z => z.Subject.Name));
            CreateMap<UpdateAbcencesDto, Abcences>();
        }
    }
}
