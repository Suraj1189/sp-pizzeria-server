using AutoMapper;

namespace PizzaService.UT
{
    public class BaseUnitTest 
    {
        private IMapper mapper;
        public BaseUnitTest()
        {

        }
        public IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new PizzaService.Profiles.PizzaProfiles());
                    });
                    mapper = mappingConfig.CreateMapper();
                }
                return mapper;
            }
        }
    }
}