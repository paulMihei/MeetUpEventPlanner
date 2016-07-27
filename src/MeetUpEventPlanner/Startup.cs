using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MeetUpEventPlanner.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MeetUpEventPlanner.Services;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MeetUpEventPlanner
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(env.ContentRootPath)
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework()
                    .AddDbContext<MeetUpEventPlannerDbContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<MeetUpEventPlannerDbContext>();

            services.AddScoped<IMeetUpEventData, MeetUpEventData>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment appEnvironment)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseDatabaseErrorPage();
            app.UseFileServer();
            app.UseNodeModules(appEnvironment);
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
