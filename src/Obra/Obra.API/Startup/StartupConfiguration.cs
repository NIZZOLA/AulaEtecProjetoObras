using AutoMapper;
using Microsoft.OpenApi.Models;
using Obra.API.Contracts.Response;
using Obra.Domain.Models;

namespace Obra.API.Startup
{
    public static class StartupConfiguration
    {
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
            });
        }

        public static IMapper CreateAutoMapper()
        {
            var configAutomapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteFornecedorModel, ClienteResponseModel>();
                cfg.CreateMap<EmpreendimentoModel, EmpreendimentoResponseModel>();
                cfg.CreateMap<ContaModel, ContaResponseModel>();
                cfg.CreateMap<FotoEmpreendimentoModel, FotoResponseModel>();
                cfg.CreateMap<TipoDeDespesaReceitaModel, TipoDeReceitaDespesaResponseModel>();
                cfg.CreateMap<TipoDePagamentoModel, TipoDePagamentoResponseModel>();
            });

            return configAutomapper.CreateMapper();
        }
    }
}
