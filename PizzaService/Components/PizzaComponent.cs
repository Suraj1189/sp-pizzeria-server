using System.Collections.Generic;
using AutoMapper;
using PizzaService.Data;
using PizzaService.Dtos;

namespace PizzaService.Components
{
    public class PizzaComponent : IPizzaComponent
    {
        private readonly IPizzaRepo _repository;

        public IMapper _mapper { get; }

        public PizzaComponent(IPizzaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<PizzaReadDto> GetAllPizzas()
        {
            var pizzas = _repository.GetAllPizzas();
            return _mapper.Map<IEnumerable<PizzaReadDto>>(pizzas);
        }
    }
}