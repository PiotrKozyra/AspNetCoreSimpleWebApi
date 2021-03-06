using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WholesaleApi.Data;

namespace WholesaleApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddEntityFrameworkNpgsql ().AddDbContext<WholesaleContext> (opt => opt.UseNpgsql (Configuration.GetConnectionString ("WholesaleConnection")));

            services.AddControllers ();

            services.AddScoped<IProductRepository, ProductRepository> ();
            services.AddScoped<ICategoryRepository, CategoryRepository> ();
            services.AddScoped<ISupplierRepository, SupplierRepository> ();

            services.AddSwaggerGen (opt => {
                opt.SwaggerDoc ("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo {
                        Title = "Wholesale API",
                            Version = "v1"
                    }
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });

            app.UseSwagger ();

            app.UseSwaggerUI (opt => {
                opt.SwaggerEndpoint ("/swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}