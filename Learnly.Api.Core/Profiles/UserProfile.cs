using AutoMapper;
using Learnly.Api.Core.Data.Dtos.User;
using Learnly.Api.Core.Models;

namespace Learnly.Api.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();   
        }
    }
}
