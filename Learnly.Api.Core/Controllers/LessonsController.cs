﻿using AutoMapper;
using Learnly.Api.Core.Data.Dtos.Lessons;
using Learnly.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learnly.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private LessonsService _lessonsService;
        private IMapper _mapper;

        public LessonsController(LessonsService lessonsService, IMapper mapper)
        {
            _lessonsService = lessonsService;
            _mapper = mapper;
        }

        [HttpGet("getGridSchedules")]
        public IActionResult GetGridSchedules()
        {
            try
            {
                var lessons = _lessonsService.Get();
                if (lessons != null)
                {
                    var lessonsGrid = _mapper.Map<List<ReadLessonsDto>>(lessons);
                    return Ok(lessonsGrid);
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
