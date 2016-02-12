using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using Kitty.Api.AutofacModules;
using Kitty.Core.Domain.Handlers.Games;
using Kitty.Core.Domain.Requests.Games;
using Kitty.Core.Infrastructure;
using Kitty.Core.Infrastructure.MediatR;
using Kitty.Core.Infrastructure.Pipeline;
using Kitty.Core.Persistence;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;
using MediatR;
using Microsoft.AspNet.Identity.EntityFramework;
using Scrutor;

namespace Kitty.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Trace()
                .CreateLogger();

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<KittyContext>(options => options
                    .UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
                    .MigrationsAssembly("Kitty.Core"));
            
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<PersistenceModule>();
            
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddSerilog();

            app.UseIISPlatformHandler();

            if (env.IsDevelopment())
            {
                using (
                    var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<KittyContext>().EnsureSeedData();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc();
        }
    }
}