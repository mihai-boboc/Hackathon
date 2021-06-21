using Hackathon.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Hackathon.Services;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Persistance.AutoMapper;
using Hackathon.Repositories;

namespace Hackathon.Persistance
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesAndRepositories(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DepartmentsMapper));

            services.AddTransient<IDepartamentRepository,DepartmentsRepository>();
            services.AddTransient<IDepartamentService,DepartamentsService>();

            services.AddTransient<IStatusRepository,StatusRepository>();
            services.AddTransient<IStatusService,StatusService>();

            services.AddTransient<IPinTypesRepository, PinTypesRepository>();
            services.AddTransient<IPinTypesService, PinTypesService>();
        }       
    }
}
