using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Lessons;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private LessonsService _lessonsService;
        private IMapper _mapper;

        public LessonsController(LessonsService lessonsService, IMapper mapper)
        {
            _lessonsService = lessonsService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            try
            {
                var lesson = _lessonsService.GetById(id);
                if (lesson != null)
                {
                    return Ok(lesson);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }


        [HttpGet("getGridSchedules")]
        public IActionResult GetGridSchedules([FromQuery] int studentId)
        {
            try
            {
                var scheduledLessons = _lessonsService.GetScheduledLessonsByStudent(studentId);
                if (scheduledLessons != null)
                {
                    return Ok(scheduledLessons);
                }
                return NotFound();

            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createLesson")]
        public IActionResult CreateLesson([FromBody]CreateLessonsDto dto)
        {
            try
            {
                var lesson = _mapper.Map<Lessons>(dto);
                var result = _lessonsService.Create(lesson);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetLessonById), lesson);
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
