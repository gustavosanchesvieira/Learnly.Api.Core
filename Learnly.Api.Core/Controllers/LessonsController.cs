using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Lessons;
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

        [HttpGet("getGridSchedules")]
        public IActionResult GetGridSchedules([FromQuery] int studentId)
        {
            try
            {
                var lessons = _lessonsService.Get();
                if (lessons != null)
                {
                    /*
                     SELECT *
'                       FROM lessons a
'                       INNER JOIN subjects b ON a.SubjectId = b.Id
'                       INNER JOIN matriculations c ON c.SubjectId = b.Id
'                       WHERE c.StudentId IN ()
                     */
                    var lessonsGrid = _mapper.Map<List<ReadLessonsDto>>(lessons);
                    return Ok(lessonsGrid);
                }
                return NotFound();

            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

    }
}
