using Equipment.Data.Infrastructure;
using Equipment.Data.Infrastructure.Services.Get;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Equipment.Get.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin", builder => builder.WithOrigins("http://localhost:4200", "https://localhost:44342", "http://localhost:3001").AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            //Fetching Connection string from APPSETTINGS.JSON  
            //Fetching Connection string from APPSETTINGS.JSON  
            var ConnectionString = Configuration.GetConnectionString("EquipmentDBConnection");
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IRepairMasterServices, RepairMasterService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IMasterLookupService, MasterLookupServices>();
            services.AddScoped<IEquipmentDetailByIDService, EquipmentDetailByIDService>();
            services.AddScoped<IDocumentParamIDService, DocumentsParamIDServices>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<ISubMasterService, SubMasterService>();
            services.AddScoped<ICategorylookupServices, CategoryLookUpService>();
            services.AddScoped<IConsumptionService, ConsumptionServices>();



            //Entity Framework  
            services.AddDbContext<EquipmentDbContext>(options => options.UseSqlServer(ConnectionString));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EMS Microservices", Version = "v1" }); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.WithOrigins("http://localhost:4200", "https://localhost:44342", "http://localhost:3001").AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "v1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
