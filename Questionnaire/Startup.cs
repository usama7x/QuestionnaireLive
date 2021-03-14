using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Data.DatabaseContext;
using Questionnaire.Services;

namespace Questionnaire
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
           
               
            services.AddControllersWithViews()
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                    .AddControllersAsServices()
                    .AddNewtonsoftJson();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                    configuration.RootPath = "ClientApp/build";
            });

            // Register questionnaire context with transient lifetime
            services.AddDbContext<QuestionnaireContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("Questionnaire"),
                    o => o.MigrationsAssembly(typeof(QuestionnaireContext).Assembly.FullName))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                    ServiceLifetime.Transient);

            //Register question service
            services.AddScoped<IQuestionService, QuestionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, QuestionnaireContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dbContext.Database.EnsureCreated();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
