using AutoMapper;
using Learnly.Api.Core.Data.Dtos.User;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]CreateUserDto createUserDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }
    }
}
