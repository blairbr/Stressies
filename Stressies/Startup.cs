using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stressies.Data;
using Stressies.Data.Customers;
using Stressies.Services;

namespace Stressies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This is like the Global.asax file in a traditional .NET application.

        // Register dependent types (services, aka any class used in some other class) with IoC container here, 
        // which will automatically inject it anywhere it's used in the constructor of a class
        public void ConfigureServices(IServiceCollection services)
        {
            //adds all the controller classes to the service collection
            services.AddControllers();
            //allows everything in service collection to have access to an instance of anything else in there
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
