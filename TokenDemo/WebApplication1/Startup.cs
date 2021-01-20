using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
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
            var apiResources = new List<ApiResource>()
            {
                new ApiResource()
                {
                    Name = "api1",
                    Scopes = {"api1.read"}
                },
            };

            var apiScopes = new[] { new ApiScope("api1.read") };

            var clients = new List<Client>()
            {
                new Client()
                {
                     ClientId = "apiClient",
                     AllowedGrantTypes = GrantTypes.ClientCredentials,
                     AllowedScopes = { "api1.read"},
                     ClientSecrets = new List<Secret>()
                     {
                         new Secret("SuperSecret".Sha256())
                     },
                },
            };

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Audience = "api1";
                options.Authority = "https://localhost:44397";
            });

            services.AddIdentityServer()
                .AddInMemoryApiScopes(new ApiScope[] { new ApiScope("api1.read") })
                .AddInMemoryApiResources(apiResources)
                .AddInMemoryClients(clients)
                .AddDeveloperSigningCredential();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
