using AutoMapper;
using Learnly.Api.Core.Data.Dtos.User;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>().
                ForMember(x => x.RA, y => y.MapFrom(z => z.StudentId.ToString("D6"))); 
        }
    }
}
