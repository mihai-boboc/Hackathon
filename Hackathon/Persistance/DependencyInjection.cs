using Hackathon.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Hackathon.Services;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using AutoMapper;
using Hackathon.Persistance.AutoMapper;

namespace Hackathon.Persistance
{
    public static class DependencyInjection
    {
        public static void ConfigureServicesAndRepositories(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DepartmentsMapper));
            services.AddTransient<IDepartamentRepository,DepartmentsRepository>();
            services.AddTransient<IDepartamentService,DepartamentsService>();
        }       
    }
}
