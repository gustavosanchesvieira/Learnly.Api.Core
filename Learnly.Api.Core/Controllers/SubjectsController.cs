using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    public class SubjectsController : ControllerBase
    {
        private SubjectsService _subjectsService;
        public SubjectsController(SubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }
    }
}
