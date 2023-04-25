using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class SubjectsService
    {
        private DbContext _dbContext;
        private IMapper _mapper;

        public SubjectsService(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
