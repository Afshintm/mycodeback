using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Essence.Communication.DataBaseServices;
using Microsoft.EntityFrameworkCore;

namespace Essence.Communication.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddCors();
            //set entityframework connection string
            services.AddDbContext<EventDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Essence")));
            services.AddMvc();

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
            builder.RegisterType(typeof(EventTypesManager)).As(typeof(IEventTypesManager)).SingleInstance();
            builder.RegisterGeneric(typeof(BaseBusinessServices<>)).As(typeof(IBaseBusinessService<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AuthenticationService)).As(typeof(IAuthenticationService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ReportingService)).As(typeof(IReportingService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserService)).As(typeof(IAccountService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MessageService)).As(typeof(IMessageService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventService)).As(typeof(IEventService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventCodeDetailsTypeMapper)).As(typeof(IEventCodeDetailsTypeMapper)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventDetailsCreater)).As(typeof(IEventDetailsCreater)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserAccountService)).As(typeof(IUserAccountService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UsersProfileService)).As(typeof(IUserProfileService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventBusMessageQueue)).As(typeof(IEventBus)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(MQPersistantConnection)).As(typeof(IMQPersistentConnection)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventRepository)).As(typeof(IEventRepository)).InstancePerLifetimeScope();



  

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
            app.UseMvc();
            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
   
}
