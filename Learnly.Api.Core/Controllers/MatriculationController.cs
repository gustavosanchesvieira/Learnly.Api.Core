using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Matriculations;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatriculationController : ControllerBase
    {
        private MatriculationService _matriculationService;
        private IMapper _mapper;

        public MatriculationController(MatriculationService matriculationService, IMapper mapper)
        {
            _matriculationService = matriculationService;
            _mapper = mapper;
        }

        [HttpGet("getMatriculation")]
        public IActionResult GetMatriculation([FromQuery]int studentId, [FromQuery] int subjectId)
        {
            try
            {
                var matriculations = _matriculationService.Get();
                if (matriculations != null)
                {
                    var matriculation = matriculations.FirstOrDefault(x => x.StudentId == studentId && x.SubjectId == subjectId);
                    if (matriculation != null)
                    {
                        return Ok(matriculation);
                    }
                }
                return NotFound();  
            }
            catch (Exception f)
            {
                return BadRequest(f.Message);
            }
        }

        [HttpPost("createMatriculation")]
        public IActionResult createMatriculation([FromBody]CreateMatriculationsDto dto)
        {
            try
            {
                var matriculation = _mapper.Map<Matriculation>(dto);
                var result = _matriculationService.Create(matriculation);
                if (result.Sucess)
                {
                    return CreatedAtAction(nameof(GetMatriculation), matriculation);
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
