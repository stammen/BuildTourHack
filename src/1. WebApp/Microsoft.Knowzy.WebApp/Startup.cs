using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Knowzy.Domain.Data;
using Microsoft.Knowzy.Service.DataSource.Core;
using Microsoft.Knowzy.Service.DataSource.Contracts;

namespace Microsoft.Knowzy.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<KnowzyContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("KnowzyContext"));
                });

            services.AddSingleton<IDataSourceService, DataSourceService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var knowzyContext = serviceScope.ServiceProvider.GetService<KnowzyContext>();
                    var configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                    var hostingEnvironment = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
                    knowzyContext.Database.EnsureDeleted();
                    knowzyContext.Database.Migrate();
                    DatabaseInitializer.Seed(hostingEnvironment, configuration, knowzyContext).Wait();
                }               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
