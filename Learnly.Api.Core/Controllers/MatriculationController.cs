using AutoMapper;
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

    }
}
