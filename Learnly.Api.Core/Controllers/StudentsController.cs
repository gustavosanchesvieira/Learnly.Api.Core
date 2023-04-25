using Learnly.Api.Core.Services;

namespace Learnly.Api.Core.Controllers
{
    public class StudentsController
    {
        private StudentsService _studentsService;
        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }
    }
}
