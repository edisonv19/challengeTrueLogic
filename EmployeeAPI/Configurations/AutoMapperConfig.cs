using API.BusinessLogic.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(API.BusinessLogic.Mapper.AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
