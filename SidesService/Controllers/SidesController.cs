using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SidesService.Data;
using SidesService.Dtos;
using SidesService.Models;

namespace SidesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SidesController : ControllerBase
    {
        private readonly ISidesRepo _repository;
        private readonly IMapper _mapper;

        public SidesController(ISidesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SideReadDto>> GetAllSides(int sideEnum)
        {
            Console.WriteLine("--> Getting Sides...");

            var sides = _repository.GetAllSides();

            return Ok(_mapper.Map<IEnumerable<SideReadDto>>(sides));
        }
    }
}