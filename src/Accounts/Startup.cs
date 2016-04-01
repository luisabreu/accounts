using Accounts.Model;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Accounts {
    public class Startup {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddOptions();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<UsersContext>(options => options.UseSqlServer(Configuration["usersCnnString"]));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) {
            if (_hostingEnvironment.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseIISPlatformHandler();

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            //app.Run(async context => { await context.Response.WriteAsync("Hello World!"); });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}