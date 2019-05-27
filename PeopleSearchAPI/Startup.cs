using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PeopleSearch.Repository;
using PeopleSearchAPI.Data;
using PeopleSearchData;

namespace PeopleSearchAPI
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("theDb"));
            services.AddSingleton<IValueRepository, ValueRepository>();
            services.AddSingleton<IPeopleRepository, PeopleRepository>();
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .WithOrigins("http://localhost:4200", "http://localhost:9327")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Cors");
            app.UseMvc();

            DataInitializer dataInitializer = new DataInitializer(env);
            var context = app.ApplicationServices.GetService<ApiContext>();
            dataInitializer.SeedData(context);

        }
    }
}
