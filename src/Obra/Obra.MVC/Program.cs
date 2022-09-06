using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Obra.Infra.Data;
using Obra.MVC.Data;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ObraDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObraMVCContext") ?? 
                throw new InvalidOperationException("Connection string 'ObraMVCContext' not found."), b => b.MigrationsAssembly("Obra.Infra")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ObraDataContext>();

builder.Services.AddDbContext<ObraMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObraMVCContext") ??
                throw new InvalidOperationException("Connection string 'ObraMVCContext' not found."), b => b.MigrationsAssembly("Obra.Infra")));

//builder.Services.AddScoped<DbContext, ObraMVCContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
