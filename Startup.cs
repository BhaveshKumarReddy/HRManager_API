using HRM_API.Models;
using HRM_API.Repository;
using HRM_API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM_API
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
            services.AddControllers();

            services.AddTransient<IHrListRepo<HrList>, HrListRepo>();
            services.AddTransient<IHrListService<HrList>, HrListService>();

            services.AddTransient<IEmployeesListRepo<EmployeesList>, EmployeesListRepo>();
            services.AddTransient<IEmployeeListService<EmployeesList>, EmployeesListService>();

            services.AddTransient<ILocationListRepo<LocationList>, LocationListRepo>();
            services.AddTransient<ILocationListService<LocationList>, LocationListService>();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<HRM_DB_ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRM_API", Version = "v1" });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRM_API v1"));
            }

            loggerFactory.AddLog4Net();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
