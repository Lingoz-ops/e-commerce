using Ecommerce.Models;
using Ecommerce.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Interfaces;
using Services.Repositories;

namespace Ecommerce.Api
{
    /// <summary>
    /// The startup of the application
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Config</param>
        /// <param name="env">The hosting environment</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EcommerceDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Main")));

            services.AddScoped<ICustomer, CustomerRepo>();
            services.AddScoped<IOrder, OrderRepo>();
            services.AddScoped<IProduct, ProductRepo>();

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Allow requests from this origin
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce App Api", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app builder</param>
        /// <param name="env">The hosting environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Use CORS middleware
            app.UseCors("AllowOrigin");

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enabling middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enabling middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }
    }
}
