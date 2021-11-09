using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using LiverpoolStatsApi.Models;
using LiverpoolStatsApi.Services;


namespace LiverpoolStatsApi
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

            services.Configure<LiverpoolStatsDatabaseSettings>(
                Configuration.GetSection(nameof(LiverpoolStatsDatabaseSettings))
            );

            services.AddSingleton<ILiverpoolStatsDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<LiverpoolStatsDatabaseSettings>>().Value
            );

            services.AddSingleton<PlayerService>();
            // Handling CORS
            services.AddCors(
                options => {
                    options.AddPolicy("AllowAny",
                        builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
                }
            );


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiverpoolStatsApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiverpoolStatsApi v1"));
            }

            // Setting the default site of the webapi
            // TODO: ?????
            // DefaultFilesOptions newOptions = new DefaultFilesOptions();
            // newOptions.DefaultFileNames.Append("index.html");
            // app.UseDefaultFiles(newOptions);


            app.UseCors("AllowAny");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
