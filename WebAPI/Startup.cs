using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Implementations;
using BusinessLogic.Contracts;
using BusinessLogic.Implementations;
using static BusinessLogic.Contracts.IBookServices;
using static BusinessLogic.Contracts.IVisitorServices;

namespace WebAPI
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
            // Mapper
            services.AddAutoMapper(typeof(Startup));

            // DataAccess
            services.AddDbContext<BooksAppContext>();
            services.Add(new ServiceDescriptor(typeof(IVisitorDataAccess), typeof(VisitorDataAccess), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookDataAccess), typeof(BookDataAccess), ServiceLifetime.Scoped));

            // Visitor Services BLL
            services.Add(new ServiceDescriptor(typeof(IVisitorCreateService), typeof(VisitorService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IVisitorGetService), typeof(VisitorService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IVisitorUpdateService), typeof(VisitorService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IVisitorDeleteService), typeof(VisitorService), ServiceLifetime.Scoped));

            // Book Services BLL
            services.Add(new ServiceDescriptor(typeof(IBookCreateService), typeof(BookService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookGetService), typeof(BookService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookUpdateService), typeof(BookService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookDeleteService), typeof(BookService), ServiceLifetime.Scoped));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
