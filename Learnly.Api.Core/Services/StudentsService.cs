using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class StudentsService
    {
        private DbContext _dbContext;
        private IMapper _mapper;

        public StudentsService(DbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}
