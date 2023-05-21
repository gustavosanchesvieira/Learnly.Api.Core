using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Student;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private StudentsService _studentsService;
        private IMapper _mapper;
        public StudentsController(StudentsService studentsService, IMapper mapper)
        {
            _studentsService = studentsService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id) 
        {
            try
            {
                var student = _studentsService.GetById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                return NotFound();

            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createStudent")]
        public IActionResult CreateStudent([FromBody]CreateStudentDto dto) 
        {
            try
            {
                var student = _mapper.Map<Students>(dto);
                var result = _studentsService.Create(student);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetStudentById), new { student.Id }, student);
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
