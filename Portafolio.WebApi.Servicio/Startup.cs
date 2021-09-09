using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Portafolio.WebApi.Aplicacion.EmpleadoAplicacion;
using Portafolio.WebApi.Infraestructura.Context;
using Portafolio.WebApi.PersistenciaDatos.Repository;
using Portafolio.WebApi.Transversal.Expressions;
using Portafolio.WebApi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portafolio.WebApi.Servicio
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
            services.AddScoped<IRepository, Repository<PortafolioContext>>();

            services.AddTransient<IEmpleadoAplicacion, EmpleadoAplicacion>();

            services.AddTransient<IEmpleadoEx, EmpleadoEx>();

            services.AddDbContext<PortafolioContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MariaDB"), ServerVersion.AutoDetect(Configuration.GetConnectionString("MariaDB"))));

            services.AddAutoMapper(x => x.AddProfile(new PortafolioMapper()), typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portafolio.WebApi.Servicio", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portafolio.WebApi.Servicio v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
