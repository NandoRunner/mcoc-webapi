using System;
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
using WebApi.Repository;
using WebApi.Repository.Implementattions;
using WebApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using Evolve.Migration;
using WebApi.Repository.Generic;
using Microsoft.Net.Http.Headers;

namespace WebApi
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var strconn = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(strconn));

            if (_environment.IsDevelopment())
            {
                try
                {
                    //var devconn = _configuration["MySqlConnection:MySqlConnectionString"];
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(strconn);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }


            //services.AddMvc();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Dependency Injection
            services.AddScoped<IActorBusiness, ActorBusinessImpl>();
            services.AddScoped<IGenreBusiness, GenreBusinessImpl>();
            services.AddScoped<IDirectorBusiness, DirectorBusinessImpl>();

            services.AddScoped<IMccAllianceBusiness, MccAllianceBusinessImpl>();
            services.AddScoped<IMccHeroeBusiness, MccHeroeBusinessImpl>();
            services.AddScoped<IMccSynergyBusiness, MccSynergyBusinessImpl>();
            services.AddScoped<IMccUserBusiness, MccUserBusinessImpl>();
            services.AddScoped<IMccUserAllianceBusiness, MccUserAllianceBusinessImpl>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRepositoryInter<>), typeof(GenericRepositoryInter<>));


            services.AddScoped(typeof(IViewRepository<>), typeof(ViewRepositoryImpl<>));

            services.AddScoped<IMovieBusiness, MovieBusinessImpl>();
            services.AddScoped<IMovieRepository, MovieRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
