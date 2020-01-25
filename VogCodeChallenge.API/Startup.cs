using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VogCodeChallenge.Core.Interfaces;
using VogCodeChallenge.Data;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.API
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           
            /*In response to step 7, using Environment variables, we can easily switch from in-memory database to a real Database
            Irrespective of the source (launchsettings, commandline, OS environment), we can check the applicable environment variable and determine the application logic
            as shown below. With this implementation, there is no need to update the domain/service implementation we used for data access and proccessing*/
            if (_env.IsDevelopment()) // use in-memory if running in development mode
            {
                services.AddDbContext<VogDBContext>(options => options.UseInMemoryDatabase(databaseName: "VogDB"));
            }
            else //use a Database (i.e. SQL Server) for other environment. In fact, we could determine different databases for staging and production
            {
                var connectionString = Environment.GetEnvironmentVariable("VogDB_ConnectionString");
                services.AddDbContext<VogDBContext>(options => options.UseSqlServer(connectionString));
            }

            // bind our interfaces to implementation classes
            services.AddScoped<IEmployeeManager, EmployeeManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
