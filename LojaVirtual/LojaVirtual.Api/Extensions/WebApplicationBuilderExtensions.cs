using LojaVirtual.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var lojaVirtualConnection = builder.Configuration.GetConnectionString("LojaVirtualConnection") ?? throw new InvalidOperationException("Connection string 'LojaVirtualConnection' not found.");

            builder.Services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(lojaVirtualConnection));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();
            builder.AddTraducaoDeModelValidation();

        }

        private static void AddTraducaoDeModelValidation(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var erros = context.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .Select(e => new
                        {
                            Campo = e.Key,
                            Erros = e.Value.Errors.Select(err => err.ErrorMessage)
                        });

                    var resultado = new
                    {
                        Titulo = "Um ou mais erros de validação ocorreram.",
                        Status = 400,
                        Erros = erros
                    };

                    return new BadRequestObjectResult(resultado);
                };
            });
        }
    }
}
