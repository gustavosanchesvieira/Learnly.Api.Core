using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Abcences;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class AbcencesProfile : Profile
    {
        public AbcencesProfile()
        {
            CreateMap<Abcences, ReadAbcencesDto>().
                ForMember(x => x.SubjectName, y => y.MapFrom(z => z.Subject.Name)).
                ForMember(x => x.Frequency, y => y.MapFrom(z => 100 - ( (25*z.Amount) / z.Subject.AbcencesLimit )));
            CreateMap<CreateAbcenceDto, Abcences>();
        }
    }
}
