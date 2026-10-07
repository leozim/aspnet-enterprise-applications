using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Catalogo.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Catalogo API",
                    Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications.",
                    Contact = new OpenApiContact() { Name = "Eduardo Pires", Email = "leonardomariz@alu.ufc.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license") }
                });
            });

        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}