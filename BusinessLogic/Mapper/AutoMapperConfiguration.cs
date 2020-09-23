using API.BusinessLogic.Mapper.Profiles;
using AutoMapper;

namespace API.BusinessLogic.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeeProfile());
            });
        }
    }
}
