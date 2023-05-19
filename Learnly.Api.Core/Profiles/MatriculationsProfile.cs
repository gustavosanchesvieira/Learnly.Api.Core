using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Matriculations;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class MatriculationsProfile : Profile
    {
        public MatriculationsProfile()
        {
            CreateMap<CreateMatriculationsDto, Matriculation>();
        }
    }
}
