using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Abcences;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AbcencesController : ControllerBase
    {
        private AbcencesService _abcencesService;
        private IMapper _mapper;

        public AbcencesController(AbcencesService abcencesService, IMapper mapper)
        {
            _abcencesService = abcencesService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAbcenceById(int id)
        {
            try
            {
                var abcence = _abcencesService.GetById(id);
                if (abcence != null)
                {
                    return Ok(abcence);
                }
                return NotFound();
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpGet("getGridAbcences")]
        public IActionResult GetGridAbcences([FromQuery] int studentId)
        {
            try
            {
                var abcences = _abcencesService.Get();
                if (abcences != null)
                {
                    abcences = abcences.Where(x => x.StudentId == studentId).ToList();
                    var abcencesGrid = _mapper.Map<List<ReadAbcencesDto>>(abcences);
                    return Ok(abcencesGrid);
                }
                return NotFound();

            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createAbcence")]
        public IActionResult CreateAbscence([FromBody] CreateAbcenceDto dto)
        {
            try
            {
                var abcence = _mapper.Map<Abcences>(dto);
                var result = _abcencesService.Create(abcence);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetAbcenceById), abcence);
                }
                return BadRequest(result.Message);
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("updateAbcence")]
        public IActionResult UpdateAbcence([FromBody]CreateAbcenceDto dto)
        {
            try
            {
                var abcence = _abcencesService.GetAbcenceSubjectByStudent(dto.StudentId, dto.SubjectId);
                if (abcence == null)
                {
                    return BadRequest("Registro de falta não encontrado");
                }

                abcence = _mapper.Map(dto, abcence);
                var result = _abcencesService.Update(abcence);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetAbcenceById), abcence);
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
