using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.API.Contacts.Requests;
using Obra.API.Contracts.Response;
using Obra.API.Extensions;
using Obra.Domain.Models;
using Obra.Infra.Data;
using Obra.API;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Obra.API.Startup;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8100")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

#region Auth
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    foreach (var val in Enum.GetValues(typeof(PerfilDeUsuarioEnum)))
        options.AddPolicy(val.ToString(), policy => policy.RequireRole(val.ToString()));
});
#endregion

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigSwagger();

builder.Services.AddDbContext<ObraDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObraMVCContext") ?? throw new InvalidOperationException("Connection string 'ObraMVCContext' not found.")));

builder.Services.Configure<JsonOptions>(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddSingleton(StartupConfiguration.CreateAutoMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.AddEndpoints();

app.Run();