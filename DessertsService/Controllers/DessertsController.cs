using System;
using System.Collections.Generic;
using AutoMapper;
using DessertsService.Data;
using DessertsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DessertsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private readonly IDessertsRepo _repository;
        private readonly IMapper _mapper;

        public DessertsController(IDessertsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DessertReadDto>> GetAllDesserts(int sideEnum)
        {
            Console.WriteLine("--> Getting Desserts...");
            
            var desserts = _repository.GetAllDesserts();

            return Ok(_mapper.Map<IEnumerable<DessertReadDto>>(desserts));
        }

    }
}