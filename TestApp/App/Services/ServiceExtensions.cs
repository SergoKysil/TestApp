using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TestApp.App.Services.Implementation;
using TestApp.App.Services.Interfaces;

namespace TestApp.App.Services
{
    public static class ServiceExtensions
    {

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICSVService, CSVService>();
        }

        public static void AddMapper(this IServiceCollection services)
        { 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper.CSVProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
