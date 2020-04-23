using BuildingCondition.Db.Context;
using BuildingCondition.Interfaces;
using BuildingCondition.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingCondition.Mvc
{
    public class Startup
    {
        protected IConfigurationRoot Configuration;

        public Startup()
        {
            Configuration = new ConfigurationBuilder().AddXmlFile("appsettings.xml").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BuildingConditionContext>(builder =>
            {
                builder.UseSqlServer(Configuration["DefaultConnection"]);
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BuildingConditionContext>();

            services.AddScoped<IApartmentElectricalInstalationReportService, ApartmentElectricalInstalationReportService>();
            
            services.AddScoped<IApartmentGasInstalationReportService, ApartmentGasInstalationReportService>();
            
            services.AddScoped<IApartmentService, ApartmentService>();
            
            services.AddScoped<IBuildingElectricalInstalationReportService, BuildingElectricalInstalationReportService>();
            
            services.AddScoped<IBuildingGasInstalationReportService, BuildingGasInstalationReportService>();
            
            services.AddScoped<IBuildingManagerService, BuildingManagerService>();
            
            services.AddScoped<IBuildingService, BuildingService>();
            
            services.AddScoped<IElectricalInstallationParametersMeterService, ElectricalInstallationParametersMeterService>();

            services.AddScoped<IElectricalQualificationCertificateService, ElectricalQualificationCertificateService>();

            services.AddScoped<IGasDetectorService, GasDetectorService>();
            
            services.AddScoped<IGasQualificationCertificateService, GasQualificationCertificateService>();
            
            services.AddScoped<IUserService, UserService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
