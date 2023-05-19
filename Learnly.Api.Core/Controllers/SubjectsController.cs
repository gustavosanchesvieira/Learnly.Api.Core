using AutoMapper;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    public class SubjectsController : ControllerBase
    {
        private SubjectsService _subjectsService;
        private IMapper _mapper;
        public SubjectsController(SubjectsService subjectsService, IMapper mapper)
        {
            _subjectsService = subjectsService;
            _mapper = mapper;
        }

    }
}
