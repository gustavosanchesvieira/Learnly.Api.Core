using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    public class StudentsController : ControllerBase
    {
        private StudentsService _studentsService;
        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }
    }
}
