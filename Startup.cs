using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace CommandAPI
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration) => Configuration = configuration;
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommandContext>
                (opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          app.UseMvc();
          app.UseSwagger();

          app.UseSwaggerUI(c =>
          {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommandAPI");
            });
        }
    }
}
