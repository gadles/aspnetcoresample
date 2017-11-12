using AutoMapper;
using ContractorCore.DBContext;
using ContractorCore.Helpers;
using ContractorCore.Repositories.Implementation;
using ContractorCore.Repositories.Interfaces;
using ContractorCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ContractorWeb
{
    public class Startup
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var st = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContractorsContext>(op => op.UseSqlServer(st, b => b.MigrationsAssembly("ContractorCore")));

            services.AddMvc();
            services.AddAutoMapper();

            RegisterCustomApplicationServices(services);
        }


        private void RegisterCustomApplicationServices(IServiceCollection services)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            LogInfo.SetLogForApplication(log);
            LogInfo.LogMessage(enumLogInfoType.Info, "Api start");

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<IApiContractorConsumer, ApiContractorConsumer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
