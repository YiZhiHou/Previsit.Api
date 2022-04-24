using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Prometheus;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Previsit.Api
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
            var assemblyVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            //#region Route

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();


            //#endregion Route

            #region Swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Previsit API"
                });
                options.OrderActionsBy(o => o.RelativePath);
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                {
                    options.IncludeXmlComments(file, true);
                });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");

            });

            #endregion Swagger


            services.AddDbContext<PrevisitDbContext>(option =>
            {
                option.UseNpgsql(Configuration["Db:ExampleDb:ConnectionString"]);
            });


            #region IOC
            services.AddSingleton(Configuration);

            services.AddScoped<IPatientAccountInfoRepository, PatientAccountInfoRepository>();
            services.AddScoped<IPatientAccountInfoBll, PatientAccountInfoBll>();

            services.AddScoped<IPatientInfoRepository, PatientInfoRepository>();
            services.AddScoped<IPatientInfoBll, PatientInfoBll>();

            services.AddScoped<IFormRecordRepository, FormRecordRepository>();
            services.AddScoped<IFormRecordBll, FormRecordBll>();
            #endregion 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Previsit API V1");
            });

            app.UseHttpMetrics();
            app.UseMetricServer();

            app.UseCors("default");

            app.UseRouting();

            //  请放置在 routing和Endpoints之间
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics();
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
        }
    }
}
