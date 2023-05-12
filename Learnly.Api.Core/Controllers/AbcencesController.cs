using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Abcences;
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

        [HttpGet("getGridAbcences")]
        public IActionResult GetGridAbcences()
        {
            try
            {
                var abcences = _abcencesService.Get();
                if (abcences != null)
                {
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
    }
}
