using System;
using System.Collections.Generic;
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
using WebApi.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using WebApi.HyperMedia;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WebApi.Security.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using McocApi.Util;
using System.IO;

namespace WebApi
{
    public class Startup
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment, Microsoft.Extensions.Logging.ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;

            NLog.LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = _configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS 
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            //Connection to database
            var strconn = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(strconn));

            //Adding Migrations Support
            ExecuteMigrations(strconn);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            //todo: testar addScoped
            services.AddSingleton<ILog, LogNLog>();

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //Content negociation - Support to XML and JSON
            services.AddMvc(options =>
            {
                //options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.EnableEndpointRouting = false;

            })
            .AddXmlSerializerFormatters();

            //HATEOAS filter definitions
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new AbilityEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new AllianceEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new HashtagEnricher());
            //filterOptions.ObjectContentResponseEnricherList.Add(new HeroeEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new SynergyEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new UserEnricher());

            //Service inject
            services.AddSingleton(filterOptions);

            //Versioning
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Add Swagger Service
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Mcoc Library",
                        Version = "v1"
                    });
            });

            //Dependency Injection
            services.AddScoped<IAbilityBusiness, AbilityBusinessImpl>();
            services.AddScoped<IAllianceBusiness, AllianceBusinessImpl>();
            services.AddScoped<IHashtagBusiness, HashtagBusinessImpl>();
            services.AddScoped<IHeroeBusiness, HeroeBusinessImpl>();
            services.AddScoped<IHeroeAbilityBusiness, HeroeAbilityBusinessImpl>();
            services.AddScoped<IHeroeHashtagBusiness, HeroeHashtagBusinessImpl>();
			services.AddScoped<ISynergyBusiness, SynergyBusinessImpl>();
            services.AddScoped<IUserBusiness, UserBusinessImpl>();
            services.AddScoped<IUserAllianceBusiness, UserAllianceBusinessImpl>();
            services.AddScoped<IUserHeroeBusiness, UserHeroeBusinessImpl>();
            services.AddScoped<IFileRenamerBusiness, FileRenamerBusinessImpl>();
            services.AddScoped<ILoginBusiness, LoginBusinessImpl>();
            services.AddScoped<IFileBusiness, FileBusinessImpl>();

            //Dependency Injection of GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRepositoryId<>), typeof(GenericRepositoryId<>));
            services.AddScoped(typeof(IRepositoryInter<,,>), typeof(GenericRepositoryInter<,,>));

//            services.AddScoped(typeof(IRepositoryInter<BaseInterEntity, BaseEntity, BaseEntity>), typeof(GenericRepositoryInter<BaseInterEntity, BaseEntity, BaseEntity>));

            services.AddScoped<IWebUserRepository, WebUserRepositoryImpl>();
            services.AddScoped(typeof(IViewRepository<>), typeof(ViewRepositoryImpl<>));
        }

        private void ExecuteMigrations(string strconn)
        {
            if (_environment.IsDevelopment())
            {
                try
                {
                    //var devconn = _configuration["MySqlConnection:MySqlConnectionString"];
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(strconn);
                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            LoggerFactory.Create(builder =>
            {
                builder.AddConfiguration(_configuration.GetSection("Logging"));
                builder.AddDebug();
            });

            //Enable Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
#if !DEBUG
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mcoc Library API v1");
#else
                   // To deploy on IIS
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Mcoc Library API v1");
#endif
            });

            //Starting our API in Swagger page
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            //Adding map routing
            app.UseMvc(routes =>
			{
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });
        }
    }
}
