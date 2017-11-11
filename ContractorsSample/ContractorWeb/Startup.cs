using AutoMapper;
using ContractorCore.DBContext;
using ContractorCore.Repositories.Implementation;
using ContractorCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContractorWeb
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
            var st = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContractorsContext>(op => op.UseSqlServer(st, b => b.MigrationsAssembly("ContractorCore")));

            services.AddMvc();
            services.AddAutoMapper();

            RegisterCustomApplicationServices(services);
        }


        private void RegisterCustomApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IContractorRepository, ContractorRepository>();
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
