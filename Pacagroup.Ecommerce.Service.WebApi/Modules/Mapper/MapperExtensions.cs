
using AutoMapper;

using Pacagroup.Ecommerce.Transversal.Mapper;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            MapperConfiguration mappingConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MappingsProfile()));

            IMapper mapper = mappingConfiguration.CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            return services;
        }
    }
}
