using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Hackathon.Repositories;
using Hackathon.Persistance;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Hackathon
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServicesAndRepositories();
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>(
                    "Db-Check",
                    HealthStatus.Unhealthy,
                    tags: new[] {"DbCheck" }
                );
            services.AddHealthChecks()
                .AddDbContextCheck<PhotoDbContext>(
                    "Photo-Db-Check",
                    HealthStatus.Unhealthy,
                    tags: new[] { "PhotoDbCheck" }
                );
            services.AddControllers();
            services.AddCors();

            services.AddAuthentication(options => 
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer();

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddDbContext<PhotoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PhotoDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HackathonApi", Version = "v1" });
            });
            services.AddTransient<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext,PhotoDbContext photoDbContext)
        {
            dbContext.Database.Migrate();
            photoDbContext.Database.Migrate();

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HackathonApi v1"));


            app.UseHttpsRedirection();

            app.UseCors(
                builder=>builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
