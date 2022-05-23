using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.Handlers;
using Sports.Infrastructure.DataSeed;
using Sports.Infrastructure.TennisRepository;
using Sports.Infrastructure.TennisRepository.Context;

namespace Sports.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sports.Api", Version = "v1" });
            });

            services.AddDbContext<TennisDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("TennisDbConnection")));

            services.AddScoped<IDataInitializer, DataInitialiazer>();
            services.AddScoped<ITennisRepository, TennisRepository>();
            services.AddScoped<ITennisHandler, TennisHandler>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializer dataInit)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sports.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dataInit.SeedData();
        }
    }
}
