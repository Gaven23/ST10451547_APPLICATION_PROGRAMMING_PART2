using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using ST10451547_APPLICATION_PROGRAMMING_PART2.BusinessLogic.Services;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Common;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Data;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Data.DataStore;
using Microsoft.EntityFrameworkCore;
namespace ST10451547_CLOUD_COMPUTING_PART2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            try
            {
                Log.Information("Starting application");

                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();
            services.Configure<AppSettings>(Configuration);
            var appSettings = Configuration.Get<AppSettings>();
            ConfigureData(services, appSettings?.ConnectionStrings?.ApprConnectionString);
            services.AddScoped<UserService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/user/index";
                options.LogoutPath = "/User/SignOut";
                //options.AccessDeniedPath = "User/AccessDenied";
            });
            services.AddSession();
            services.AddCors();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
         
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Add this line to enable authentication middleware
            app.UseAuthorization();

            app.UseSession(); // Add this line to enable session middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=login}/{action=login}/{id?}");
            });
        }


        private void ConfigureData(IServiceCollection services, string? ApprConnectionString)
        {
            if (ApprConnectionString == null)
            {
                throw new ArgumentNullException(nameof(ApprConnectionString));
            }

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ApprConnectionString);
            });

            services.AddScoped<IDataStore, DataStore>();
        }
    }
}
