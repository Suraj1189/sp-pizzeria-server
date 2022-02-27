using System;
using System.Collections.Generic;
using AutoMapper;
using BeveragesService.Data;
using BeveragesService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BeveragesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly IBeveragesRepo _repository;
        private readonly IMapper _mapper;

        public BeveragesController(IBeveragesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BeverageReadDto>> GetAllBeverages(int sidesEnum)
        {
            Console.WriteLine("--> Getting Beverages...");

            var beverages = _repository.GetAllBeverages();

            return Ok(_mapper.Map<IEnumerable<BeverageReadDto>>(beverages));
        }
    }
}