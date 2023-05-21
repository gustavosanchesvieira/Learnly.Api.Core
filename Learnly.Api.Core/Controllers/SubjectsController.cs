using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Subject;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private SubjectsService _subjectsService;
        private IMapper _mapper;
        public SubjectsController(SubjectsService subjectsService, IMapper mapper)
        {
            _subjectsService = subjectsService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            try
            {
                var subject = _subjectsService.GetById(id);
                if (subject != null)
                {
                    return Ok(subject);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpGet("getGridSubjects")]
        public IActionResult GetGridSubjects([FromQuery] int studentId)
        {
            try
            {
                var studentSubjects = _subjectsService.GetSubjectsByStudent(studentId);
                if (studentSubjects != null && studentSubjects.Any())
                {
                    return Ok(studentSubjects);
                }

                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createSubject")]
        public IActionResult CreateSubject([FromBody] CreateSubjectDto dto)
        {
            try
            {
                var subject = _mapper.Map<Subjects>(dto);
                var result = _subjectsService.Create(subject);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetSubjectById), new { subject.Id }, subject);
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
