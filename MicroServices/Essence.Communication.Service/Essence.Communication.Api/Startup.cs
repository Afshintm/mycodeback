using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Services.Utils;
using Essence.Communication.BusinessServices;
using BuildingBlocks.EventBus.MessageQueue;
using BuildingBlocks.EventBus.Interfaces;
using BuildingBlocks.EventBus.MessageQueue.Interfaces;
using Microsoft.EntityFrameworkCore;
using Essence.Communication.Models.Utility;
using Services.Utilities.DataAccess;
using Essence.Communication.DbContexts;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using System.IO;

namespace Essence.Communication.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration,ILogger<Startup> logger)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();
            //this.Configuration = builder.Build();
            Configuration = configuration;
            HostingEnvironment = env;
            _logger = logger;
        }
        public ILogger<Startup> _logger;
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddCors();
            //set entityframework connection string
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ApplicationConnectionString"), b => b.MigrationsAssembly("Essence.Communication.DbContexts")));
            services.AddDbContext<ApplicationIdentityDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ApplicationConnectionString"), b => b.MigrationsAssembly("Essence.Communication.DbContexts")));

            services.AddMvc();

            //add swagger service
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "HomeStay API", Version = "v1" });
                    
                    var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                    var name = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(basePath, name);
                    c.IncludeXmlComments(xmlPath);
                });
            
            services.AddAuthorization();
            var IdentityServerIssuerUrl = Configuration.GetSection("AuthenticationServer")["Issuer"];
            var apiName = Configuration.GetSection("AuthenticationServer")["ApiKey"];
            _logger.LogInformation("Identity Server configuration data is {0}available.",( string.IsNullOrEmpty(IdentityServerIssuerUrl)||string.IsNullOrEmpty(IdentityServerIssuerUrl)?"not":string.Empty ));
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = IdentityServerIssuerUrl;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = apiName;
                });
            

            var builder = AppContainerBuilder(services);
            //var builder = services.GetAppContainerBuilder();

            this.ApplicationContainer = builder.Build();

           
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private static ContainerBuilder AppContainerBuilder(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            builder.RegisterType<HttpClientManager>().As<IHttpClientManager>().SingleInstance();
            builder.RegisterType(typeof(AppSettingsConfigService)).As(typeof(IAppSettingsConfigService)).SingleInstance();
            builder.RegisterType(typeof(VendorEventCodeDetailsMapper)).As(typeof(IVendorEventCodeDetailsMapper)).SingleInstance();
            builder.RegisterType(typeof(VendorEventList)).As(typeof(IVendorEventList)).SingleInstance();
            builder.RegisterType(typeof(EmergencyRules)).As(typeof(IEventEmergencyRules)).SingleInstance();
            builder.RegisterType(typeof(HttpClientManagerNew)).As(typeof(IHttpClientManagerNew)).SingleInstance();

            builder.RegisterType(typeof(ModelMapper)).As(typeof(IModelMapper)).SingleInstance();
            builder.RegisterGeneric(typeof(BaseBusinessServices<>)).As(typeof(IBaseBusinessService<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AuthenticationService)).As(typeof(IAuthenticationService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ReportingService)).As(typeof(IReportingService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserService)).As(typeof(IAccountService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MessageService)).As(typeof(IMessageService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventService)).As(typeof(IEventService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventCreater)).As(typeof(IEventCreater)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserAccountService)).As(typeof(IUserAccountService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UsersProfileService)).As(typeof(IUserProfileService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventBusMessageQueue)).As(typeof(IEventBus)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MQPersistantConnection)).As(typeof(IMQPersistentConnection)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MQPersistantConnection)).As(typeof(IMQPersistentConnection)).InstancePerLifetimeScope();          
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency();
            builder.RegisterType<EssenceRequestValidation>().As<IRequestValidation>().InstancePerDependency();



            return builder;
        }
        
        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
          IApplicationBuilder app,
          ILoggerFactory loggerFactory,
          IApplicationLifetime appLifetime, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }


            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseMvc();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeStayIntelligent API V1");
            });
            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
   
}
