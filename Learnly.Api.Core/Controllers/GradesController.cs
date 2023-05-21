using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Grades;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradesController : ControllerBase
    {
        private GradesService _gradesService;
        private IMapper _mapper;

        public GradesController(GradesService gradesService, IMapper mapper)
        {
            _gradesService = gradesService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetGradeById(int id)
        {
            try
            {
                var grade = _gradesService.GetById(id);
                if (grade != null)
                {
                    return Ok(grade);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpGet("getGridGrades")]
        public IActionResult GetGridGrades([FromQuery] int studentId)
        {
            try
            {
                var grades = _gradesService.Get();
                if (grades != null && grades.Any())
                {
                    grades = grades.Where(x => x.StudentId == studentId).ToList();
                    var gradesGrid = _mapper.Map<List<ReadGradesDto>>(grades);
                    return Ok(gradesGrid);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createGrade")]
        public IActionResult CreateGrade([FromBody]CreateGradesDto dto)
        {
            try
            {
                var grade = _mapper.Map<Grades>(dto);
                var result = _gradesService.Create(grade);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetGradeById), new { grade.Id }, grade);
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
