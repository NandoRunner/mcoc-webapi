﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
    using WebApi.Business;
    using WebApi.Business.Implementattions;
    using WebApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi
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
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));
            services.AddMvc();

            services.AddApiVersioning();

            //Dependency Injection
            services.AddScoped<IActorBusiness, ActorBusinessImpl>();
            services.AddScoped<IActorMovieBusiness, ActorMovieBusinessImpl>();
            services.AddScoped<IGenreBusiness, GenreBusinessImpl>();
            services.AddScoped<IDirectorBusiness, DirectorBusinessImpl>();
            services.AddScoped<IMovieBusiness, MovieBusinessImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
