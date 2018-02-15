using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssetGuard.Data.Context;
using AssetGuard.Core.Interfaces;
using AssetGuard.Data.Repositories;
using AssetGuard.Services.Interfaces;
using AssetGuard.Services.Services;

namespace AssetGuard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AssetGuardContext>(options =>
                options.UseInMemoryDatabase("AssetGuardDb")); // Using InMemory for simplicity as allowed

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IReportingService, ReportingService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddScoped<ILicenseService, LicenseService>();

            services.AddMvc(options => 
            {
                options.Filters.Add<Filters.AuditFilterAttribute>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
