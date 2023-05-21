using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Teacher;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private TeacherService _teacherService;
        private IMapper _mapper;

        public TeachersController(TeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherId(int id)
        {
            try
            {
                var teacher = _teacherService.GetById(id);
                if (teacher != null)
                {
                    return Ok(teacher);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createTeacher")]
        public IActionResult CreateTeacher([FromBody] CreateTeacherDto dto)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(dto);
                var result = _teacherService.Create(teacher);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetTeacherId), new { teacher.Id }, teacher);
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
