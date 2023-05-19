using AutoMapper;
using Learnly.Api.Core.Data.Dtos.User;
using Learnly.Api.Core.Models;
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
        
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]CreateUserDto dto)
        {
            try
            {
                var user = _mapper.Map<User>(dto);
                var result = _userService.Create(user);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetUserById), user);
                }
                return BadRequest(result.Message);
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }
    }
}
